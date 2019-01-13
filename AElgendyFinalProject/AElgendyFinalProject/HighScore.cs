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
using Microsoft.Xna.Framework.Media;
/// <summary>
/// high score inherit DrawableGameComponent
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// draw a string "Font" on the screen
    /// </summary>
    public class HighScore:DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private string message;
        private SpriteFont font;
        private Vector2 position;
        private Color color;

        public string Message { get => message; set => message = value; }
        /// <summary>
        /// high score constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="message">string shown on the screen</param>
        /// <param name="font">sprite font</param>
        /// <param name="position">position of the message</param>
        /// <param name="color">color of the message</param>

        public HighScore(Game game,
            SpriteBatch spriteBatch,
            string message,
            SpriteFont font,
            Vector2 position,
            Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.message = message;
            this.font = font;
            this.position = position;
            this.color = color;

        }
        /// <summary>
        /// update the game
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// draw the string
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
