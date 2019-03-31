using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSky
{
    #region Enumérations
    public enum eDirection : byte { Top, Right, Bottom, Left }
    public enum VAlign : byte { None, Top, Middle, Bottom }
    public enum HAlign : byte { None, Left, Center, Right }
    public enum SceneType : byte { Menu, Gameplay, Gameover, Victory, HowToPlay, }
    #endregion

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        #region Propriétés
        public static GraphicsDeviceManager graphics { get; private set; }
        public static SpriteBatch spriteBatch { get; private set; }
        public static Viewport Screen { get; private set; }
        public static Camera Camera { get; private set; }
        public static bool ExitGame { get; set; }

        public static readonly bool UsingMouse = true;
        public static readonly bool UsingKeyboard = true;
        public static readonly bool UsingGamePad = false;
        public static readonly int GamePadMaxPlayer = 0;
        #endregion

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.IsFullScreen = screenWidth == graphics.PreferredBackBufferWidth && screenHeight == graphics.PreferredBackBufferHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.Load(Content);
            Screen = GraphicsDevice.Viewport;
            IsMouseVisible = true;
            Camera = new Camera(Screen, Vector3.Zero);
            SceneManager.ChangeScene(SceneType.Menu);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ExitGame)
                Exit();

            Input.Update();
            Camera.Update();

            SceneManager.CurrentScene.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Camera.Transformation);
            SceneManager.CurrentScene.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
