using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class ShieldUpgrade : Upgrades
    {
        int ShieldHealth;
        SpriteGameObject shieldUpgrade;
        
        public ShieldUpgrade()
        {
            UpgradeEssentials();
        }

        public override void UpgradeEssentials()
        {
            base.UpgradeEssentials();
            shieldUpgrade = new SpriteGameObject("HealthUpgrade");
            ShieldHealth = 150;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Q))
            {
                activated = true;
            }
        }
    }
}
