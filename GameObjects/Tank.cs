using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class Tank : GameObjectList
     {
        RotatingSpriteGameObject wheels;
        RotatingSpriteGameObject gun;
        RotatingSpriteGameObject directionArrow;

        GameObjectList bullets;

        // snelle fix, ooit naar soort settings?
        Keys[,] keys = new Keys[10,2] { { Keys.W, Keys.I }, 
                                        { Keys.S, Keys.K }, 
                                        { Keys.A, Keys.J }, 
                                        { Keys.D, Keys.L }, 
                                        { Keys.Q, Keys.U }, 
                                        { Keys.E, Keys.O }, 
                                        { Keys.F, Keys.H }, 
                                        { Keys.R, Keys.Y },
                                        { Keys.Z, Keys.OemPeriod },
                                        { Keys.X, Keys.OemComma } };

        int player;
        bool isFiring;
        float turningSpeed = 0.05f;
        float arrowDistance = 35.0f;
        float acceleration = 0.0f;
        float accelerationStep = 0.25f;
        float accelerationLimit = 3.0f;

        public Tank(int player)
        {
            this.wheels = new RotatingSpriteGameObject("tank_wheels");

            switch (player)
            {
                case 0:
                    this.gun = new RotatingSpriteGameObject("tank_gun1");
                    break;
                case 1:
                    this.gun = new RotatingSpriteGameObject("tank_gun2");
                    break;
            }

            this.directionArrow = new RotatingSpriteGameObject("direction_arrow");
            this.bullets = new GameObjectList();

            this.Add(wheels);
            this.Add(gun);
            this.Add(directionArrow);
            this.Add(bullets);

            wheels.Origin = wheels.Center;
            gun.Origin = gun.Center;
            directionArrow.Origin = directionArrow.Center;
            isFiring = false;
            this.player = player;

            this.Reset();
        }

        public RotatingSpriteGameObject Gun
        {
            get { return this.gun; }
        }

        public int Player
        {
            get { return this.player; }
        }

        public bool IsFiring
        {
            get { return this.isFiring; }
        }

        public override void Reset()
        {
            this.Velocity = Vector2.Zero;
            this.Position = new Vector2(100 * this.player + 150, 150);
            this.gun.Position = this.Position;
            this.wheels.Position = this.Position;

            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;
            wheels.Position = this.Position;
            gun.Position = this.Position;
            directionArrow.Position = this.Position + Vector2.Multiply(wheels.AngularDirection, arrowDistance);
            
            directionArrow.Angle = wheels.Angle;

            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            GamePadCapabilities gamePadCapabilities = GamePad.GetCapabilities(this.player);
            GamePadState state = GamePad.GetState(this.player);

            this.Velocity = Vector2.Zero;
            this.isFiring = false;

            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.DPadUp) || state.ThumbSticks.Left.Y > 0.5f) : inputHelper.IsKeyDown(keys[0, this.player]))
            {
                if (this.acceleration < accelerationLimit)
                    this.acceleration += accelerationStep;
            }
            if (state.IsButtonUp(Buttons.DPadUp))
            {
                if (this.acceleration > 0.00f)
                    this.acceleration -= accelerationStep / 2;
            }

            if (gamePadCapabilities.IsConnected ? state.IsButtonDown(Buttons.A) : inputHelper.IsKeyDown(keys[6, this.player]))
            {
                this.isFiring = true;
            }


            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.DPadDown) || state.ThumbSticks.Left.Y < -0.5f) : inputHelper.IsKeyDown(keys[1, this.player]))
            {
                if (this.acceleration > -accelerationLimit)
                    this.acceleration -= accelerationStep;
            }
            if (state.IsButtonUp(Buttons.DPadDown))
            {
                if (this.acceleration < 0.00f)
                    this.acceleration += accelerationStep / 2;
            }

            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.DPadLeft) || state.ThumbSticks.Left.X < -0.5f) : inputHelper.IsKeyDown(keys[2, this.player]))
            {
                wheels.Angle -= turningSpeed;
            }
            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.DPadRight) || state.ThumbSticks.Left.X > 0.5f) : inputHelper.IsKeyDown(keys[3, this.player]))
            {
                wheels.Angle += turningSpeed;
            }

            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.LeftShoulder)) : inputHelper.IsKeyDown(keys[4, this.player]))
            {
                gun.Angle -= turningSpeed;
            }
            if (gamePadCapabilities.IsConnected ? (state.IsButtonDown(Buttons.RightShoulder)) : inputHelper.IsKeyDown(keys[5, this.player]))
            {
                gun.Angle += turningSpeed;
            }

            this.Velocity += Vector2.Multiply(wheels.AngularDirection, this.acceleration);
        }
    }
}
