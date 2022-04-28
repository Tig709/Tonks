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

        public MainState()
        {
            Add(new SpriteGameObject("mainBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("buttonSelected", 100, 0));
            buttons.Add(new Button("buttonSelected", 300, 1));
            buttons.Add(new Button("buttonSelected", 500, 2));
            buttons.Add(new Button("buttonSelected", 700, 3));
            buttons.Add(new Button("buttonTransparent", 100, 4));
            buttons.Add(new Button("buttonTransparent", 300, 5));
            buttons.Add(new Button("buttonTransparent", 500, 6));
            buttons.Add(new Button("buttonTransparent", 700, 7));

            texts = new GameObjectList();
            this.Add(texts);

            texts.Add(new Text("play", 0));
            texts.Add(new Text("settings", 1));
            texts.Add(new Text("map", 2));
            texts.Add(new Text("exit", 3));
            texts.Add(new Text("playTransparent", 4));
            texts.Add(new Text("settingsTransparent", 5));
            texts.Add(new Text("mapTransparent", 6));
            texts.Add(new Text("exitTransparent", 7));

            selectedButton = 0;

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter) && selectedButton == 0)
                GameEnvironment.GameStateManager.SwitchTo("Play");

            if (inputHelper.KeyPressed(Keys.Enter) && selectedButton == 3)
                Environment.Exit(0);

            if (inputHelper.KeyPressed(Keys.Down) && selectedButton < 4)
            {
                if (selectedButton < 4)
                    selectedButton++;
                if (selectedButton == 4)
                    selectedButton = 0;
            }
            
            if (inputHelper.KeyPressed(Keys.Up))
            {
                if(selectedButton >= 0)
                    selectedButton--;
                if(selectedButton < 0)
                    selectedButton = 3;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(Button button in buttons.Children)
            {
                Console.WriteLine(button.buttonIndex);
                if(selectedButton == button.buttonIndex)
                {
                        button.selected = true;
                } else if (button.buttonIndex > 3)
                {
                    if(button.buttonIndex == selectedButton + 4)
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
