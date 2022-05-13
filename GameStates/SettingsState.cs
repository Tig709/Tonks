using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class SettingsState : GameObjectList
    {
        GameObjectList buttons;
        int buttonStandardPositionX = 480;
        int buttonOffScreenPositionX = 4000;
        int optionIndex;

        public SettingsState()
        {
            Add(new SpriteGameObject("settingsBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 320, 0, true));
            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 550, 1, false));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 550, 2, true));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 320, 3, false));

            optionIndex = 0;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Down) || inputHelper.KeyPressed(Keys.Up))
            {
                if (optionIndex == 0)
                {
                    optionIndex = 1;
                }
                else
                {
                    optionIndex = 0;
                }
                foreach (Button button in buttons.Children)
                {
                    if (button.buttonIndex == optionIndex || button.buttonIndex == optionIndex + 2)
                    {
                        button.selected = true;
                    }
                    else
                    {
                        button.selected = false;
                    }
                }
            }

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                if (optionIndex == 0)
                {
                    GameEnvironment.GameStateManager.SwitchTo("Sound");
                }
                else
                {
                    GameEnvironment.GameStateManager.SwitchTo("Controls");
                }
            }

            if (inputHelper.KeyPressed(Keys.Back))
            {
                GameEnvironment.GameStateManager.SwitchTo("Begin");
            }
        }
    }
}
