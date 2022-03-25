using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class PlayingState : GameObjectList
    {
        TankFirstPlayer firstPlayerTank;
        TankSecondPlayer secondPlayerTank;
       GameObjectList unbreakableWall;
        public PlayingState()
        {
            
            this.Add(new SpriteGameObject("level_zonder_raster"));

            firstPlayerTank = new TankFirstPlayer();
            this.Add(firstPlayerTank);
            secondPlayerTank = new TankSecondPlayer();
            this.Add(secondPlayerTank); 
            unbreakableWall = new GameObjectList();
            String[] assetName = {"unbreakable_wall"};
            int startXPosition = 100,
                startYPosition = 0,
                nWallsPerRow = 3;
            for (int iWallType = 0; iWallType < assetName.Length; iWallType++)
                for (int iWall = 0; iWall < nWallsPerRow; iWall++)
                    unbreakableWall.Add(new UnbreakableWall(assetName[iWallType],
                          new Vector2(startXPosition + iWall, startYPosition + iWallType)));
            this.Add(unbreakableWall);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
