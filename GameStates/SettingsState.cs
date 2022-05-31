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
        GameObjectList texts;
        int buttonStandardPositionX = 480;
        int buttonOffScreenPositionX = 4000;
        int optionIndex;

        public SettingsState()
        {
            Add(new SpriteGameObject("settingsBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 320, 0, true));
            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 570, 1, false));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 570, 2, true));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 320, 3, false));

            texts = new GameObjectList();
            this.Add(texts);

            texts.Add(new Text("sound", 0));
            texts.Add(new Text("controls", 1));
            texts.Add(new Text("controlsTransparent", 2));
            texts.Add(new Text("soundTransparent", 3));

            optionIndex = 0;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Down) || inputHelper.KeyPressed(Keys.Up) || inputHelper.KeyPressed(Keys.W) || inputHelper.KeyPressed(Keys.S))
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Button button in buttons.Children)
            {
                foreach (Text text in texts.Children)
                {
                    if (button.buttonIndex == text.textIndex)
                    {
                        text.position = button.position;
                    }
                }
            }
        }
    }
}
