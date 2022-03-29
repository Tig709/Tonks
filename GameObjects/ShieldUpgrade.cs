using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.GameObjects
{
    class ShieldUpgrade : Upgrades
    {
        int ShieldHealth;
        public override void UpgradeEssentials()
        {
            base.UpgradeEssentials();
            ShieldHealth = 150;
        }
    }
}
