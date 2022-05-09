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
        AnimatedGameObject scrollingUpgrade;

        public UpgradeState()
        {
            Random rnd = new Random();
            int index = rnd.Next(upgradeArray.Length);
            upgradeName = new chosenUpgrade(upgradeArray[index], new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2));
            scrollingUpgrade = new AnimatedGameObject();
            scrollingUpgrade.LoadAnimation("scrollingUpgrade@3x1", "upgradeStates", true, 0.10f);

            this.Add(scrollingUpgrade);

            scrollingUpgrade.PlayAnimation("upgradeStates");
            //this.Add(new SpriteGameObject("upgradeState"));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.E))
                this.Add(upgradeName);

            if (inputHelper.KeyPressed(Keys.Enter))
                GameEnvironment.GameStateManager.SwitchTo("Play");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
