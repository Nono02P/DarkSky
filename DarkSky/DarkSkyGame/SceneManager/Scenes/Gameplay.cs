using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DarkSky
{
    public class Gameplay : Scene
    {
        #region Constantes

        #endregion

        #region Evènements

        #endregion

        #region Variables privées
        MapManager _mapManager;
        #endregion

        #region Propriétés

        #endregion

        #region Load/Unload
        public override void Load()
        {
            /*
            #region Démarrage des musiques
            sndMusic = AssetManager.mscGameplay;
            MediaPlayer.Play(sndMusic);
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            #endregion
            
            #region Ajout des bruitages
            
            #endregion
            */
            _mapManager = new MapManager("Content\\_Maps");

            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            #region Collisions entre acteurs
            // Gère les collisions entre IActors
            List<IActor> lstCollisionnable = lstActors.FindAll(actor => actor is ICollisionnable);
            for (int i = 0; i < lstCollisionnable.Count; i++)
            {
                IActor actor = lstCollisionnable[i];

                for (int j = 0; j < lstCollisionnable.Count; j++)
                {
                    IActor actor2 = lstCollisionnable[j];
                    ICollisionnable col = (ICollisionnable)actor;
                    ICollisionnable col2 = (ICollisionnable)actor2;
                    if (utils.Collide(actor, actor2))
                    {
                        col.TouchedBy(col2);
                        col2.TouchedBy(col);
                    }
                }
            }
            #endregion

            // Test chargement de l'autre map
            // A supprimer !
            if (Input.OnPressed(Keys.Space))
                _mapManager.CurrentMap = "Content\\_Maps\\map2.tmx";

            base.Update(gameTime);
        }
        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _mapManager.Draw(spriteBatch, gameTime);
            base.Draw(spriteBatch, gameTime);
        }
        #endregion
    }
}