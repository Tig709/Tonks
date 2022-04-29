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
            origin = Center;
            this.position.X = GameEnvironment.Random.Next(0 + Width, GameEnvironment.Screen.X - Width);
            this.position.Y = GameEnvironment.Random.Next(-500, -300);
            this.velocity.X = 0;
            this.velocity.Y = 0;
            position = startPosition;
            Reset();
        }
        public override void Reset()
        {
            base.Reset();
            this.position.X = GameEnvironment.Random.Next(0 + Width, GameEnvironment.Screen.X - Width);
            this.position.Y = GameEnvironment.Random.Next(-500, -300);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timer++;
            if (timer == 500)
            {
                velocity.Y = 500;
            }
            if (this.position.Y > GameEnvironment.Screen.Y)
            {
                velocity.Y = 0;
                timer = 0;
                this.position.X = GameEnvironment.Random.Next(0 + Width, GameEnvironment.Screen.X - Width);
                this.position.Y = GameEnvironment.Random.Next(-500, -300);
            }
        }
    }

    class Warning : SpriteGameObject
    {
        int timer;
        int offScreenPositionY, onScreenPositionY;
        public bool helicopterOnScreen;

        public Warning() : base("warning")
        {
            origin = Center;
            helicopterOnScreen = false;
            offScreenPositionY = -500;
            onScreenPositionY = 100;
            position.Y = offScreenPositionY;
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            position.Y = offScreenPositionY;
            timer = -300;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timer++;
            if (!helicopterOnScreen)
            {
                Blink();
            }
            if (helicopterOnScreen)
            {
                position.Y = offScreenPositionY;
            }
        }

        public void Blink()
        {
            if (timer <= 10 && timer >= 0)
            {
                position.Y = offScreenPositionY;
            }
            else if (timer < 20 && timer > 10)
            {
                position.Y = onScreenPositionY;
            }
            if (timer == 20)
            {
                timer = 0;
            }
            if (timer > 20)
            {
                timer = -300;
            }
        }
    }
}
