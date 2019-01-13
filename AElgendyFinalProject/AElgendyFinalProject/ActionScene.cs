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
/// <summary>
/// this class inherit the game scene 
/// </summary>
namespace AElgendyFinalProject
{/// <summary>
/// Class constructor for Action Scene 
/// creates all the game component
/// </summary>
    public class ActionScene : GameScene
    {
        #region ClassVariables
        private SpriteBatch spriteBatch;
        private Bat bat;
        private List<Bat> myBat = new List<Bat>();
        private Coins coin, coin1, coin2, coin3, coin4, coin5;
        private List<Coins> myCoins = new List<Coins>();
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
        public GameOver gameOver, gameOverLevel2;
        private int gameCounter = 1000;
        #endregion
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="game">from the main game</param>
        /// <param name="spriteBatch">for drawing </param>
        public ActionScene(Game game,
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
            bat = new Bat(game, spriteBatch
                , texBat, batInitPos, batSpeed, Shared.stage);
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
            gameScore = new HighScore(game, spriteBatch, "Score: \n "
                , font, Vector2.Zero, Color.Red);

            cm = new CollisionManager(game, myBat, player, hit, myCoins, coinHit);


            #endregion




            #region AnimationBlueBird
            //adding the blue bird Animation
            Texture2D texBlueBird = game.Content.Load<Texture2D>("images/blueBird");

            Vector2 position = new Vector2(100, 0);
            Vector2 position1 = new Vector2(300, 100);
            Vector2 blueBirdSpeed = new Vector2(-1, 0);
            Vector2 blueBirdSpeed1 = new Vector2(-1, 0);

            blueBird = new BlueBird(game, spriteBatch, texBlueBird, position, blueBirdSpeed, delay);
            blueBird1 = new BlueBird(game, spriteBatch, texBlueBird, position1, blueBirdSpeed1, delay);

            #endregion


            #region gameOver
            Texture2D texGameOver = game.Content.Load<Texture2D>("images/gameOver");
            Vector2 positionGameOver = new Vector2(0, 0);
            gameOver = new GameOver(game
                , spriteBatch, texGameOver, positionGameOver);
            #endregion
            #region LevelTwo
            Texture2D texGameOver1 = game.Content.Load<Texture2D>("images/levelTwo");
            Vector2 positionGameOver1 = new Vector2(0, 0);
            gameOverLevel2 = new GameOver(game
                , spriteBatch, texGameOver1, positionGameOver1);
            #endregion

            #region AddComponent
            this.Components.Add(cityBack);
            this.Components.Add(cityBack1);
            this.Components.Add(bat);
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
            myBat.Add(bat);
            this.Components.Add(gameOver);
            this.Components.Add(gameOverLevel2);
            #endregion
        }
        /// <summary>
        /// this to make all the game component visible 
        /// and hide the game over scene
        /// reset scores and counters
        /// </summary>
        public void reloadGame()
        {
            hideGameOverLevel2();
            cm.Score = 0;
            cm.CoinScore = 0;
            gameCounter = 1000;
            //all components visable
            cityBack.Visible = true;
            cityBack1.Visible = true;
            bat.Visible = true;
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
            //all component enabled
            cityBack.Enabled = true;
            cityBack1.Enabled = true;
            bat.Enabled = true;
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

            //except game over 
            gameOver.Enabled = false;
            gameOver.Visible = false;




        }
        /// <summary>
        /// called when game ends
        /// </summary>
        public void removeGameComponent()
        {
            //all component not visible
            cityBack.Visible = false;
            cityBack1.Visible = false;
            bat.Visible = false;
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
        }
        /// <summary>
        /// show the gameover screen
        /// </summary>
        private void GameOverShow()
        {
            gameOver.Visible = true;
            gameOver.Enabled = true;
        }
        /// <summary>
        /// show level 2 screen
        /// </summary>
        private void showGameOverLevel2()
        {
            gameOverLevel2.Visible = true;
            gameOverLevel2.Enabled = true;
        }
        /// <summary>
        /// hide level2 screen
        /// </summary>
        public void hideGameOverLevel2()
        {
            gameOverLevel2.Visible = false;
            gameOverLevel2.Enabled = false;
        }
        /// <summary>
        /// get the score read the file
        /// save the top scores
        /// </summary>
        public void SaveScore()
        {
            //local variable
            int counter = 0;
            SortedList<int, string> scoreList = new SortedList<int, string>();//list of scores
            string line;
            string[] arrayLine;
            string fileName = Environment.CurrentDirectory + "/" + "Score.text";
            //end of variables

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
                                scoreList.Add(int.Parse(arrayLine[0]),
                                    '|' + arrayLine[1]);
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
                scoreList.Add(scoreLocal
                    , '|' + DateTime.Now.ToString() 
                    +Shared.showPlayerName.ToUpper());
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
                gameScore.Message = ("Score : " 
                    + cm.CoinScore.ToString() + "\n"
                    + "Hits : " + cm.Score.ToString() + "\n");

                if (gameCounter <= 0)
                {
                    MediaPlayer.Stop();
                    if (cm.CoinScore > cm.Score)
                    {
                        gameOver.Enabled = false;
                        gameOver.Visible = false;
                        gameScore.Message = ("Congratulations  " 
                            +Shared.showPlayerName
                            + " you Win " + "\n" + "Your Score : " 
                            + cm.CoinScore.ToString()).ToString();
                        removeGameComponent();
                        showGameOverLevel2();
                    }
                    else
                    {
                        SaveScore();
                        gameScore.Message = ("Sorry" 
                            +Shared.showPlayerName
                            + " You lose " + " ! try again " 
                            + "\n" + "Bat Score: " 
                            + cm.Score.ToString()).ToString();
                        removeGameComponent();
                        GameOverShow();
                    }
                }
            }
            base.Update(gameTime);
        }
    }
}
