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
        public Vector2 MapSize { get; private set; }
        public string CurrentMap
        {
            get { return _currentMap; }
            set
            {
                _currentMap = value;
                TmxMap map = Maps[value];
                _tileSize = new Vector2(map.TileWidth, map.TileHeight);
                MapSize = new Vector2(map.Width, map.Height);
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

        private int GetTilePosition(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }

        private int GetTileID(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }

        #region Sur la map
        public bool IsOnMap(Vector2 pPosition)
        {
            return  pPosition.X >= 0 && pPosition.X < MapSize.X &&
                    pPosition.Y >= 0 && pPosition.Y < MapSize.Y;
        }
        #endregion

        #region Collisions
        public bool IsSolid(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }

        public bool IsSolid(Rectangle pRectangle)
        {
            throw new NotImplementedException();
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
                        TmxTileset tileset = tilesets[0];
                        for (int k = 1; k < tilesets.Count; k++)
                        {
                            TmxTileset ts = tilesets[k];
                            if (gid > ts.FirstGid)
                            {
                                tileset = ts;
                            }
                        }
                        int tileId = gid - tileset.FirstGid;
                        Texture2D texture = AssetManager.TileSet[tileset.Name];
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
