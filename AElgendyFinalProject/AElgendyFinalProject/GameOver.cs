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
/// simple class draw texture 2 d
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// inherit DrawableGameComponent
    /// </summary>
    public class GameOver:DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Texture2D tex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex">2d</param>
        /// <param name="position">position</param>

        public GameOver(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
        }
        /// <summary>
        /// draw it self
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
