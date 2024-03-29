﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSky
{
    public interface IActor
    {
        #region Propriétés
        Vector2 Position { get; }
        IBoundingBox BoundingBox { get; }
        bool Remove { get; set; }
        float Layer { get; set; }
        #endregion

        #region Méthodes
        void RefreshBoundingBox();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        #endregion
    }
}