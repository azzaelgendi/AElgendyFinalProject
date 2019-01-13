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
using System.IO;
namespace AElgendyFinalProject
{/// <summary>
/// class to show the score
/// </summary>
    public class ScoreScene :GameScene
    {/// <summary>
    /// inhert game scene
    /// </summary>
        private SpriteBatch spriteBatch;
        SpriteFont font;
        private HighScore highScore,pressEsc;
        private string fileName;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        public ScoreScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
           // tex = game.Content.Load<Texture2D>("images/moon");
            font = game.Content.Load<SpriteFont>("myFonts/large");

            fileName = Environment.CurrentDirectory + "/" + "Score.text";

            pressEsc = new HighScore(game, spriteBatch, " ", font, new Vector2(20, 100), Color.Black);

            pressEsc.Message = "The Top scores , press Esc to go to main menu";
            highScore = new HighScore (game, spriteBatch, " ", font, new Vector2(100,200), Color.Chocolate);
           
             this.Components.Add(highScore);
            this.Components.Add(pressEsc);
            

        }
        /// <summary>
        /// Allows the game to update the score,show the score
        /// 
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            string scoreLine ;

            scoreLine = (("Score :"
               + "    " + "Date:   "+"\n"));

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    while (!sr.EndOfStream)
                    {

                            highScore.Message = scoreLine + sr.ReadToEnd();

                        

                    }
                }

            }
            else
            {
                highScore.Message = "There's no Saved Score Yet";
            }
            base.Update(gameTime);
        }
    }
}
