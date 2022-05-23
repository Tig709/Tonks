using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Bullet : RotatingSpriteGameObject
    {
        GameObjectList wall;
        int frameCounter;
        Vector2 positionPrevious;
        Vector2 startPosition;
        Vector2 startSnelheid;
        Vector2 positionWall;
        float turningspeed = 1.57f;
        float distanceY, distanceX;
        bool active = false;

        public Bullet(String assetName, Vector2 startPosition, Vector2 startSnelheid) : base(assetName)
        {
            this.wall = wall;
            origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            this.startSnelheid = startSnelheid;
            velocity += startSnelheid;
            AngularDirection = velocity;
            positionPrevious = new Vector2();
            active = true;
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
            active = false;

        }
        public override void Update(GameTime gameTime)
        {
            if (active)
            {
            positionPrevious = position;
            base.Update(gameTime);
            WrapBullet();
            frameCounter++;
            AngularDirection = velocity;
            }
        }
        public void WrapBullet()
        {
            if (position.X < 0 + Width / 2)
            {
                velocity.X *= -1;
                position.X = 0 + Width / 2;
            }
            else if (position.X > GameEnvironment.Screen.X - Width / 2)
            {
                velocity.X *= -1;
                position.X = GameEnvironment.Screen.X - Width / 2;
            }
            if (position.Y < 0)
            {
                velocity.Y *= -1;
                position.Y = 0 + Height / 2;
            }
            else if (position.Y > GameEnvironment.Screen.Y - Height / 2)
            {
                velocity.Y *= -1;
                position.Y = GameEnvironment.Screen.Y - Height / 2;
            }
        }

        public void WrapWallBullet(Vector2 positionWall, int heightWall, int widthWall)
        {
            distanceX = Convert.ToSingle(Math.Sqrt(Math.Pow(position.X - positionWall.X, 2))) / widthWall;
            distanceY = Convert.ToSingle(Math.Sqrt(Math.Pow(position.Y - positionWall.Y, 2))) / heightWall;

            if (position.X - Width / 2 < positionWall.X - widthWall / 2 || position.X + Width / 2 > positionWall.X + widthWall / 2 && distanceX > distanceY)
            {
                velocity.X *= -1;

                if (position.X < positionWall.X)
                {
                    position.X = positionWall.X - widthWall / 2 - Width / 2;
                }
                else
                {
                    position.X = positionWall.X + widthWall / 2 + Width / 2;
                }
            }
            if (position.Y - Height / 2 < positionWall.Y - heightWall / 2 || position.Y + Height / 2 > positionWall.Y + heightWall / 2 && distanceY > distanceX)
            {
                velocity.Y *= -1;

                if (position.Y < positionWall.Y)
                {
                    position.Y = positionWall.Y - heightWall / 2 - Width / 2;
                }
                else
                {
                    position.Y = positionWall.Y + heightWall / 2 + Width / 2;
                }
            }
            if (distanceY == distanceX)
            {
                velocity *= new Vector2(-1, -1);
            }
        }
    }
}