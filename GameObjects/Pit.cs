using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Pit : SpriteGameObject
    {
        Vector2 firstWallPosition;
        Vector2 secondWallPosition;
        public Pit(String assetName, Vector2 position) : base(assetName)
        {
            origin = Center;
            this.Position = position;
    
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
