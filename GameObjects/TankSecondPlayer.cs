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
        Vector2 positionPrevious;
        int acceleration = 500;
     
        public TankSecondPlayer() : base("yellowTankBase") 
        {
            startPosition = new Vector2(1820,980);
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
            if (inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.W) && !inputHelper.IsKeyDown(Keys.S))
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

            if (inputHelper.IsKeyDown(Keys.D) && !inputHelper.IsKeyDown(Keys.W) && !inputHelper.IsKeyDown(Keys.S))
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

            if (inputHelper.IsKeyDown(Keys.S) && !inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.D))
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

            if (inputHelper.IsKeyDown(Keys.W) && !inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.D))
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
            if (inputHelper.IsKeyDown(Keys.W) && inputHelper.IsKeyDown(Keys.D) && !inputHelper.IsKeyDown(Keys.A))
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

            if (inputHelper.IsKeyDown(Keys.W) && inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.D))
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

            if (inputHelper.IsKeyDown(Keys.S) && inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.D))
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

            if (inputHelper.IsKeyDown(Keys.S) && inputHelper.IsKeyDown(Keys.D) && !inputHelper.IsKeyDown(Keys.A))
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

    class SecondPlayerShaft : RotatingSpriteGameObject
    {
        Vector2 centerOffset = new Vector2(24, 0);
        public SecondPlayerShaft() : base("yellowTankShaft")
        {
            origin = Center - centerOffset;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            {
                if (inputHelper.IsKeyDown(Keys.E))
                    Degrees += 2;
                if (inputHelper.IsKeyDown(Keys.Q))
                    Degrees -= 2;
            }
        }
    }
}
