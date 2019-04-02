using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using TiledSharp;

namespace DarkSky
{
    public class MapManager : IMap
    {
        #region Variables privées
        private Vector2 _tileSize;
        private string _currentMap;
        #endregion

        #region Propriétés
        public Dictionary<string, TmxMap> Maps { get; private set; }
        public Point MapSize { get; private set; }
        public string CurrentMap
        {
            get { return _currentMap; }
            set
            {
                _currentMap = value;
                TmxMap map = Maps[value];
                _tileSize = new Vector2(map.TileWidth, map.TileHeight);
                MapSize = new Point(map.Width, map.Height);
            }
        }
        #endregion

        #region Constructeur
        public MapManager(string pPathMaps)
        {
            Maps = new Dictionary<string, TmxMap>();
            string[] fileNames = Directory.GetFiles(pPathMaps);
            for (int i = 0; i < fileNames.Length; i++)
            {
                string name = fileNames[i];
                TmxMap map = new TmxMap(name);
                Maps.Add(name, map);
                if (i == 0)
                    CurrentMap = name;
            }
        }
        #endregion

        private Point GetPositionOnGrid(Vector2 pCoordonatePosition)
        {
            return (pCoordonatePosition / _tileSize).ToPoint();
        }

        private Vector2 GetGridCoordonate(Point pPositionOnGrid)
        {
            return pPositionOnGrid.ToVector2() * _tileSize;
        }

        private int GetTileID(Point pPositionOnGrid, int pLayer = 0)
        {
            TmxMap map = Maps[_currentMap];
            int tileIndex = pPositionOnGrid.X + map.Width * pPositionOnGrid.Y;
            return map.Layers[pLayer].Tiles[tileIndex].Gid;
        }

        private int GetTileID(Vector2 pCoordonatePosition, int pLayer = 0)
        {
            if (IsOnMap(pCoordonatePosition))
                return GetTileID(GetPositionOnGrid(pCoordonatePosition), pLayer);
            else
                return -1;
        }

        #region Sur la map
        public bool IsOnMap(Point pPositionOnGrid)
        {
            return pPositionOnGrid.X >= 0 && pPositionOnGrid.X < MapSize.X &&
                    pPositionOnGrid.Y >= 0 && pPositionOnGrid.Y < MapSize.Y;
        }

        public bool IsOnMap(Vector2 pPosition)
        {
            return IsOnMap(GetPositionOnGrid(pPosition));
        }
        #endregion

        #region Collisions
        public bool IsSolid(Vector2 pPosition)
        {
            int gid = GetTileID(pPosition);
            TmxMap map = Maps[_currentMap];
            TmxTileset tileset = map.Tilesets[0];
            for (int i = 0; i < map.Tilesets.Count; i++)
            {
                TmxTileset ts = map.Tilesets[i];
                if (gid > ts.FirstGid)
                {
                    tileset = ts;
                }
            }
            int tileId = gid - tileset.FirstGid;
            bool result = false;
            for (int i = 0; i < tileset.Tiles.Count; i++)
            {
                TmxTilesetTile tile = tileset.Tiles[i];
                if (tile.Id == tileId)
                {
                    foreach (KeyValuePair<string, string> property in tile.Properties)
                    {
                        if ("ISSOLID" == property.Key.ToUpper().Replace(" ", string.Empty).Replace("_", string.Empty))
                        {
                            result = bool.Parse(property.Value);
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            TmxMap map = Maps[CurrentMap];
            TmxList<TmxLayer> layers = map.Layers;
            TmxList<TmxTileset> tilesets = map.Tilesets;
            for (int i = 0; i < layers.Count; i++)
            {
                TmxLayer layer = layers[i];
                Collection<TmxLayerTile> tiles = layer.Tiles;
                for (int j = 0; j < tiles.Count; j++)
                {
                    TmxLayerTile tile = tiles[j];
                    int gid = tile.Gid;
                    if (gid > 0)
                    {
                        Texture2D texture = null;
                        int offset = 1;
                        if (tilesets.Count > 0)
                        {
                            TmxTileset tileset = tilesets[0];
                            for (int k = 1; k < tilesets.Count; k++)
                            {
                                TmxTileset ts = tilesets[k];
                                if (gid > ts.FirstGid)
                                {
                                    tileset = ts;
                                }
                            }
                            texture = AssetManager.TileSet[tileset.Name];
                            offset = tileset.FirstGid;
                        }
                        int tileId = gid - offset;
                        Vector2 tilesetCellSize = new Vector2(texture.Width / _tileSize.X, texture.Height / _tileSize.Y);

                        Vector2 tilesetIndex = new Vector2(tileId % tilesetCellSize.X, (int)(tileId / tilesetCellSize.X));
                        Rectangle tilesetRect = new Rectangle((tilesetIndex * _tileSize).ToPoint(), _tileSize.ToPoint());

                        Vector2 tileIndex = new Vector2(j % MapSize.X, (int)(j / MapSize.X));
                        Vector2 tilePosition = tileIndex * _tileSize;
                        spriteBatch.Draw(texture, tilePosition, tilesetRect, Color.White);
                    }
                }
            }
        }
        #endregion
    }
}
