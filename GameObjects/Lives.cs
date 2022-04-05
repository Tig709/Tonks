using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class Lives: SpriteGameObject
    {
        Vector2 firstlivePosition;
        Vector2 secondlivePosition;
        public Lives(String assetNames, Vector2 position) : base(assetNames)
        {
            this.position = position;
            firstlivePosition = new Vector2(0, 1080);
            secondlivePosition = new Vector2(1920, 1080);
        }

    }
}
