using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class SettingsState : GameObjectList
    {
        GameObjectList buttons;
        int buttonStandardPositionX = 400;
        int buttonOffScreenPositionX = 4000;
        int optionIndex;

        public SettingsState()
        {
            Add(new SpriteGameObject("settingsBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("sound", buttonStandardPositionX, buttonOffScreenPositionX, 400, 0, true));
            buttons.Add(new Button("controls", buttonStandardPositionX, buttonOffScreenPositionX, 400, 1, false));
            buttons.Add(new Button("soundTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 800, 2, false));
            buttons.Add(new Button("controlsTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 800, 3, true));

            optionIndex = 0;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Down))
            {
                if(optionIndex == 0)
                    optionIndex = 1;
                if (optionIndex == 1)
                    optionIndex = 0;
            }
        }
    }
}
