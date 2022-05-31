using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class SoundState : GameObjectList
    {
        GameObjectList buttons;
        int volumeLevelIndex;
        public int volume;
        int buttonStandardPositionX = 400;
        int buttonOffScreenPositionX = 4000;
        int soundbarOffset = 400;
        int optionIndex;
        int volumeIndex;

        public SoundState()
        {
            Add(new SpriteGameObject("soundBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("master", buttonStandardPositionX, buttonOffScreenPositionX, 400, 0, true));
            buttons.Add(new Button("masterTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 400, 1, false));
            buttons.Add(new Button("soundBar", buttonStandardPositionX + soundbarOffset, buttonOffScreenPositionX, 400, 2, true));
            buttons.Add(new Button("soundBar", buttonStandardPositionX + soundbarOffset + 40, buttonOffScreenPositionX, 400, 3, true));
            buttons.Add(new Button("soundBar", buttonStandardPositionX + soundbarOffset + 80, buttonOffScreenPositionX, 400, 4, true));
            buttons.Add(new Button("soundBar", buttonStandardPositionX + soundbarOffset + 120, buttonOffScreenPositionX, 400, 5, true));
            buttons.Add(new Button("soundBar", buttonStandardPositionX + soundbarOffset + 160, buttonOffScreenPositionX, 400, 6, true));
            buttons.Add(new Button("soundBarTransparent", buttonStandardPositionX + soundbarOffset, buttonOffScreenPositionX, 400, 7, false));
            buttons.Add(new Button("soundBarTransparent", buttonStandardPositionX + soundbarOffset + 40, buttonOffScreenPositionX, 400, 8, false));
            buttons.Add(new Button("soundBarTransparent", buttonStandardPositionX + soundbarOffset + 80, buttonOffScreenPositionX, 400, 9, false));
            buttons.Add(new Button("soundBarTransparent", buttonStandardPositionX + soundbarOffset + 120, buttonOffScreenPositionX, 400, 10, false));
            buttons.Add(new Button("soundBarTransparent", buttonStandardPositionX + soundbarOffset + 160, buttonOffScreenPositionX, 400, 11, false));

            optionIndex = 0;
            volumeIndex = 5;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if(optionIndex == 0)
            {
                if (inputHelper.KeyPressed(Keys.Left) && volumeIndex > 0 || inputHelper.KeyPressed(Keys.A) && volumeIndex > 0)
                {
                    volumeIndex--;
                }

                if (inputHelper.KeyPressed(Keys.Right) && volumeIndex < 5 || inputHelper.KeyPressed(Keys.D) && volumeIndex < 5)
                {
                    volumeIndex++;
                }

                if (inputHelper.KeyPressed(Keys.Back))
                {
                    GameEnvironment.GameStateManager.SwitchTo("Settings");
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(Button button in buttons.Children)
            {
                if(button.buttonIndex <= volumeIndex + 1 && button.buttonIndex >= 2 && button.buttonIndex <= 6)
                {
                    button.selected = true;
                } else if(button.buttonIndex >= 2 && button.buttonIndex <= 6)
                {
                    button.selected = false;
                }
                if(button.buttonIndex <= volumeIndex + 6 && button.buttonIndex >= 7 && button.buttonIndex <= 12)
                {
                    button.selected = false;
                } else if(button.buttonIndex >= 7 && button.buttonIndex <= 12)
                {
                    button.selected = true;
                }
            }
            GameEnvironment.AssetManager.mainVolume = (float)volumeIndex / 5;
        }
    }
}
