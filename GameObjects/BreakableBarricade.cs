using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
   class BreakableBarricade : SpriteGameObject
    {
        public BreakableBarricade(String assetName, Vector2 position) : base(assetName)
        {
            this.Position = position;
            Origin = Center;
        }
        public override void Reset()
        {
            base.Reset();
            this.Position = new Vector2(-1000,-1000);
        }

    }
}
