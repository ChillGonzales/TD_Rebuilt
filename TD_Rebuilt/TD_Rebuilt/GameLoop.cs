using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using TD_Rebuilt.Helpers;
using TD_Rebuilt.Game_Objects;

namespace TD_Rebuilt
{    
    public class GameLoop : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;        
        public static Tile[,] backgroundTiles;
        private GameManager gameManager;
        private Texture2D fireTowerTexture, iceTowerTexture;
        bool pressed;
        public static bool boundToMouse = false;
        public static int screenX, screenY;
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
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            screenX = 200 + graphics.GraphicsDevice.Viewport.Width / 2;
            screenY = 100 + graphics.GraphicsDevice.Viewport.Height / 2;
            gameManager = new GameManager();
        }
        
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
                
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T)) { pressed = true; }
            if(keyboardState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.T) && pressed)
            {
                pressed = false;
                boundToMouse = true;
                GameManager.AddTower(Cursor.Position.X, Cursor.Position.Y, fireTowerTexture);                
            }
            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) { boundToMouse = false; }
            if (boundToMouse) { gameManager.UpdateTowerPositions(Cursor.Position.X, Cursor.Position.Y); }                 

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            spriteBatch.Begin();

            Tile.DrawTileArray(ref spriteBatch, ref backgroundTiles);
            gameManager.DrawGameObjects(ref spriteBatch);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
