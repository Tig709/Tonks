﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
     class Tank : GameObjectList
    {
        Vector2 startPosition;
        Vector2 accelerationLeft;
        Vector2 accelerationRight;
        Vector2 accelerationTop;    
        Vector2 accelerationBottom; 
        SpriteGameObject player1, player2;
        public Tank() 
        {
            player1 = new SpriteGameObject("tankspritesRed");
            player2 = new SpriteGameObject("tanksprites");
            Add(player1);
            Add(player2);
            player1.Position = new Vector2(300, 200);
            player2.Position = new Vector2(50, 100);
            startPosition = GameEnvironment.Screen.ToVector2() / 2;
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


        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.IsKeyDown(Keys.Left))
                player1.Position += accelerationLeft;
            if (inputHelper.IsKeyDown(Keys.Right))
                player1.Position += accelerationRight;
            if (inputHelper.IsKeyDown(Keys.Up))
                player1.Position += accelerationTop;
            if(inputHelper.IsKeyDown(Keys.Down))
                player1.Position += accelerationBottom;
            if (inputHelper.IsKeyDown(Keys.A))
                player2.Position += accelerationLeft;
            if (inputHelper.IsKeyDown(Keys.D))
                player2.Position += accelerationRight;
            if (inputHelper.IsKeyDown(Keys.W))
                player2.Position += accelerationTop;
            if (inputHelper.IsKeyDown(Keys.S))
                player2.Position += accelerationBottom;
        }
    }
}
