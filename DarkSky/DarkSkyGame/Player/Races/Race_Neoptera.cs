using Microsoft.Xna.Framework;

namespace DarkSky
{
    public class Race_Neoptera : IRace
    {
        #region Propriete
        public Anim IdleAnimRight { get; set; }
        public Anim IdleAnimUp { get; set; }
        public Anim WalkAnimRight { get; set; }
        public Anim WalkAnimUp { get; set; }
        public int Speed { get; set; }
        #endregion

        #region Constructor
        public Race_Neoptera()
        {
            WalkAnimRight = new Anim(AssetManager.PlayerWalkRight, new Vector2(32, 32), 6, 0.2f);
            WalkAnimUp = new Anim(AssetManager.PlayerWalkUp, new Vector2(32, 32), 6, 0.2f);
            IdleAnimRight = new Anim(AssetManager.PlayerIdleRight, new Vector2(32, 32), 1, 0.2f);
            IdleAnimUp = new Anim(AssetManager.PlayerIdleUp, new Vector2(32, 32), 1, 0.2f);
            Speed = 5;
        }
        #endregion
    }
}
