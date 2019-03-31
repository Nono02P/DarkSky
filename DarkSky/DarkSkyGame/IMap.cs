using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSky
{
    public interface IMap
    {
        Vector2 MapSize { get; }

        bool IsOnMap(Vector2 pPosition);
        bool IsSolid(Vector2 pPosition);
        bool IsSolid(Rectangle pRectangle);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
