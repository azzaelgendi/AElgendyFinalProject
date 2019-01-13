/*
 * Azza Elgendy
 * Section1 
 * Final Project
 * Monogames
 * Halloween Run Game
 * Revision History
 * Created November 16th, 2018
 * final edits December 6th
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;
/// <summary>
/// main game
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Deleration Start
        private StartScene startScene;
        private ActionScene actionScene;
        private ActionScene2 actionScene2;
        private HelpScene helpScene;
        private AboutScene aboutScene;
        private ScoreScene scoreScene;
        private HighScore playerN, pressEnter;
        private Bat photo;
        private Bat texRect;
        //Declaration ends
        /// <summary>
        /// game1 constructor
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            IsMouseVisible = true;
            Shared.showPlayerName = ":Player:";

        }
        /// <summary>
        /// Allows the game to perform any initialization 
        /// it needs to before starting to run.
        /// This is where it can query for any 
        /// required services and load any non-graphic
        /// related content.  Calling base.
        /// Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
            graphics.PreferredBackBufferHeight);
            Window.TextInput += TextInputHandler;
            base.Initialize();


        }
        /// <summary>
        /// method to get user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">game window text input</param>
        private void TextInputHandler(object sender, TextInputEventArgs args)
        {
            var newState = Keyboard.GetState();

            if (!newState.IsKeyDown(Keys.Back) || !newState.IsKeyDown(Keys.Space))
            {
                var pressedKey = args.Key;
                var character = args.Character;
                if (char.IsLetter(character))
                {
                    playerN.Message += character.ToString().ToUpper();
                    Shared.showPlayerName += character;
                }
            }
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
            Texture2D texBat = this.Content.Load<Texture2D>("images/wallpaper1");
            Vector2 batSpeed = new Vector2(0, 0);
            Vector2 batInitPos = new Vector2(0, 300);
            photo = new Bat(this
                , spriteBatch
                , texBat
                , batInitPos
                , batSpeed
                , Shared.stage);

            actionScene = new ActionScene(this, spriteBatch);
            this.Components.Add(actionScene);

            actionScene2 = new ActionScene2(this, spriteBatch);
            this.Components.Add(actionScene2);

            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);

            aboutScene = new AboutScene(this, spriteBatch);
            this.Components.Add(aboutScene);
            scoreScene = new ScoreScene(this, spriteBatch);
            this.Components.Add(scoreScene);


            SpriteFont font = this.Content.Load<SpriteFont>("myFonts/white");
            SpriteFont font2 = this.Content.Load<SpriteFont>("myFonts/white");


            playerN = new HighScore(this, spriteBatch, " "
                , font, new Vector2(100, 310), Color.Crimson);
            pressEnter = new HighScore(this, spriteBatch, " "
                , font, new Vector2(0, 100), Color.Black);

            pressEnter.Message = "Enter your name and press Tab to play";

            Texture2D texRec = this.Content.Load<Texture2D>("images/rectangle");

            Vector2 texRecInitPos = new Vector2(100, 350);
            texRect = new Bat(this, spriteBatch, texRec
                , texRecInitPos
                , new Vector2(0, 0), Shared.stage);
            this.Components.Add(photo);
            this.Components.Add(texRect);
            this.Components.Add(playerN);
            this.Components.Add(pressEnter);
            playerN.Message = "Enter Your Name:  " + "\n";
            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);

            //instantiation ends

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back 
            //== ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here


            KeyboardState ks = Keyboard.GetState();


            if (ks.IsKeyDown(Keys.Tab))
            {
                playerN.Enabled = false;
                playerN.Visible = false;
                texRect.Visible = false;
                texRect.Enabled = false;
                pressEnter.Enabled = false;
                pressEnter.Visible = false;
                photo.Visible = false;
                photo.Enabled = false;
                startScene.show();
            }


            int selectedIndex = 0;

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    actionScene.reloadGame();
                    actionScene.show();
                    MediaPlayer.Play(actionScene.Scary);
                }
                //take care of other scenes here
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    MediaPlayer.Stop();
                    startScene.hide();

                    helpScene.show();
                }
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    MediaPlayer.Stop();
                    startScene.hide();

                    scoreScene.show();
                }
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();

                    aboutScene.show();
                }
                if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            if (actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    actionScene.hide();
                    actionScene.reloadGame();
                    startScene.show();
                }
                if (ks.IsKeyDown(Keys.Space))
                {
                    actionScene.hide();
                    actionScene.reloadGame();
                    actionScene2.reloadGame();

                    actionScene2.show();
                    MediaPlayer.Play(actionScene.Scary);
                }
            }
            if (actionScene2.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    actionScene2.hide();
                    startScene.show();
                }
            }
            if (aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    aboutScene.hide();
                    startScene.show();
                }
            }
            if (scoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    scoreScene.hide();
                    startScene.show();
                }
            }
            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    helpScene.hide();
                    startScene.show();
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.LightSteelBlue);

            base.Draw(gameTime);
        }
    }
}
