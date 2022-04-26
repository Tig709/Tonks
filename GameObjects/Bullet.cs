using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Bullet : RotatingSpriteGameObject
    {
        SpriteGameObject wall;
        Vector2 positionPrevious;
        int frameCounter;
        Vector2 startPosition;
        Vector2 startSnelheid;
        float turningspeed = 1.57f;
        public Bullet(Vector2 startPosition, Vector2 startSnelheid, SpriteGameObject wall) : base("tank_bullet")
        {
            this.wall = wall;
            origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            this.startSnelheid = startSnelheid;
            velocity += startSnelheid;
            AngularDirection = velocity;

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
            positionPrevious = position;
            WrapBullet();
            frameCounter++;
            AngularDirection = velocity;
        }
        public void WrapBullet()
        {
            if (position.X < 0+Width/2)
            {
                velocity.X *= -1;
            }
            else if (position.X > GameEnvironment.Screen.ToVector2().X-Width/2)
            {
                velocity.X *= -1;
            }
            if (position.Y < 0)
            {
                velocity.Y *= -1;
            }
            else if (position.Y > GameEnvironment.Screen.ToVector2().Y-Height/2)
            {
                velocity.Y *= -1;
            }
        }
        public void WrapBulletWall()
        {
            if (position.X < 0 + Width / 2)
            {
                velocity.X *= -1;
            }
            else if (position.X > wall.Position.X - Width / 2)
            {
                velocity.X *= -1;
            }
            if (position.Y < 0 + Height / 2)
            {
                velocity.Y *= -1;
            }
            else if (position.Y > wall.Position.Y - Height / 2)
            {
                velocity.Y *= -1;
            }
        }
    }
}