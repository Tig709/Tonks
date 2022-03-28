using BaseProject.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class PlayingState : GameObjectList
    {
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

            firstPlayerTank = new TankFirstPlayer();
            this.Add(firstPlayerTank);

            secondPlayerTank = new TankSecondPlayer();
            this.Add(secondPlayerTank);
            
            walls = new GameObjectList();
            walls2 = new GameObjectList();
            walls3 = new GameObjectList();  
            walls4 = new GameObjectList();
            walls5 = new GameObjectList();
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
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (firstPlayerTank.CollidesWith(secondPlayerTank))
            {
                firstPlayerTank.Reset();
                secondPlayerTank.Reset();
                GameEnvironment.GameStateManager.SwitchTo("Tie");
            }
            foreach (UnbreakableWall wall in walls.Children) 
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                   firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                }
            }
            foreach (UnbreakableWall wall in walls2.Children)
            {
                if (wall.CollidesWith(firstPlayerTank) )
                {
                    firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;
                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                }
            }
            foreach (UnbreakableWall wall in walls3.Children)
            {
                if (wall.CollidesWith(firstPlayerTank) )
                {
                    firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;

                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                }
            }
            foreach (UnbreakableWall wall in walls4.Children)
            {
                if (wall.CollidesWith(firstPlayerTank) )
                {
                    firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;

                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                }
            }
            foreach (UnbreakableWall wall in walls5.Children)
            {
                if (wall.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.Position = firstPlayerTank.Position + wallbounce;

                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.Position = secondPlayerTank.Position + wallbounce2;
                }
            }
        }
    }
    
}
