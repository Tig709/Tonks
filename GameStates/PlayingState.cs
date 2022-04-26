﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class PlayingState : GameObjectList
    {

        Upgrades upgrade;
        GameObjectList bullets, bullets2;
        TankFirstPlayer firstPlayerTank;
        TankSecondPlayer secondPlayerTank;
        SpriteGameObject wall;
        Helicopter theHelicopter;
        GameObjectList explosion;
        GameObjectList score;
        GameObjectList minesPlayer1, minesPlayer2;
        Vector2 wallbounce, wallbounce2;
        Vector2 minePosition;
        int frameCounter = 0;
        int bulletTimer = 0;
        int explosionTimer = 0;
        int healthbarFirst = 100;
        int healthbarSecond = 100;
        int helipcoterHealth = 1000;
        public static int roundCounter1, roundCounter2;
        string[] assetNamesScore = { "text_0", "text_1", "text_2", "text_3", "text_dots", };
        GameObject score1, score2, scoreText;

        public static int RoundCounterP1 { get { return roundCounter1; }
            set { RoundCounterP1 = roundCounter1; }
        }
        public static int RoundCounterP2 { get { return roundCounter2; }

            set { RoundCounterP2 = roundCounter2; }
        }

        public PlayingState()
        {

            wallbounce = new Vector2(-50, 10);
            wallbounce2 = new Vector2(50, 10);
            /*positionPrevious = new Vector2();*/

            this.Add(new SpriteGameObject("spr_background"));
            wall = new SpriteGameObject("spr_walls");
            this.Add(wall);

            upgrade = new Upgrades();
            this.Add(upgrade);

            bullets = new GameObjectList();
            this.Add(bullets);

            bullets2 = new GameObjectList();
            this.Add(bullets2);

            minesPlayer1 = new GameObjectList();
            this.Add(minesPlayer1);

            minesPlayer2 = new GameObjectList();
            this.Add(minesPlayer2);

            firstPlayerTank = new TankFirstPlayer();
            this.Add(firstPlayerTank);

            secondPlayerTank = new TankSecondPlayer();
            this.Add(secondPlayerTank);

            score = new GameObjectList();
            this.Add(score);


            this.Add(wall);


            theHelicopter = new Helicopter();
            this.Add(theHelicopter);

            explosion = new GameObjectList();
            this.Add(explosion);
        }



        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if(inputHelper.KeyPressed(Keys.L) && bulletTimer >= 100)
            {
                bullets.Add(new Bullet(new Vector2(firstPlayerTank.Position.X,firstPlayerTank.Position.Y), new Vector2(firstPlayerTank.AngularDirection.X * 500, firstPlayerTank.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer = 0;

            }
            else
            {
                if (frameCounter >= 6)
                {
                    velocity.X = 0;
                    position.X = 0;
                    frameCounter = 0;
                }
            }
            if (inputHelper.KeyPressed(Keys.Space) && bulletTimer >= 100)
            {
                bullets2.Add(new Bullet(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y), new Vector2(secondPlayerTank.AngularDirection.X * 500, secondPlayerTank.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer = 0;
            }

            if (inputHelper.KeyPressed(Keys.X))
            {
                minePosition = this.firstPlayerTank.position;
                minesPlayer1.Add(new Mine(new Vector2(minePosition.X, minePosition.Y)));
            }
            if (inputHelper.KeyPressed(Keys.B))
            {
                minePosition = this.secondPlayerTank.position;
                minesPlayer2.Add(new Mine(new Vector2(minePosition.X, minePosition.Y)));
            }

            else
            {
                if (frameCounter >= 6)
                {
                    velocity.X = 0;
                    position.X = 0;
                    frameCounter = 0;

                }
            }


            upgrade = new Upgrades();
            this.Add(upgrade);

        }
    
        public void ScreenShake()
        {
            velocity.X = 1000;

        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            frameCounter++;
            explosionTimer++;
            bulletTimer++;

            if (GameEnvironment.Screen.X > 400)
            {
                velocity.X = -velocity.X;
            }
            if (GameEnvironment.Screen.X < 0)
            {
                velocity.X = +velocity.X;
            }

            if (firstPlayerTank.CollidesWith(theHelicopter))
            {
                

                explosion.Add(new Explosion(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y)));
                explosionTimer++;
                explosion.Visible = true;
                healthbarFirst -= 90;
                theHelicopter.Reset();
                ScreenShake();

            }
            if (secondPlayerTank.CollidesWith(theHelicopter))
            {
               
                explosion.Add(new Explosion(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y)));
                explosionTimer++;
                explosion.Visible = true;
                healthbarSecond -= 90;
                theHelicopter.Reset();
                ScreenShake();
            }

            else if (explosionTimer >= 15)
            {
                explosionTimer = 0;
                explosion.Reset();
                explosion.Visible = false;
            }

            if (firstPlayerTank.CollidesWith(secondPlayerTank))
            {
                firstPlayerTank.Reset();
                secondPlayerTank.Reset();
                GameEnvironment.GameStateManager.SwitchTo("Tie");
                bullets.Reset();
            }
            foreach (Bullet bullet1 in bullets.Children)
            {
                bullet1.Reset();
                healthbarSecond -= 60;

                if (bullet1.CollidesWith(theHelicopter))
                {
                    bullets.Reset();
                    helipcoterHealth -= 60;
                    theHelicopter.Scale -= 0.5f;
                }
                else
                {
                    theHelicopter.Scale = 1;
                }
            }



            if (helipcoterHealth <= 0)
            {
               
                healthbarSecond = 100;
                healthbarFirst = 100;
            }
            if (helipcoterHealth <= 0)
            {
                helipcoterHealth = 1000;
                theHelicopter.Velocity = new Vector2(0, 0);
                theHelicopter.Reset();
            }
            foreach (Bullet bullet in bullets2.Children)
            {
                if (bullet.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.Reset();
                    bullets2.Reset();
                    healthbarFirst -= 60;
                    


                }
                if (bullet.CollidesWith(theHelicopter))
                {
                    bullets.Reset();
                    helipcoterHealth -= 60;
                    theHelicopter.Scale -= 0.5f;
                }
                else
                {
                    theHelicopter.Scale = 1;
                }

            }

           /* if (healthbarFirst <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("winState_player_1");//dead veranderen naar end of round screen
                healthbarFirst = 100;
                healthbarSecond = 100;
                roundCounter2++;
            }

            if (healthbarSecond <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("winState_player_2");//dead veranderen naar end of round screen
                healthbarSecond = 100;
                healthbarFirst = 100;
                roundCounter1++;
            }*/

            if (roundCounter2 == 3) 
            {
                //MOET NOG GEMAAKT WORDEN : WINSTATE VOOR PLAYER2, SPEL IS OVER ETC.
            }

            if (roundCounter1 == 3)
            {
                //MOET NOG GEMAAKT WORDEN : WINSTATE VOOR PLAYER1, SPEL IS OVER ETC.
            }

            if (wall.CollidesWith(firstPlayerTank))
            {
                if (firstPlayerTank.Position.X <= wall.Position.X || firstPlayerTank.Position.X >= wall.Position.X)
                {

                    firstPlayerTank.WallCorrect();
                }

            }
            else if (wall.CollidesWith(secondPlayerTank))
            {
                if (secondPlayerTank.Position.X >= wall.Position.X || secondPlayerTank.Position.X <= wall.Position.X)
                {
                    secondPlayerTank.WallCorrect();
                }

            }
        }
    }
}




       
    




