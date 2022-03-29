using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Bullet : RotatingSpriteGameObject
    {
       
        public Bullet() : base("bulletRed2_outline")
        {

            origin = new Vector2(position.X + sprite.Width / 2, position.Y + sprite.Height / 2);
            //position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y - 20);
            
            
            this.velocity.Y = -600;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
    }
}