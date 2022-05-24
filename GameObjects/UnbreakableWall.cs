﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class UnbreakableWall : SpriteGameObject
    {

        // give the constructer a AssetName and a Position for the walls
        public UnbreakableWall(String assetName, Vector2 position) : base(assetName)
        {
            //set originof the sprite on Center
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
            
           
        }

    }
}
