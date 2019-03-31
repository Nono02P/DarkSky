using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            #region Collisions
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

            base.Update(gameTime);
        }
        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
        #endregion
    }
}