using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class WinState2 : SpriteGameObject
    {
        public WinState2() : base("winState_player_2")
        {

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.P))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}
