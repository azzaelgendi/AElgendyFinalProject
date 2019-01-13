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
/// enable/disable and show/hide each menu component/scenes
/// </summary>
namespace AElgendyFinalProject
{   /// <summary>
    /// inheret DrawableGameComponent
    /// </summary>
    public class GameScene:DrawableGameComponent
    {
        private List<GameComponent> components;
        public List<GameComponent> Components { get => components; set => components = value; }
        /// <summary>
        /// show the scene
        /// </summary>
        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        /// <summary>
        /// hide the scene
        /// </summary>
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        /// <summary>
        /// class conestructor
        /// </summary>
        /// <param name="game"></param>

        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="gameTime"></param>

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
    }
}
