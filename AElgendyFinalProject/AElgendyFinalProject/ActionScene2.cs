/*
 * Azza Elgendy
 * Section1 
 * Final Project
 * Monogames
 * Halloween Run Game
 * Revision History
 * Created November 16th, 2018
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.IO;
namespace AElgendyFinalProject
{   /// <summary>
    /// Level 2 of the game add second enemy
    /// </summary>
    public class ActionScene2 : GameScene
    {       /// <summary>
            /// level 2 components
            /// </summary>
        #region ClassVariables
        private SpriteBatch spriteBatch;
        private Bat bat, bat1;
        private Coins coin, coin1, coin2, coin3, coin4, coin5;
        private List<Coins> myCoins = new List<Coins>();
        private List<Bat> myBat = new List<Bat>();
        private Player player;
        private BlueBird blueBird, blueBird1;
        public CollisionManager cm;
        private HighScore gameScore;
        SpriteFont font;
        private ScrollingBackGround cityBack, cityBack1, birds;
        private Song scary;
        public Song Scary { get => scary; set => scary = value; }
        public int delay = 3;
        public string fileName;
        private int scoreLocal = 0;
        public GameOver gameOver;
        int gameCounter = 1000;
        #endregion
        /// <summary>
        /// class conctructor for level2
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        public ActionScene2(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            scary = game.Content.Load<Song>("Music/backMusic");
            SoundEffect hit = game.Content.Load<SoundEffect>("Music/hit");
            SoundEffect coinHit = game.Content.Load<SoundEffect>("Music/coinHit1");
            MediaPlayer.IsRepeating = true;

            #region city
            Texture2D city1 = game.Content.Load<Texture2D>("images/wallpaper1");
            Vector2 pos = new Vector2(0, Shared.stage.Y - city1.Height - 20);//change the y 
            Vector2 pos2 = new Vector2(0, Shared.stage.Y - city1.Height);//allign the image to the bottom

            cityBack = new ScrollingBackGround(game, spriteBatch, city1, pos, new Vector2(-5, 0));
            cityBack1 = new ScrollingBackGround(game, spriteBatch, city1, pos2, new Vector2(-1, 0));

            #endregion


            #region theBat
            //the bat
            Texture2D texBat = game.Content.Load<Texture2D>("images/bat-th");
            Vector2 batSpeed = new Vector2(-4, -5);
            Vector2 batInitPos = new Vector2(Shared.stage.X / 4 - texBat.Width / 2,
            Shared.stage.Y / 4 - texBat.Height / 2);
            bat = new Bat(game, spriteBatch, texBat, batInitPos, batSpeed, Shared.stage);
            Texture2D texBat1 = game.Content.Load<Texture2D>("images/pumpkin-icon");
            Vector2 batSpeed1 = new Vector2(-1, -1);
            Vector2 batInitPos1 = new Vector2(Shared.stage.X / 3 - texBat.Width,
            Shared.stage.Y / 4 - texBat.Height);
            bat1 = new Bat(game, spriteBatch, texBat1, batInitPos1, batSpeed1, Shared.stage);
            myBat.Add(bat);
            myBat.Add(bat1);

            #endregion


            #region Coins
            Texture2D texCoins = game.Content.Load<Texture2D>("images/Coin_sprites");
            Vector2 coinsSpeed = new Vector2(0, 3);
            Vector2 coinsInitPos = new Vector2(120, 0);
            coin = new Coins(game, spriteBatch, texCoins, coinsInitPos, coinsSpeed, delay);

            //coin1
            Vector2 coinsSpeed1 = new Vector2(0, 1);
            Vector2 coinsInitPos1 = new Vector2(700, 0);
            coin1 = new Coins(game, spriteBatch, texCoins, coinsInitPos1, coinsSpeed1, delay);


            //coin2 
            Vector2 coinsSpeed2 = new Vector2(0, 5);
            Vector2 coinsInitPos2 = new Vector2(900, 0);
            coin2 = new Coins(game, spriteBatch, texCoins, coinsInitPos2, coinsSpeed2, delay);


            //coin3 
            Vector2 coinsSpeed3 = new Vector2(0, 6);
            Vector2 coinsInitPos3 = new Vector2(350, 0);
            coin3 = new Coins(game, spriteBatch, texCoins, coinsInitPos3, coinsSpeed3, delay);


            //coin4 
            Vector2 coinsSpeed4 = new Vector2(0, 4);
            Vector2 coinsInitPos4 = new Vector2(300, 0);
            coin4 = new Coins(game, spriteBatch, texCoins, coinsInitPos4, coinsSpeed4, delay);


            //coin5 
            Vector2 coinsSpeed5 = new Vector2(0, 2);
            Vector2 coinsInitPos5 = new Vector2(30, 0);
            coin5 = new Coins(game, spriteBatch, texCoins, coinsInitPos5, coinsSpeed5, delay);


            #endregion

            #region thePlayer
            // the player
            Texture2D texPlayer = game.Content.Load<Texture2D>("images/witch1");
            Vector2 stage = new Vector2(Shared.stage.X,
                Shared.stage.Y);
            Vector2 positionPlayer = new Vector2(stage.X / 2, stage.Y / 2);
            Vector2 speed = Vector2.One;
            player = new Player(game, spriteBatch, texPlayer, positionPlayer, speed, stage);
            #endregion




            #region skyBirds
            Texture2D texs = game.Content.Load<Texture2D>("images/birds");
            birds = new ScrollingBackGround(game, spriteBatch, texs, new Vector2(800, 5), new Vector2(-1, 0));
            #endregion


            #region CollosionManager&Score

            //collision manager
            font = game.Content.Load<SpriteFont>("myFonts/regular");
            gameScore = new HighScore(game, spriteBatch, "Score: \n ", font, Vector2.Zero, Color.Red);

            cm = new CollisionManager(game, myBat, player, hit, myCoins, coinHit);


            #endregion

            #region AnimationBlueBird
            //adding the blue bird Animation
            Texture2D texBlueBird = game.Content.Load<Texture2D>("images/blueBird");

            Vector2 position = new Vector2(200, 200);
            Vector2 position1 = new Vector2(400, 300);
            Vector2 blueBirdSpeed = new Vector2(-3, -1);
            Vector2 blueBirdSpeed1 = new Vector2(-1, -1);

            blueBird = new BlueBird(game, spriteBatch, texBlueBird, position, blueBirdSpeed, delay);
            blueBird1 = new BlueBird(game, spriteBatch, texBlueBird, position1, blueBirdSpeed1, delay);

            #endregion


            #region gameOver
            Texture2D texGameOver = game.Content.Load<Texture2D>("images/gameOver");
            Vector2 positionGameOver = new Vector2(0, 0);
            gameOver = new GameOver(game, spriteBatch, texGameOver, positionGameOver);
            #endregion

            #region AddComponent
            this.Components.Add(cityBack);
            this.Components.Add(cityBack1);
            this.Components.Add(bat);
            this.Components.Add(bat1);
            this.Components.Add(coin);
            myCoins.Add(coin);
            this.Components.Add(coin1);
            myCoins.Add(coin1);
            this.Components.Add(coin2);
            myCoins.Add(coin2);
            this.Components.Add(coin3);
            myCoins.Add(coin3);
            this.Components.Add(coin4);
            myCoins.Add(coin4);
            this.Components.Add(coin5);
            myCoins.Add(coin5);
            this.Components.Add(player);
            this.Components.Add(birds);
            this.Components.Add(cm);
            this.Components.Add(gameScore);
            gameScore.Message += cm.Score.ToString();

            this.Components.Add(blueBird);
            this.Components.Add(blueBird1);

            this.Components.Add(gameOver);
            #endregion
        }
        /// <summary>
        /// enable/visible game components
        /// </summary>
        public void reloadGame()
        {
            //reset the counters
            cm.Score = 0;
            cm.CoinScore = 0;
            gameCounter = 1000;

            cityBack.Visible = true;
            cityBack1.Visible = true;
            bat.Visible = true;
            bat1.Visible = true;
            coin.Visible = true;
            coin1.Visible = true;
            coin2.Visible = true;
            coin3.Visible = true;
            coin4.Visible = true;
            coin5.Visible = true;
            player.Visible = true;
            birds.Visible = true; ;
            cm.Enabled = true;
            blueBird.Visible = true;
            blueBird1.Visible = true;
            cityBack.Enabled = true;
            cityBack1.Enabled = true;
            bat.Enabled = true;
            bat1.Enabled = true;
            coin.Enabled = true;
            coin1.Enabled = true;
            coin2.Enabled = true;
            coin3.Enabled = true;
            coin4.Enabled = true;
            coin5.Enabled = true;
            player.Enabled = true;
            birds.Enabled = true; ;
            cm.Enabled = true;
            blueBird.Enabled = true;
            blueBird1.Enabled = true;
            gameOver.Enabled = false;
            gameOver.Visible = false;
        }
        /// <summary>
        /// disable /not visible  game components
        /// </summary>
        public void removeGameComponent()
        {

            cityBack.Visible = false;
            cityBack1.Visible = false;
            bat.Visible = false;
            bat1.Visible = false;
            coin.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            player.Visible = false;
            birds.Visible = false; ;
            cm.Enabled = false;


            blueBird.Visible = false;
            blueBird1.Visible = false;


            cityBack.Enabled = false;
            cityBack1.Enabled = false;
            bat.Enabled = false;
            bat1.Enabled = false;
            coin.Enabled = false;
            coin1.Enabled = false;
            coin2.Enabled = false;
            coin3.Enabled = false;
            coin4.Enabled = false;
            coin5.Enabled = false;
            player.Enabled = false;
            birds.Enabled = false; ;
            cm.Enabled = false;


            blueBird.Enabled = false;
            blueBird1.Enabled = false;

            gameOver.Visible = true;
            gameOver.Enabled = true;


        }
        /// <summary>
        /// check the file 
        /// save the top scores
        /// </summary>
        public void SaveScore()
        {
            int counter = 0;
            SortedList<int, string> scoreList = new SortedList<int, string>();//list of scores
            string line;
            string[] arrayLine;
            string fileName = Environment.CurrentDirectory + "/" + "Score.text";
            scoreLocal = cm.CoinScore;

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            arrayLine = line.Split('|');
                            try
                            {
                                scoreList.Add(Convert.ToInt32(arrayLine[0]), '|' + arrayLine[1]);
                            }
                            catch (Exception)
                            {

                                removeGameComponent();
                                gameOver.Visible = true;
                                gameOver.Enabled = true;
                            }
                            
                        }

                    }
                }

            }
            else
            {
                gameScore.Message = "There's no Saved Score Yet";
            }
            if (!scoreList.ContainsKey(scoreLocal))//check if the score repeated
            {
                scoreList.Add(scoreLocal, '|' + DateTime.Now.ToString() + Shared.showPlayerName);
            }
            
            if (File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {

                    foreach (KeyValuePair<int, string> kvp in scoreList.Reverse())
                    {
                        counter++;//Limit to top 5 scores
                        if (counter <= 5)
                        {
                            sw.WriteLine(kvp.Key + kvp.Value);
                        }

                    }
                    return;

                }
            }
            else
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
            }




        }
        /// <summary>
        /// check the score 
        /// checking for winner
        /// remove game componets
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (cm.Score >= 0 || cm.CoinScore >= 0)
            {
                gameCounter--;
                gameScore.Message = ("Level 2 Score : " + cm.CoinScore.ToString() + "\n"
                    + "Hits : " + cm.Score.ToString() + "\n");

                if (gameCounter <= 0)
                {
                    SaveScore();
                    removeGameComponent();
                    MediaPlayer.Stop();

                    if (cm.CoinScore > cm.Score)
                    {
                        gameScore.Message = ("Congratulations  " 
                            +Shared.showPlayerName
                            + " you Win " + "\n" + "Your Score : " 
                            + cm.CoinScore.ToString()).ToString();


                    }
                    else
                    {
                        gameScore.Message = ("Sorry" 
                            + Shared.showPlayerName 
                            + " You lose " + " ! try again " + "\n" + "Bat Score: " 
                            + cm.Score.ToString()).ToString();
                    }
                }

            }
            base.Update(gameTime);
        }
    }
}
