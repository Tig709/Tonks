using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Explosion : SpriteGameObject
    {
        Vector2 startPosition;
        const int RESET_VALUE = -1000;
        //set Origin of the sprite on Center
        //give the constructer a variable named stratposition;
        public Explosion(Vector2 startPosition) : base("explosion_heli")
        {
            Origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
        }
        // reset buiten het scherm
        public override void Reset()
        {
            base.Reset();
            this.position.X = RESET_VALUE;
            this.position.Y = RESET_VALUE;
        }
    }
}
