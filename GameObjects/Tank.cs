using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class Tank : SpriteGameObject
    {
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;    
        Vector2 accelerationBottom; 
        public Tank() : base("tank_sprites2")
        {
            startPosition = GameEnvironment.Screen.ToVector2() / 2;
            accelerationLeft = new Vector2(-20, 0);
            accelerationRight = new Vector2(20, 0);
            accelerationTop = new Vector2(0, -20);
            accelerationBottom = new Vector2(0, 20);
                
            Reset();
        }
        public override void Reset()
        {
            base.Reset();
            position = startPosition;
            velocity = Vector2.One;
            Origin = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Left))
                position += accelerationLeft;
            if (inputHelper.KeyPressed(Keys.Right))
                position += accelerationRight;
            if (inputHelper.KeyPressed(Keys.Up))
                position += accelerationTop;
            if(inputHelper.KeyPressed(Keys.Down))
                position += accelerationBottom;
        }
    }
}
