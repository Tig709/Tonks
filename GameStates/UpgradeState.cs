using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class UpgradeState : GameObjectList
    {
        string[] upgradeArray = new string[] { "spr_double_lives", "spr_dash", "spr_invisibility" };
        GameObject upgradeName;
        GameObject sheetUpgrade;
        Vector2 upgradeOffset = new Vector2(80, 120);

        public UpgradeState() : base("")
        {
            Random rnd = new Random();
            int index = rnd.Next(upgradeArray.Length);
            upgradeName = new ChosenUpgrade(upgradeArray[index], new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2));
            sheetUpgrade = new StylesheetUpgrade(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2));
            
            this.Add(sheetUpgrade);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                this.Add(upgradeName);

            //if (inputHelper.KeyPressed(Keys.Enter))
            //    GameEnvironment.GameStateManager.SwitchTo("Play");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
