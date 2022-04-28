
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
        SpriteGameObject wall, breakableWall, pit;
        Warning theWarning;
        Helicopter theHelicopter;
        GameObjectList explosion;
        GameObjectList score, walls;
        GameObjectList minesPlayer1, minesPlayer2;
        Vector2 wallbounce, wallbounce2, positionPrevious;
        Vector2 minePosition;
        int frameCounter = 0;
        int bulletTimer = 0;
        int explosionTimer = 0;
        int healthbarFirst = 100;
        int healthbarSecond = 100;
        int helipcoterHealth = 1000;
        int wallHealth = 180;
        public static int roundCounter1, roundCounter2;
        string[] assetNamesScore = { "text_0", "text_1", "text_2", "text_3", "text_dots", };
        string[] mineType = { "spr_mine", "spr_mine2" };
        GameObject score1, score2, scoreText;
        


        public static int RoundCounterP1
        {
            get { return roundCounter1; }
            set { RoundCounterP1 = roundCounter1; }
        }
        public static int RoundCounterP2
        {
            get { return roundCounter2; }

            set { RoundCounterP2 = roundCounter2; }
        }


        public PlayingState()
        {

            wallbounce = new Vector2(-50, 10);

            wallbounce2 = new Vector2(50, 10);
            /*positionPrevious = new Vector2();*/

            this.Add(new SpriteGameObject("spr_background"));
           /* wall = new SpriteGameObject("spr_walls");
            this.Add(wall);*/
            breakableWall = new SpriteGameObject("spr_breakable_wall");
            this.Add(breakableWall);
            pit = new SpriteGameObject("spr_pit");
            this.Add(pit);

            upgrade = new Upgrades();
            this.Add(upgrade);

            walls = new GameObjectList();
            this.Add(walls);

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

            

            score1 = new Score(assetNamesScore[roundCounter1], new Vector2(GameEnvironment.Screen.X / 2 - 50, 50));
            scoreText = new Score(assetNamesScore[4], new Vector2(GameEnvironment.Screen.X / 2, 50));
            score2 = new Score(assetNamesScore[roundCounter2], new Vector2(GameEnvironment.Screen.X / 2 + 50, 50));
            this.Add(score1);
            this.Add(scoreText);
            this.Add(score2);
            walls.Add(new UnbreakableWall("unbreakable_wall",new Vector2(265, 128)));
            walls.Add(new UnbreakableWall("unbreakable_wall", new Vector2(1715, 128)));
            walls.Add(new UnbreakableWall("unbreakable_wall", new Vector2(265, 928)));
            walls.Add(new UnbreakableWall("unbreakable_wall", new Vector2(1715, 928)));

            theHelicopter = new Helicopter();
            this.Add(theHelicopter);

            theWarning = new Warning();
            this.Add(theWarning);

            explosion = new GameObjectList();
            this.Add(explosion);
        }



        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.L) && bulletTimer >= 100)
            {
                
                bullets.Add(new Bullet(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y), new Vector2(firstPlayerTank.AngularDirection.X * 500, firstPlayerTank.AngularDirection.Y * 500), walls));
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
                bullets2.Add(new Bullet(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y), new Vector2(secondPlayerTank.AngularDirection.X * 500, secondPlayerTank.AngularDirection.Y * 500), walls));
                ScreenShake();
                bulletTimer = 0;
            }

            if (inputHelper.KeyPressed(Keys.X))
            {
                minePosition = this.firstPlayerTank.position;
                minesPlayer1.Add(new Mine(mineType[0],new Vector2(minePosition.X, minePosition.Y)));
            }
            if (inputHelper.KeyPressed(Keys.B))
            {
                minePosition = this.secondPlayerTank.position;
                minesPlayer2.Add(new Mine(mineType[1],new Vector2(minePosition.X, minePosition.Y)));
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
            theWarning.position.X = theHelicopter.position.X;

            if (theHelicopter.position.Y > 0 - theHelicopter.Height / 2 && theHelicopter.position.Y < GameEnvironment.Screen.Y + theHelicopter.Height / 2)
            {
                Console.WriteLine(theHelicopter.position.Y);
                theWarning.helicopterOnScreen = true;
            } else
            {
                theWarning.helicopterOnScreen = false;
            }

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
                theWarning.helicopterOnScreen = false;
                ScreenShake();

            }
            if (secondPlayerTank.CollidesWith(theHelicopter))
            {

                explosion.Add(new Explosion(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y)));
                explosionTimer++;
                explosion.Visible = true;
                healthbarSecond -= 90;
                theHelicopter.Reset();
                theWarning.helicopterOnScreen = false;
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
            
            foreach (Bullet bullet in bullets.Children)
            {
                
                    if (bullet.CollidesWith(breakableWall))
                    {
                        bullet.Reset();
                        wallHealth -= 60;
                    }
                   
                    if (wallHealth <= 0)
                    {
                        breakableWall.Visible = false;
                    }
                    if (bullet.CollidesWith(secondPlayerTank))
                    {
                        /* secondPlayerTank.Reset();*/
                        bullet.Reset();
                        healthbarSecond -= 60;
                    }

                    foreach (UnbreakableWall wall in walls.Children)
                    {
                        if (bullet.CollidesWith(wall))
                        {
                            bullet.WrapWallBullet(wall.position, wall.Height, wall.Width);
                        }
                    }

                    if (bullet.CollidesWith(theHelicopter))
                    {
                        bullet.Reset();
                        helipcoterHealth -= 60;
                        theHelicopter.Scale -= 0.5f;
                    } else
                    {
                        theHelicopter.Scale = 1;
                    }
               
            }
            foreach (Bullet bullet2 in bullets2.Children)
            {
                if (bullet2.CollidesWith(breakableWall))
                {
                    bullet2.Reset();
                    wallHealth -= 60;
                }
                if (wallHealth <= 0)
                {
                    breakableWall.Visible = false;
                }
                foreach (UnbreakableWall wall in walls.Children)
                {
                    if (bullet2.CollidesWith(wall))
                    {
                        bullet2.WrapWallBullet(wall.position, wall.Height, wall.Width);
                    }
                }
            }

                if (healthbarFirst <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("End");
                this.Remove(score2);
                roundCounter2++;

                score.Add(new Score(assetNamesScore[roundCounter2], new Vector2(GameEnvironment.Screen.X / 2 + 50, 50)));
                this.Add(score);
                healthbarFirst = 100;
                healthbarSecond = 100;
                firstPlayerTank.Reset();
                secondPlayerTank.Reset();
                bullets.Reset();
                bullets2.Reset();
            }
            if (healthbarSecond <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("End");
                this.Remove(score1);
                roundCounter1++;

                score.Add(new Score(assetNamesScore[roundCounter1], new Vector2(GameEnvironment.Screen.X / 2 - 50, 50)));
                this.Add(score);
                healthbarSecond = 100;
                healthbarFirst = 100;
                firstPlayerTank.Reset();
                secondPlayerTank.Reset();
                bullets.Reset();
                bullets2.Reset();
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
                    /*firstPlayerTank.Reset();*/
                    bullet.Reset();
                    healthbarFirst -= 60;


                }
                if (bullet.CollidesWith(theHelicopter))
                {
                    bullet.Reset();
                    helipcoterHealth -= 60;
                    theHelicopter.Scale -= 0.5f;
                }
                else
                {
                    theHelicopter.Scale = 1;
                }

            }


            if (roundCounter2 == 3)
            {
                //MOET NOG GEMAAKT WORDEN : WINSTATE VOOR PLAYER2, SPEL IS OVER ETC.
            }

            if (roundCounter1 == 3)
            {
                //MOET NOG GEMAAKT WORDEN : WINSTATE VOOR PLAYER1, SPEL IS OVER ETC.
            }
            foreach (UnbreakableWall wall in walls.Children)
            {

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
            if (breakableWall.CollidesWith(firstPlayerTank))
            {
                if (firstPlayerTank.Position.X <= breakableWall.Position.X || firstPlayerTank.Position.X >= breakableWall.Position.X)
                {
                    firstPlayerTank.WallCorrect();
                }
            }
            if (breakableWall.CollidesWith(secondPlayerTank))
            {
                if (secondPlayerTank.Position.X <= breakableWall.Position.X || secondPlayerTank.Position.X >= breakableWall.Position.X)
                {
                    secondPlayerTank.WallCorrect();
                }
            }
        
        }

    }
}
    

