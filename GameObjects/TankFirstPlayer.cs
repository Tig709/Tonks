using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class TankFirstPlayer : RotatingSpriteGameObject
    {
        Vector2 wheels;
        Vector2 gun;
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;
        Vector2 accelerationBottom;
        Vector2 positionPrevious;
        int acceleration = 500;
        float turningspeed = 1.57f;

        public TankFirstPlayer() : base("redTankBase")
        {

            startPosition = new Vector2(100, 100);
            accelerationLeft = new Vector2(-10, 0);
            accelerationRight = new Vector2(10, 0);
            accelerationTop = new Vector2(0, -10);
            accelerationBottom = new Vector2(0, 10);
            positionPrevious = new Vector2();


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
            positionPrevious = position;
            base.Update(gameTime);
            WrapScreen();
            DegreeCorrect();

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            velocity = new Vector2(0, 0);
            base.HandleInput(inputHelper);
            Origin = Center;

            //regular movement
            if (inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Down))
            {
                if (Degrees >= 175 && Degrees <= 185)
                {
                    Degrees = 180;
                }
                else
                {
                    if (Degrees >= 0 && Degrees < 180)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Down))
            {
                if (Degrees >= 355 || Degrees <= 5)
                {
                    Degrees = 0;
                }
                else
                {
                    if (Degrees >= 180)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right))
            {
                if (Degrees >= 85 && Degrees <= 95)
                {
                    Degrees = 90;
                }
                else
                {
                    if (Degrees >= 270 || Degrees < 90)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right))
            {
                if (Degrees >= 265 && Degrees <= 275)
                {
                    Degrees = 270;
                }
                else
                {
                    if (Degrees >= 90 && Degrees < 270)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            //diagonal movement
            if (inputHelper.IsKeyDown(Keys.Up) && inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Left))
            {
                if (Degrees >= 310 && Degrees <= 320)
                {
                    Degrees = 315;
                }
                else
                {
                    if (Degrees >= 135 && Degrees < 315)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Up) && inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right))
            {
                if (Degrees >= 220 && Degrees <= 230)
                {
                    Degrees = 225;
                }
                else
                {
                    if (Degrees >= 45 && Degrees < 225)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right))
            {
                if (Degrees >= 130 && Degrees <= 140)
                {
                    Degrees = 135;
                }
                else
                {
                    if (Degrees >= 315 || Degrees < 135)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Left))
            {
                if (Degrees >= 40 && Degrees <= 50)
                {
                    Degrees = 45;
                }
                else
                {
                    if (Degrees >= 225 || Degrees < 45)
                    {
                        Degrees += 6;
                    }
                    else
                    {
                        Degrees -= 6;
                    }
                }
                velocity = AngularDirection * acceleration;
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
        public void WallCorrect()
        {
            WallCorrect(positionPrevious);
        }
        public void WallCorrect(Vector2 position)
        {
            this.position = position;
        }

        public void DegreeCorrect()
        {
            if (Degrees > 360)
                Degrees -= 360;
            if (Degrees < 0)
                Degrees += 360;
        }
    }

    class FirstPlayerShaft : RotatingSpriteGameObject
    {
        Vector2 centerOffset = new Vector2(24, 0);
        public FirstPlayerShaft() : base("redTankShaft")
        {
            origin = Center - centerOffset;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            {
                if (inputHelper.IsKeyDown(Keys.RightShift))
                    Degrees += 2;
                if (inputHelper.IsKeyDown(Keys.RightControl))
                    Degrees -= 2;
            }
        }
    }
}
