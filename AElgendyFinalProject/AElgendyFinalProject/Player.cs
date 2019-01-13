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
/// main player class
/// </summary>
namespace AElgendyFinalProject
{   /// <summary>
    /// player inherit DrawableGameComponent
    /// </summary>
    public class Player:DrawableGameComponent
    {
        /// <summary>
        /// decleration
        /// </summary>
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private float rotation = 0f;
        private Rectangle srcRect;
        private Vector2 origin;
        private Vector2 stage;
        private float scale = 1.0f;

        //private float scaleChange = 0.05f;
        private const float MAX_SCALE = 3.0f;
        private const float MIN_SCALE = 0.05f;
        //private float oldValue; 

        public Vector2 Position { get => position; set => position = value; }
        /// <summary>
        /// class constructors
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="stage"></param>
        public Player (Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
        }
        /// <summary>
        /// called to draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, srcRect, Color.White,
                rotation, origin, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// manage the mouse input
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Vector2 target = new Vector2(ms.X, ms.Y);
                float xDiff = target.X - position.X;
                float yDiff = target.Y - position.Y;

                //translation
                position.X += xDiff * speed.X * 0.05f;
                position.Y += yDiff * speed.Y * 0.05f;

                //rotation
                float deviation = 0f;
                if (yDiff < 0 && xDiff > 0)
                {
                    deviation = 0f;
                }
                else if (yDiff > 0 && xDiff > 0)
                {
                    deviation = 0f;
                }
                else if (yDiff > 0 && xDiff < 0)
                {
                    deviation = -(float)Math.PI;
                }
                else if (yDiff < 0 && xDiff < 0)
                {
                    deviation = -(float)Math.PI;
                }
                rotation = deviation + (float)Math.Atan(yDiff / xDiff);


            }

            //float currValue = ms.ScrollWheelValue;
            //if (currValue != oldValue)
            //{
            //    float scaleValue = (currValue - oldValue) / 120;
            //    scale += scaleValue * scaleChange;
            //    if (scale > MAX_SCALE)
            //    {
            //        scale = MAX_SCALE;
            //    }
            //    if (scale < MIN_SCALE)
            //    {
            //        scale = MIN_SCALE;
            //    }


            //    oldValue = currValue;
            //}


            base.Update(gameTime);
        }
        /// <summary>
        /// get the boundry
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
