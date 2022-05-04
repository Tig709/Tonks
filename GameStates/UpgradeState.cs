using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject { 
    class UpgradeState : GameObjectList
    {
        string[] upgradeArray = new string[] {"spr_double_lives", "spr_dash", "spr_invisibilty"};
        GameObject upgradeName;

        public UpgradeState()
        {
            this.Add(new SpriteGameObject("upgradeState"));
            Random rnd = new Random();
            int index = rnd.Next(upgradeArray.Length);
            upgradeName = new chosenUpgrade(upgradeArray[index], new Vector2(GameEnvironment.Screen.X / 2, 550));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.E))
                this.Add(upgradeName);

            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }
    }
}
