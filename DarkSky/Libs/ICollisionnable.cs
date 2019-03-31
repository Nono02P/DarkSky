namespace DarkSky
{
    public interface ICollisionnable : IActor
    {
        bool EnableContinuousCollisionDetection { get; set; }
        IMap Map { get; }

        void TouchedBy(ICollisionnable collisionnable);
    }
}