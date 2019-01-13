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
using System.Media;
using Microsoft.Xna.Framework.Audio;
/// <summary>
/// first enemy class
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// Bat inherit DrawableGameComponent
    /// </summary>
    public class Bat :DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Texture2D tex;
        private Vector2 speed;
        private Vector2 stage;
        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 Position { get => position; set => position = value; }
        /// <summary>
        /// class conctructor
        /// </summary>
        /// <param name="game">main game</param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex">the 2d</param>
        /// <param name="position">bat position</param>
        /// <param name="speed">bat speed</param>
        /// <param name="stage"></param>
        public Bat(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage
            ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
        }
        /// <summary>
        /// called when game draw it self
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
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

                speed.Y = -speed.Y;
            }
            //left wall
            if (position.X < 0)
            {
                speed.X = -speed.X;

            }


            base.Update(gameTime);
        }/// <summary>
        /// get the boundry 
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
