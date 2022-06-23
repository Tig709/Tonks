using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class WinState1 : SpriteGameObject
    {
        public WinState1() : base("spr_red_wins")
        {

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                Environment.Exit(0);
            //GameEnvironment.GameStateManager.SwitchTo("Begin");

        }
    }
}

