namespace DarkSky
{
    public interface IRace
    {
        #region Propriete
        Anim IdleAnimRight { get; set; }
        Anim IdleAnimUp { get; set; }
        Anim WalkAnimRight { get; set; }
        Anim WalkAnimUp { get; set; }
        int Speed { get; set; }
        #endregion
    }
}
