using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class TankFirstPlayer : RotatingSpriteGameObject
    {
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;    
        Vector2 accelerationBottom;
        float turningspeed = 1.57f;
       
        public TankFirstPlayer() : base("tankspritesRed")
        {
            startPosition = new Vector2(0,0);   
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
            position.X = MathHelper.Clamp(position.X, 55, GameEnvironment.Screen.X - 60);
            position.Y = MathHelper.Clamp(position.Y, 55, GameEnvironment.Screen.Y - 88);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            Origin = Center;
            if (inputHelper.IsKeyDown(Keys.Left))
            {
                Position += accelerationLeft;
            }
            if (inputHelper.KeyPressed(Keys.M))
            {
                Angle += turningspeed;
            }
            if (inputHelper.KeyPressed(Keys.N))
            {
                Angle -= turningspeed;
            }
            if (inputHelper.IsKeyDown(Keys.Right))
            {
                Position += accelerationRight;
            }
            if (inputHelper.IsKeyDown(Keys.Up))
            {
                Position += accelerationTop;
            }
            if (inputHelper.IsKeyDown(Keys.Down))
            {
                Position += accelerationBottom;
            }
        }
    }
}
