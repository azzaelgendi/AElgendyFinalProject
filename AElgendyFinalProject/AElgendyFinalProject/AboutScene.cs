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
/// this class inherit the game scene 
/// </summary>
namespace AElgendyFinalProject
{/// <summary>
/// Class constructor for about Scene 
/// which show creator's Name
/// </summary>
    public class AboutScene : GameScene
    {   /// <summary>
        /// about sence component
        /// </summary>
        //class variables
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public AboutScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("images/about");

        }
        /// <summary>
        /// Draw the 2D photo
        /// called when the game want to draw it self
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
