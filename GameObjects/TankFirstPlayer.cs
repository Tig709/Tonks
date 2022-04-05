﻿using Microsoft.Xna.Framework;
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
        int acceleration = 5;
        float turningspeed = 1.57f;
       
        public TankFirstPlayer() : base("tankspritesRed")
        {
           /* player1 = new SpriteGameObject("tankspritesRed");
            player2 = new SpriteGameObject("tanksprites");
            Add(player1);
            Add(player2);
            player1.Position = new Vector2(300, 200);
            player2.Position = new Vector2(50, 100);*/
            startPosition = new Vector2(0,0); 
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
            position.X = MathHelper.Clamp(position.X, 55, GameEnvironment.Screen.X - 60);
            position.Y = MathHelper.Clamp(position.Y, 55, GameEnvironment.Screen.Y - 88);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            Origin = Center;
            if (inputHelper.IsKeyDown(Keys.Left))
            {
                Degrees -= 6;
            }
           
            if (inputHelper.IsKeyDown(Keys.Right))
            {
                Degrees += 6;
            }
            if (inputHelper.IsKeyDown(Keys.Up))
            {
                this.position += AngularDirection * acceleration;
            }
            if (inputHelper.IsKeyDown(Keys.Down))
            {
                this.position -= AngularDirection * acceleration;
            } 
            if (inputHelper.KeyPressed(Keys.M))
            {
                Angle += turningspeed;
            }
            if (inputHelper.KeyPressed(Keys.N))
            {
                Angle -= turningspeed;
            }
        }
    }
}
