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

namespace AElgendyFinalProject
{
    public class GameScore : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private string message;
        private SpriteFont font;
        private Vector2 position;
        private Color color;

        public string Message { get => message; set => message = value; }


        public GameScore(Game game,
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
        /// Allows the game to run logic 
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
