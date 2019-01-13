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
/// show help instruction
/// </summary>
namespace AElgendyFinalProject
{   /// <summary>
    /// Class help scene inherit from GameScene
    /// </summary>
    public class HelpScene : GameScene
    {
        /// <summary>
        /// help scene components
        /// </summary>
        
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        public HelpScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("images/Help");

        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}