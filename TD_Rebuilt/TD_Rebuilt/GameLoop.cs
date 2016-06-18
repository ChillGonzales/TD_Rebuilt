using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Drawing;
using TD_Rebuilt.Backdrop;
using TD_Rebuilt.Game_Objects;

namespace TD_Rebuilt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameLoop : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;        
        Tile[,] backgroundTiles;
        private Texture2D fireTowerTexture, iceTowerTexture;
        bool pressed;
        public GraphicsDeviceManager GraphicsProp { get { return graphics; } }
        public static Vector2 cursorPosition
        {
            get { return cursorPosition; }
            set { cursorPosition = value; }
        }

        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            var grassTexture = this.Content.Load<Texture2D>("Landscape/landscape_28");
            var dirtTexture = this.Content.Load<Texture2D>("Landscape/landscape_37");
            fireTowerTexture = this.Content.Load<Texture2D>("Buildings/tower_35");
            iceTowerTexture = this.Content.Load<Texture2D>("Buildings/tower_36");         
            
            backgroundTiles = Tile.CreateTileArray(20, grassTexture);
        }
        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            cursorPosition = new Vector2(Cursor.Position.X, Cursor.Position.Y);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T))
                pressed = true;
            if(keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T) && pressed)
            {
                pressed = false;
                GameManager.AddTower(cursorPosition.X, cursorPosition.Y, fireTowerTexture);
            }

            GameManager.UpdateTowerPositions();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Tile.DrawTileArray(ref spriteBatch, ref backgroundTiles);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
