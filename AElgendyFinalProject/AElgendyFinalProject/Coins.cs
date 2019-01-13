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
using Microsoft.Xna.Framework.Audio;
/// <summary>
/// animated coins class
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// |Coins component of the action scenes 
    /// </summary>
    public class Coins:DrawableGameComponent
    {
        /// <summary>
        /// decleration
        /// </summary>
        private SpriteBatch spriteBatch;
        public Vector2 position;
        private Texture2D tex;
        private Vector2 speed;
        private Vector2 dimension;
        private List<Rectangle> frames;//continous crop
        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        public Vector2 Speed { get => speed; set => speed = value; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex">texture 2d</param>
        /// <param name="position">position</param>
        /// <param name="speed">speed</param>
        /// <param name="delay">delay the frames</param>
        public Coins(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            int delay
                    ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.delay = delay;
            this.dimension = new Vector2(30, 30);//willbe used in the loops
            //creates the frames here 
            createFrames();
        }
        /// <summary>
        /// crop the image create frames
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
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
            //v2
            if (frameIndex >= 0)
            {
                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// update the position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            position += speed;
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > 11)
                {
                    frameIndex = -1;

                }
                delayCounter = 0;
            }
            //top wall
            if (position.Y < 0)
            {
                speed.Y = -speed.Y;

            }
            //right wall
            if (position.X + tex.Width > Shared.stage.X)
            {
                speed.X = -speed.X;

            }
            //bottom wall
            if (position.Y + tex.Height > Shared.stage.Y)
            {
                position.Y = 0;
                speed.Y = -speed.Y;//falling from the sky
                
               
            }
            //left wall
            if (position.X < 0)
            {
                speed.X = -speed.X;

            }


            base.Update(gameTime);
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
