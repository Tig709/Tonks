using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
namespace BaseProject
{
    class TankFirstPlayer : RotatingSpriteGameObject
    {
        SpriteSheet invincibleTank = new SpriteSheet("invincibleRedTank");
        SpriteSheet normalTank = new SpriteSheet("redTankBase");
        Vector2 startPosition;
        Vector2 positionPrevious;
        int acceleration = 75;
        float friction = 0.15f;

        public TankFirstPlayer() : base("redTankBase")
        {
            startPosition = new Vector2(100, 100);
            positionPrevious = new Vector2();
            Reset();
        }

        public void Invincibility()
        {
            sprite = invincibleTank;
        }

        public void InvincibilityExpired()
        {
            sprite = normalTank;
        }

        public override void Reset()
        {
            base.Reset();
            position = startPosition;
        }

        public override void Update(GameTime gameTime)
        {
            velocity -= velocity * friction;
            positionPrevious = position;
            base.Update(gameTime);
            WrapScreen();
            DegreeCorrect();
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            Origin = Center;

            //regular movement
            if (inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Down) && !inputHelper.IsKeyDown(Keys.Right))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Down) && !inputHelper.IsKeyDown(Keys.Left))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Up))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Up) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Down))
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
                velocity += AngularDirection * acceleration;
            }

            //diagonal movement
            if (inputHelper.IsKeyDown(Keys.Up) && inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Down))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Up) && inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Down))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Up))
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
                velocity += AngularDirection * acceleration;
            }

            if (inputHelper.IsKeyDown(Keys.Down) && inputHelper.IsKeyDown(Keys.Right) && !inputHelper.IsKeyDown(Keys.Left) && !inputHelper.IsKeyDown(Keys.Up))
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
                velocity += AngularDirection * acceleration;
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
        SpriteSheet invincibleTankShaft = new SpriteSheet("invincibleRedTankShaft");
        SpriteSheet normalTankShaft = new SpriteSheet("redTankShaft");
        Vector2 centerOffset = new Vector2(24, 0);
        float turningSpeed;
        float turningFriction = 0.28f;
        public FirstPlayerShaft() : base("redTankShaft")
        {
            origin = Center - centerOffset;
        }

        public void Invincibility()
        {
            sprite = invincibleTankShaft;
        }
        public void InvincibilityExpired()
        {
            sprite = normalTankShaft;
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            {
                if (inputHelper.IsKeyDown(Keys.RightShift))
                    turningSpeed += 2;
                if (inputHelper.IsKeyDown(Keys.RightControl))
                    turningSpeed -= 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            turningSpeed -= turningSpeed * turningFriction;
            Degrees += turningSpeed;
        }
    }
}
