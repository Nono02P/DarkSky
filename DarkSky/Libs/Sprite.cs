﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSky
{
    public class Sprite : ICollisionnable
    {
        #region Variables privées
        private Vector2 _position = Vector2.Zero;
        private Rectangle? _imgBox = null;
        private Vector2 _origin = Vector2.Zero;
        private Vector2 _scale = Vector2.One;
        private Texture2D _image;
        #endregion

        #region Propriétés
        public IMap Map { get; private set; }
        public bool EnableContinuousCollisionDetection { get; set; }
        public Vector2 Position { get => _position; set { if (_position != value) { _position = value; RefreshBoundingBox(); } } }
        public Vector2 Velocity { get; set; }
        public IBoundingBox BoundingBox { get; protected set; } = new RectangleBBox();
        public Rectangle? ImgBox { get => _imgBox; protected set { if (_imgBox != value) { _imgBox = value; RefreshBoundingBox(); } } }
        public Vector2 Origin { get => _origin; set { if (_origin != value) { _origin = value; RefreshBoundingBox(); } } }
        public Vector2 Scale { get => _scale; set { if (_scale != value) { _scale = value; RefreshBoundingBox(); } } }
        public Texture2D Image { get => _image; protected set { _image = value; RefreshBoundingBox(); } }
        public float Angle { get; set; }
        public bool Remove { get; set; }
        public SpriteEffects Effects { get; set; }
        public bool ShowBoundingBox { get; set; }
        public float Layer { get; set; } = 0f;
        #endregion

        #region Constructeur
        public Sprite(Texture2D pImage, Rectangle? pImgBox, Vector2 pPosition, Vector2 pOrigin, Vector2 pScale, IMap pMap, bool pEnableContinuousCollisionDetection = false)
        {
            Image = pImage;
            ImgBox = pImgBox;
            Position = pPosition;
            Origin = pOrigin;
            Scale = pScale;
            Effects = SpriteEffects.None;
            Map = pMap;
            EnableContinuousCollisionDetection = pEnableContinuousCollisionDetection;
            SceneManager.CurrentScene.AddActor(this);
        }

        protected Sprite(Texture2D pImage, IMap pMap)
        {
            Image = pImage;
            Map = pMap;
            SceneManager.CurrentScene.AddActor(this);
        }

        protected Sprite(IMap pMap)
        {
            Map = pMap;
            SceneManager.CurrentScene.AddActor(this);
        }
        #endregion
        
        #region Collisions
        public virtual void TouchedBy(ICollisionnable collisionnable) { }
        #endregion

        #region BoundingBox
        public virtual void RefreshBoundingBox()
        {
            RectangleBBox r = (RectangleBBox)BoundingBox;
            if (ImgBox == null)
            {
                r.Rectangle = new Rectangle((int)(Position.X - Origin.X * Scale.X), (int)(Position.Y - Origin.Y * Scale.Y), (int)(Image.Width * Scale.X), (int)(Image.Height * Scale.Y));
            }
            else
            {
                r.Rectangle = new Rectangle((int)(Position.X - Origin.X * Scale.X), (int)(Position.Y - Origin.Y * Scale.Y), (int)(ImgBox.Value.Width * Scale.X), (int)(ImgBox.Value.Height * Scale.Y));
            }
        }
        #endregion

        #region Update
        public virtual void Update(GameTime gameTime)
        {
            Vector2 collisionPos = Position;
            Position += Velocity;
            bool collision = false;
            if (EnableContinuousCollisionDetection)
            {
                Vector2 direction = Vector2.Normalize(Velocity);
                while (!collision && (collisionPos.X < Position.X && collisionPos.Y < Position.Y) && !utils.OutOfScreen(Position))
                {
                    collision = Map.IsSolid(collisionPos);
                    collisionPos += direction;
                }
            }
            else
            {
                collision = Map.IsSolid(((RectangleBBox)BoundingBox).Rectangle);
            }
            if (collision)
            {
                Position = collisionPos;
            }
        }
        #endregion

        #region Draw
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Image, Position, ImgBox, Color.White, Angle, Origin, Scale, Effects, 0);
            if (ShowBoundingBox)
                BoundingBox.Draw(spriteBatch, gameTime);
        }
        #endregion
    }
}