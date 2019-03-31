using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DarkSky
{
    public class AssetManager
    {
        #region Musiques
        public static Song mscMenu { get; private set; }
        public static Song mscGameplay { get; private set; }
        public static Song mscGameover { get; private set; }
        public static Song mscVictory { get; private set; }
        #endregion

        #region Sons
        
        #endregion

        #region Font
        public static SpriteFont MainFont { get; private set; }
        public static SpriteFont MenuFont { get; private set; }
        #endregion

        #region Textures
        public static Texture2D Menu { get; private set; }
        public static Texture2D HowToPlay { get; private set; }
        public static Texture2D Victory { get; private set; }
        public static Texture2D Gameover { get; private set; }
        #endregion

        #region Load
        public static void Load(ContentManager pContent)
        {
            /*
            #region Musiques
            mscMenu = pContent.Load<Song>("_Musics/Menu");
            mscGameplay = pContent.Load<Song>("_Musics/Gameplay");
            mscVictory = pContent.Load<Song>("_Musics/Victory");
            mscGameover = pContent.Load<Song>("_Musics/Gameover");
            #endregion

            #region Sons

            #endregion
            */

            #region Font
            MainFont = pContent.Load<SpriteFont>("_Font/MainFont");
            MenuFont = pContent.Load<SpriteFont>("_Font/MenuFont");
            #endregion
            /*
            #region Textures
            Menu = pContent.Load<Texture2D>("_Background/Menu");
            HowToPlay = pContent.Load<Texture2D>("_Background/HowToPlay");
            Gameover = pContent.Load<Texture2D>("_Background/Defeat");
            Victory = pContent.Load<Texture2D>("_Background/Victory");
            #endregion
            */
        }
        #endregion
    }
}