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
        int buttonStandardPositionX = 1450;

        public MainState()
        {
            Add(new SpriteGameObject("mainBackground"));

            buttons = new GameObjectList();
            this.Add(buttons);

            buttons.Add(new Button("buttonSelected", new Vector2(buttonStandardPositionX, 100)));
            buttons.Add(new Button("buttonSelected", new Vector2(buttonStandardPositionX, 300)));
            buttons.Add(new Button("buttonSelected", new Vector2(buttonStandardPositionX, 500)));
            buttons.Add(new Button("buttonSelected", new Vector2(buttonStandardPositionX, 700)));
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}
