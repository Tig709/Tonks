using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class TankSecondPlayer : RotatingSpriteGameObject
    {
        float turningspeed = 1.57f;
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;
        Vector2 accelerationBottom;
        int acceleration = 5;
     
        public TankSecondPlayer() : base("tanksprites") 
        {
            startPosition = new Vector2(1820,980);
            accelerationLeft = new Vector2(-10, 0);
            accelerationRight = new Vector2(10, 0);
            accelerationTop = new Vector2(0, -10);
            accelerationBottom = new Vector2(0, 10);

            Reset();
        }
        public override void Reset()
        {
            base.Reset();
            position = startPosition;
            velocity = Vector2.One;

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            WrapScreen();
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            Origin = Center;
            if (inputHelper.IsKeyDown(Keys.A))
                Degrees -= 6;
            if (inputHelper.IsKeyDown(Keys.D))
                Degrees += 6;
            if (inputHelper.IsKeyDown(Keys.W))
                this.position += AngularDirection * acceleration;
            if (inputHelper.IsKeyDown(Keys.S))
                this.position -= AngularDirection * acceleration;
            if (inputHelper.KeyPressed(Keys.E))
            {
                Angle += turningspeed;
            }
            if (inputHelper.KeyPressed(Keys.Q))
            {
                Angle -= turningspeed;
            }
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
