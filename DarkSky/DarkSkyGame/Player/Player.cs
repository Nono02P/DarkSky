using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky
{
    public class Player : Sprite
    {
        #region Enum
        public enum eNomRace : byte
        {
            Neoptera,
            Sapien,
            Yakshi
        }
        public enum eState : byte
        {
            Idle,
            Walk
        }
        #endregion

        #region Variables privées
        private IControl _control;
        #endregion

        #region Propriétés
        public IRace Race { get; private set; }
        public eState State { get; private set; }
        #endregion

        #region Constructor
        public Player(Vector2 pPosition, eNomRace pRace, IMap pMap, IControl pControl = null) : base(null, null, pPosition, Vector2.Zero, Vector2.One, Vector2.Zero, 0, 0.0f, pMap)
        {
            if (pRace == eNomRace.Neoptera)
            {
                Race = new Race_Neoptera();
            }
            else if (pRace == eNomRace.Sapien)
            {
                Race = new Race_Sapien();
            }
            else if (pRace == eNomRace.Yakshi)
            {
                Race = new Race_Yakshi();
            }

            CurrentAnim = Race.IdleAnimUp;
            State = eState.Idle;
            if (pControl == null)
                _control = new KeyboardControl();
            else
                _control = pControl;
        }
        #endregion

        public void ChangeAnim(Anim pNewAnim)
        {
            if (_control.Up)
            {
                CurrentAnim = pNewAnim;
                Effects = SpriteEffects.None;
            }
            if (_control.Down)
            {
                CurrentAnim = pNewAnim;
                Effects = SpriteEffects.FlipVertically;
            }
            if (_control.Right)
            {
                CurrentAnim = pNewAnim;
                Effects = SpriteEffects.None;
            }
            if (_control.Left)
            {
                CurrentAnim = pNewAnim;
                Effects = SpriteEffects.FlipHorizontally;
            }
        }

        #region Update
        public override void Update(GameTime gameTime)
        {
            Velocity = Vector2.Zero;
            if (_control.Up)
            {
                Velocity += new Vector2(0, - Race.Speed);
            }
            if (_control.Down)
            {
                Velocity += new Vector2(0, Race.Speed);
            }
            if (_control.Right)
            {
                Velocity += new Vector2(Race.Speed, 0);
            }
            if (_control.Left)
            {
                Velocity += new Vector2(-Race.Speed, 0);
            }
            
            // Change State
            // If Idle
            if (State == eState.Walk && Velocity == Vector2.Zero)
            {
                State = eState.Idle;
                if (_control.Up || _control.Down)
                {
                    ChangeAnim(Race.IdleAnimUp);
                }
                if (_control.Right || _control.Left)
                {
                    ChangeAnim(Race.IdleAnimRight);
                }
            }
            // If walk
            if (Velocity != Vector2.Zero)
            {
                State = eState.Walk;
                if (_control.Up || _control.Down)
                {
                    ChangeAnim(Race.WalkAnimUp);
                }
                if (_control.Right || _control.Left)
                {
                    ChangeAnim(Race.WalkAnimRight);
                }
            }
            
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
