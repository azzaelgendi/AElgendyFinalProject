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
/// used this class for my animations
/// </summary>
namespace AElgendyFinalProject
{   /// <summary>
    // 
    /// bluebirs class inherit DrawableGameComponent
    /// </summary>
    public class BlueBird : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position1,position2,position3;
        private Vector2 dimension;
        private List<Rectangle> frames;//continous crop
        private int frameIndex = -1;
        private int delay;
        private int delayCounter;
        Vector2 speed;

        /// <summary>
        /// class constractor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex">2 d</param>
        /// <param name="position">position</param>
        /// <param name="speed">speed</param>
        /// <param name="delay">delay the frames</param>
        
        public BlueBird(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,

            int delay
            ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.delay = delay;
            this.dimension = new Vector2(107, 105);//willbe used in the loops
            this.speed = speed;
            this.position1 = position;
            this.position2 = new Vector2(position1.X + tex.Width, position1.Y);
            this.position3 = new Vector2( position2.X + tex.Width,  position2.Y);
            //creates the frames here 
            createFrames();
        }
        /// <summary>
        /// crop the photo and create the frames
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }
        /// <summary>
        /// draw the frames
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //v4
            if (frameIndex >= 0)
            {
                spriteBatch.Draw(tex, position1, frames[frameIndex], Color.White);
                spriteBatch.Draw(tex, position2, frames[frameIndex], Color.White);
                spriteBatch.Draw(tex, position3, frames[frameIndex], Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// update the position and repeat the frames
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {//claculate our frame index
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > 8)
                {
                    frameIndex = -1;

                }
                delayCounter = 0;
            }


            position1 += speed;
            position2 += speed;
            position3 += speed;

            if (position1.X < Shared.stage.X)
            {
                position1.X = Shared.stage.X;
            }
            if (position2.X < -tex.Width)
            {
                position2.X = position1.X + tex.Width;
            }


            base.Update(gameTime);
        }
    }
}
