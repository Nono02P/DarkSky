using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.IO;

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
        public static Dictionary<string, Texture2D> TileSet { get; private set; }
        public static Texture2D imgPlayer { get; private set; }
        public static Texture2D PlayerWalkRight { get; private set; }
        public static Texture2D PlayerWalkUp { get; private set; }
        public static Texture2D PlayerIdleRight { get; private set; }
        public static Texture2D PlayerIdleUp { get; private set; }
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

            #region Textures
            /*Menu = pContent.Load<Texture2D>("_Background/Menu");
            HowToPlay = pContent.Load<Texture2D>("_Background/HowToPlay");
            Gameover = pContent.Load<Texture2D>("_Background/Defeat");
            Victory = pContent.Load<Texture2D>("_Background/Victory");
            */

            #region TileSet
            TileSet = new Dictionary<string, Texture2D>();
            string[] fileNames = Directory.GetFiles("Content/_Images/TileSet/");
            for (int i = 0; i < fileNames.Length; i++)
            {
                string fullName = fileNames[i].Split(new char[] { '.' })[0];    // Retire l'extension
                string[] splitteName = fullName.Split(new char[] { '/' });      // Découpe les dossiers
                string name = splitteName[splitteName.Length - 1];              // Récupère le nom du fichier
                string contentFileName = string.Empty;
                for (int j = 1; j < splitteName.Length; j++)
                {
                    string s = splitteName[j];
                    contentFileName += s;
                    if (j < splitteName.Length - 1)
                        contentFileName += "\\";
                }
                Texture2D img = pContent.Load<Texture2D>(contentFileName);
                TileSet.Add(name, img);
            }
            #endregion

            #region Player
            imgPlayer = pContent.Load<Texture2D>("_Images/Player/Player");
            PlayerWalkRight = pContent.Load<Texture2D>("_Images/Player/PlayerWalkRight");
            PlayerWalkUp = pContent.Load<Texture2D>("_Images/Player/PlayerWalkUp");
            PlayerIdleRight = pContent.Load<Texture2D>("_Images/Player/PlayerIdleRight");
            PlayerIdleUp = pContent.Load<Texture2D>("_Images/Player/PlayerIdleUp");
            #endregion

            #endregion
        }
        #endregion
    }
}