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
/// class which show menu on start 
/// </summary>
namespace AElgendyFinalProject
{   /// <summary>
    /// class constructor
    /// inherit gamescene
    /// </summary>
    public class StartScene : GameScene
    {
        /// <summary>
        /// StartScene inherits GameScene
        /// </summary>
        //initalize variable
        private SpriteBatch spriteBatch;
        public MenuComponent Menu { get; set; }

        //menu items
        private string[] menuItems =
        {
            "Start Game",
            "Help",
            "High Score",
            "About",
            "Quit"
        };

        /// <summary>
        /// start scene compnents
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch">draw the class</param>
        public StartScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            //TODO: construct any game components here
            SpriteFont regularFont 
                = game.Content.Load<SpriteFont>("myFonts/regular");
            SpriteFont hilightFont 
                = game.Content.Load<SpriteFont>("myFonts/hilight");

            Menu = new MenuComponent(game
                , spriteBatch
                , regularFont
                , hilightFont
                , menuItems);
            this.Components.Add(Menu);
        }
    }
}
