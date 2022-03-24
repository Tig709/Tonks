using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class MainState : SpriteGameObject
    {
        public MainState() : base("mainState")
        { 
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}
