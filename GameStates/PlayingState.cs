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
       GameObjectList unbreakableWall;
        GameObjectList bullets;
        public PlayingState()
        {
            
            this.Add(new SpriteGameObject("level_zonder_raster"));


            bullets = new GameObjectList();
            this.Add(bullets);

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
            bullets.Position = firstPlayerTank.Position;

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
                bullets.Add(new Bullet());
        }
    }
}
