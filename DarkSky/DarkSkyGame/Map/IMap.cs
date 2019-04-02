using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSky
{
    public interface IMap
    {
        Point MapSize { get; }

        bool IsOnMap(Vector2 pPosition);
        bool IsSolid(Vector2 pPosition);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
