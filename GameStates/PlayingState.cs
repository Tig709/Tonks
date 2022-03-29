
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
        Vector2 wallbounce, wallbounce2;
        

 
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
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                bullets.Add(new Bullet());
                bullets.Position = firstPlayerTank.Position;
            }
            if (inputHelper.KeyPressed(Keys.L))
            {
                bullets2.Add(new Bullet());
                bullets2.Position = secondPlayerTank.Position;
            }




            if (inputHelper.KeyPressed(Keys.Tab))
            {
                velocity.X = 200;
            }
        }

        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(GameEnvironment.Screen.X > 400)
            {
                velocity.X = -velocity.X;
            }
            if (GameEnvironment.Screen.X < 0)
            {
                velocity.X = +velocity.X;
            }

            

            if (firstPlayerTank.CollidesWith(secondPlayerTank))
            {
                firstPlayerTank.Reset();
                secondPlayerTank.Reset();
                GameEnvironment.GameStateManager.SwitchTo("Tie");
            }
            foreach(Bullet bullet in bullets.Children)
            {
               

                if (bullet.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Reset();
                    this.Remove(lives1); 
                }
            }
            foreach (Bullet bullet in bullets2.Children)
            {
                if (bullet.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.Reset();
                    this.Remove(lives);
                }
                else if (bullet.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.Reset();
                    GameEnvironment.GameStateManager.SwitchTo("Dead");
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
