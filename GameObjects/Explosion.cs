using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class Explosion : SpriteGameObject
    {
        Vector2 startPosition;
        public Explosion(Vector2 startPosition) : base("explosion_heli")
        {
            Origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
        }

        public override void Reset()
        {
            base.Reset();
            this.position.X = -1000;
            this.position.Y = -1000;
        }

    }
}
