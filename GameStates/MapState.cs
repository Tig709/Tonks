using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class MapState : GameObjectList
    {
        public MapState()
        {
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Back))
            {
                GameEnvironment.GameStateManager.SwitchTo("Begin");
            }
        }
    }
}
