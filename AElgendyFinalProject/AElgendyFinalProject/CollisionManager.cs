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
using Microsoft.Xna.Framework.Audio;
using System.IO;
/// <summary>
/// used to manage the collisions
/// </summary>
namespace AElgendyFinalProject
{
    /// <summary>
    /// inherit GameComponent
    /// </summary>
    public class CollisionManager : GameComponent
    {
        // private Bat bat;
        private Player player;
        private SoundEffect hitSound;
        // private Coins myCoins;
        private List<Coins> coinlist = new List<Coins>();
        private List<Bat> myBat = new List<Bat>();

        private SoundEffect coinHit;
        private int score;
        private int coinScore;
        public int Score { get => score; set => score = value; }
        public int CoinScore { get => coinScore; set => coinScore = value; }


        /// <summary>
        /// conustractor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="myBat"></param>
        /// <param name="player"></param>
        /// <param name="hitSound"></param>
        /// <param name="coinlist"></param>
        /// <param name="coinHit"></param>

        public CollisionManager(Game game,
             //Bat bat,
             List<Bat> myBat,
            Player player,
            SoundEffect hitSound,
            //Coins myCoins
            List<Coins> coinlist
            , SoundEffect coinHit) : base(game)
        {
            this.myBat = myBat;
            this.player = player;
            this.hitSound = hitSound;
            this.coinlist = coinlist;
            this.coinHit = coinHit;


        }

        /// <summary>
        /// update the scores
        /// </summary>
        /// <param name="gameTime"></param>

        public override void Update(GameTime gameTime)
        {
            Rectangle playerRect = player.getBounds();
            // Rectangle batRect = bat.getBounds();

            foreach (var item in coinlist)
            {
                Rectangle coinRect = item.getBounds();
                if (playerRect.Intersects(coinRect))
                {
                    item.Speed = new Vector2(item.Speed.X, -Math.Abs(item.Speed.Y));
                    item.position.Y = 0;
                    coinHit.Play();
                    coinScore++;
                }
            }
            foreach (var item in myBat)
            {
                Rectangle coinRect = item.getBounds();
                if (playerRect.Intersects(coinRect))
                {
                    item.Speed = new Vector2(item.Speed.X, -Math.Abs(item.Speed.Y));
                    hitSound.Play();
                    score++;
                }
            }
        }
    }
}
