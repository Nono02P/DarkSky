using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace DarkSky
{
    public class MapManager
    {
        #region Variables privées
        private int _currentMap;
        #endregion

        #region Propriétés
        public List<TmxMap> Maps { get; private set; }
        #endregion

        public MapManager()
        {
            Maps = new List<TmxMap>();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            TmxList<TmxLayer> layers = Maps[_currentMap].Layers;
            for (int i = 0; i < layers.Count; i++)
            {
                TmxLayer layer = layers[i];
                Collection<TmxLayerTile> tiles = layer.Tiles;
                for (int j = 0; j < tiles.Count; j++)
                {
                    TmxLayerTile tile = tiles[j];
                    int gid = tile.Gid;
                    
                }
            }
        }
    }
}
