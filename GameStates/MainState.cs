using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class MainState : GameObjectList
    {
        GameObjectList buttons;
        GameObjectList texts;
        public int selectedButton;
        int buttonStandardPositionX = 1450;
        int buttonOffScreenPositionX = 4000;

        public MainState()
        {
            GameEnvironment.AssetManager.mainVolume = 1.0f;

            Add(new SpriteGameObject("mainBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 150, 0, true));
            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 350, 1, false));
            buttons.Add(new Button("buttonSelected", buttonStandardPositionX, buttonOffScreenPositionX, 550, 2, false));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 150, 3, false));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 350, 4, true));
            buttons.Add(new Button("buttonTransparent", buttonStandardPositionX, buttonOffScreenPositionX, 550, 5, true));

            texts = new GameObjectList();
            this.Add(texts);

            texts.Add(new Text("play", 0));
            texts.Add(new Text("settings", 1));
            texts.Add(new Text("exit", 2));
            texts.Add(new Text("playTransparent", 3));
            texts.Add(new Text("settingsTransparent", 4));
            texts.Add(new Text("exitTransparent", 5));

            selectedButton = 0;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter) && selectedButton == 0)
                GameEnvironment.GameStateManager.SwitchTo("Play");

            if (inputHelper.KeyPressed(Keys.Enter) && selectedButton == 1)
                GameEnvironment.GameStateManager.SwitchTo("Settings");

            if (inputHelper.KeyPressed(Keys.Enter) && selectedButton == 2)
                Environment.Exit(0);

            if (inputHelper.KeyPressed(Keys.Down) && selectedButton < 3 || inputHelper.KeyPressed(Keys.S) && selectedButton < 3)
            {
                if (selectedButton < 3)
                    selectedButton++;
                if (selectedButton == 3)
                    selectedButton = 0;
            }
            
            if (inputHelper.KeyPressed(Keys.Up) || inputHelper.KeyPressed(Keys.W))
            {
                if(selectedButton >= 0)
                    selectedButton--;
                if(selectedButton < 0)
                    selectedButton = 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(Button button in buttons.Children)
            {
                if(selectedButton == button.buttonIndex)
                {
                        button.selected = true;
                } else if (button.buttonIndex > 2)
                {
                    if(button.buttonIndex == selectedButton + 3)
                    {
                        button.selected = false;
                    } else
                    {
                        button.selected = true;
                    }
                } else
                    button.selected = false;

                foreach(Text text in texts.Children)
                {
                    if(button.buttonIndex == text.textIndex)
                    {
                        text.position = button.position;
                    }
                }
            }
        }
    }
}
