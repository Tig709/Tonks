
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class PlayingState : GameObjectList
    {
        GameObjectList lives, lives1;
        GameObjectList bullets, bullets2;
        TankFirstPlayer firstPlayerTank;
        TankSecondPlayer secondPlayerTank;
        GameObjectList walls ,walls2, walls3, walls4,walls5;
        Helicopter theHelicopter;
        GameObjectList explosion;
        Vector2 wallbounce, wallbounce2;
        int frameCounter = 0;
        int explosionTimer = 0;
        int healthbarFirst = 100;
        int healthbarSecond = 100;


        public PlayingState()
        {
            wallbounce = new Vector2(-50, 10);
            wallbounce2 = new Vector2(50, 10);

            this.Add(new SpriteGameObject("level_zonder_raster"));
            
            bullets = new GameObjectList();
            this.Add(bullets);

            bullets2 = new GameObjectList();    
            this.Add(bullets2);

            firstPlayerTank = new TankFirstPlayer();
            this.Add(firstPlayerTank);

            secondPlayerTank = new TankSecondPlayer();
            this.Add(secondPlayerTank);

          

            lives = new GameObjectList();
            lives1 = new GameObjectList();
            walls = new GameObjectList();
            walls2 = new GameObjectList();
            walls3 = new GameObjectList();  
            walls4 = new GameObjectList();
            walls5 = new GameObjectList();
            string assetNames = "live_amount";

            for (int iLives = 0; iLives < 6; iLives++)
            {
                lives.Add(new Lives(assetNames, new Vector2(20, 980)));
                lives.Add(new Lives(assetNames, new Vector2(120, 980)));
                lives1.Add(new Lives(assetNames, new Vector2(1800, 980)));
                lives1.Add(new Lives(assetNames, new Vector2(1700, 980)));
            }
         
            
      
            String[] assetName = {"unbreakable_wall"};
            int startXPosition = 200,
                startYPosition = 0,
                nWallsPerRow = 6;
            for (int iWallType = 0; iWallType < assetName.Length; iWallType++)
                for (int iWall = 0; iWall < nWallsPerRow; iWall++)
                {
                    walls2.Add(new UnbreakableWall(assetName[iWallType],
                         new Vector2(startXPosition + iWall, startYPosition + iWallType)));
                    walls.Add(new UnbreakableWall(assetName[iWallType],
                                  new Vector2(startXPosition + iWall+1500, startYPosition + iWallType+800)));
                    walls3.Add(new UnbreakableWall(assetName[iWallType],
                                  new Vector2(startXPosition + iWall + 800, startYPosition + iWallType + 400)));
                    walls4.Add(new UnbreakableWall(assetName[iWallType],
                                  new Vector2(startXPosition + iWall + 1500, startYPosition + iWallType)));
                    walls5.Add(new UnbreakableWall(assetName[iWallType],
                                  new Vector2(startXPosition + iWall, startYPosition + iWallType + 800)));
                }
            this.Add(walls);
            this.Add(walls2);
            this.Add(walls3);
            this.Add(walls4);
            this.Add(walls5);
            this.Add(lives);
            this.Add(lives1);

            theHelicopter = new Helicopter();
            this.Add(theHelicopter);

            explosion = new GameObjectList();
            this.Add(explosion);
         
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                bullets.Add(new Bullet(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y), new Vector2(firstPlayerTank.AngularDirection.X * 500, firstPlayerTank.AngularDirection.Y * 500)));
                ScreenShake();
                
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
            if (inputHelper.KeyPressed(Keys.L))
            {
                bullets2.Add(new Bullet(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y), new Vector2(secondPlayerTank.AngularDirection.X * 500, secondPlayerTank.AngularDirection.Y * 500)));
                ScreenShake();
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
                this.Remove(lives);

                explosion.Add(new Explosion(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y)));
                explosionTimer++;
                explosion.Visible = true;
                healthbarFirst -= 90;
                theHelicopter.Reset();
                ScreenShake();

            }
            if (secondPlayerTank.CollidesWith(theHelicopter))
            {
                this.Remove(lives1);
                explosion.Add(new Explosion(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y)));
                explosionTimer++;
                explosion.Visible = true;
                healthbarSecond -= 90;
                theHelicopter.Reset();
                ScreenShake();
            }

            else if(explosionTimer >= 15 )  
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
            }
            foreach (Bullet bullet in bullets.Children)
            {
               

                if (bullet.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Reset();
                    bullets.Reset();
                    healthbarSecond -= 60;
                    this.Remove(lives1);
                    
                }
            }
            if(healthbarFirst <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("Dead2");
                healthbarFirst = 100;
                healthbarSecond = 100;
            }
            if(healthbarSecond <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("Dead1");
                healthbarSecond = 100;
                healthbarFirst = 100;
            }
            foreach (Bullet bullet in bullets2.Children)
            {
                if (bullet.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.Reset();
                    bullets2.Reset();
                    healthbarFirst -= 60;
                    this.Remove(lives);
                    
                }

            }
            foreach (UnbreakableWall wall in walls.Children) 
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                    }
                    else if (firstPlayerTank.Position.X >= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce2;
                    }
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                    }
                    if (secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce;
                    }
                }
            }
            foreach (UnbreakableWall wall in walls2.Children)
            {
                if (wall.CollidesWith(firstPlayerTank) )
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                    }
                    else if (firstPlayerTank.Position.X >= wall.Position.X) { 
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce2; }
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                    }
                    if (secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce;
                    }
                }
            }
            foreach (UnbreakableWall wall in walls3.Children)
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                    }
                    else if (firstPlayerTank.Position.X >= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce2;
                    }
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                    }
                    if (secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce;
                    }
                }
            }
            foreach (UnbreakableWall wall in walls4.Children)
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                    }
                    else if (firstPlayerTank.Position.X >= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce2;
                    }
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                    }
                    if (secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce;
                    }
                }
            }
            foreach (UnbreakableWall wall in walls5.Children)
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                    }
                    else if (firstPlayerTank.Position.X >= wall.Position.X)
                    {
                        firstPlayerTank.Position = firstPlayerTank.Position + wallbounce2;
                    }
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                    }
                    if (secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.Position = secondPlayerTank.Position + wallbounce;
                    }
                }
            }
        }
        
    }
    
}
