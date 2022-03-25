using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class UnbreakableWall : SpriteGameObject
    {
       Vector2 firstWallPosition;
        Vector2 secondWallPosition;
        public UnbreakableWall(String assetName, Vector2 position) : base(assetName)
        {
            this.Position = position;
            firstWallPosition = new Vector2(100,0);
            secondWallPosition = new Vector2(300,0);
        }
        public override void Reset()
        {
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            /*Position = firstWallPosition;*/
           
        }
    }
}
