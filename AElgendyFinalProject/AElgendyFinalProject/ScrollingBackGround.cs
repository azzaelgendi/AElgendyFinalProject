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
/// <summary>
/// show scrolling back ground
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// ScrollingBackGround inherit DrawableGameComponent
    /// </summary>
    public class ScrollingBackGround : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position1, position2;
        private Vector2 speed;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public ScrollingBackGround(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.speed = speed;
            this.position1 = position;
            this.position2 = new Vector2(position1.X + tex.Width, position1.Y);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// draw the tex
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position1,  Color.White);
            spriteBatch.Draw(tex, position2,  Color.White);//stitch the same image
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// update the position
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            position1 += speed;
            position2 += speed;

            if (position1.X < -tex.Width)
            {
                position1.X = position2.X + tex.Width;
            }
            if (position2.X < -tex.Width)
            {
                position2.X = position1.X + tex.Width;
            }
            base.Update(gameTime);
        }
    }
}
