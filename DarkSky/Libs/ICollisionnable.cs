namespace DarkSky
{
    public interface ICollisionnable : IActor
    {
        void TouchedBy(ICollisionnable collisionnable);
    }
}