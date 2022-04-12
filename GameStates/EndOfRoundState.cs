using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class EndOfRoundState : SpriteGameObject
    {
         Vector2 points;
        String textForPoints;
        
        

        public EndOfRoundState() : base("EndOfRoundStateTest")
        {
           
           
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Vector2 points = new Vector2();
        }
        public override void HandleInput(InputHelper inputHelper)
        {

            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}
