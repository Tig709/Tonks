using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Bullet : RotatingSpriteGameObject
    {
        int frameCounter;
        Vector2 startPosition;
        Vector2 startSnelheid;
        float turningspeed = 1.57f;
        public Bullet(Vector2 startPosition, Vector2 startSnelheid
            ) : base("bulletRed2_outline")
        {

            origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            this.startSnelheid = startSnelheid;
            velocity += startSnelheid;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
          
        }
        public override void Reset()
        {
            base.Reset();
            this.position.X = -1000;
            this.position.Y = -1000;
            this.velocity.X = 0;
            this.velocity.Y = 0;
            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            WrapScreen();
            frameCounter++; 
          
        }
        public void WrapScreen()
        {
            if (position.X < 0)
            {
                position.X = GameEnvironment.Screen.ToVector2().X;
            }
            else if (position.X > GameEnvironment.Screen.ToVector2().X)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = GameEnvironment.Screen.ToVector2().Y;
            }
            else if (position.Y > GameEnvironment.Screen.ToVector2().Y)
            {
                position.Y = 0;
            }
        }
    }
}