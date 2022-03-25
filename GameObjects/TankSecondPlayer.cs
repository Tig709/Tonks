using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class TankSecondPlayer : SpriteGameObject
    {
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;
        Vector2 accelerationBottom;
        public TankSecondPlayer() : base("tanksprites") 
        {
            startPosition = GameEnvironment.Screen.ToVector2() / 2;
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
            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - 50);
            position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y - 50);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyDown(Keys.A))
                Position += accelerationLeft;
            if (inputHelper.IsKeyDown(Keys.D))
                Position += accelerationRight;
            if (inputHelper.IsKeyDown(Keys.W))
               Position += accelerationTop;
            if (inputHelper.IsKeyDown(Keys.S))
                Position += accelerationBottom;
        }

        }
}
