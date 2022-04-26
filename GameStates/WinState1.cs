using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
   class WinState1 : SpriteGameObject
    {
        public WinState1() : base("winState_player_1")
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

