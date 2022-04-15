﻿using BaseProject.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class EndOfRoundState : GameObjectList
    {
        GameObjectList score;
        int roundCounter1, roundCounter2;
        string[] assetNamesScore = { "text_0", "text_1", "text_2", "text_3", "text_dots" };
        GameObject score1, score2, scoreText;

        

        public EndOfRoundState(){

            this.Add(new SpriteGameObject("EndOfRoundStateTest"));

            score = new GameObjectList();
            this.Add(score);

            score1 = new Score(assetNamesScore[roundCounter1], new Vector2(GameEnvironment.Screen.X / 2 - 50, 50));
            scoreText = new Score(assetNamesScore[4], new Vector2(GameEnvironment.Screen.X / 2, 50));
            score2 = new Score(assetNamesScore[roundCounter2], new Vector2(GameEnvironment.Screen.X / 2 + 50, 50));

        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            
        }
        public override void HandleInput(InputHelper inputHelper)
        {

            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}