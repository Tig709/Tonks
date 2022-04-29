using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class Helicopter : SpriteGameObject
    {
        int timer;
        Vector2 startPosition;
        public Helicopter() : base("attack_heli")
        {

            this.position.X = GameEnvironment.Random.Next(0,GameEnvironment.Screen.X);
            this.position.Y = GameEnvironment.Random.Next(-500,-300);
            this.velocity.X = 0;
            this.velocity.Y = 0;
            position = startPosition;
            Reset();
        }
        public override void Reset()
        {
            base.Reset();
            this.position.X = GameEnvironment.Random.Next(0, GameEnvironment.Screen.X);
            this.position.Y = GameEnvironment.Random.Next(-500, -300);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timer++;
            if(timer == 500)
            {
                velocity.Y = 500;
            }
            if (this.position.Y > GameEnvironment.Screen.Y)
            {
                velocity.Y = 0;
                timer = 0;
                this.position.X = GameEnvironment.Random.Next(0, GameEnvironment.Screen.X);
                this.position.Y = GameEnvironment.Random.Next(-500, -300);
            }
        }
    }
}
