namespace DarkSky
{
    public class Race_Sapien : IRace
    {
        #region Propriete
        public Anim IdleAnimRight { get; set; }
        public Anim IdleAnimUp { get; set; }
        public Anim WalkAnimRight { get; set; }
        public Anim WalkAnimUp { get; set; }
        public int Speed { get; set; }
        #endregion

        #region Constructor
        public Race_Sapien()
        {

        }
        #endregion
    }
}
