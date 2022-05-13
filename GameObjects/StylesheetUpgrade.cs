using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class StylesheetUpgrade : AnimatedGameObject
    {
        AnimatedGameObject scrollingUpgrade;

        //Vector2 upgradeOffset = new Vector2(67, 67);
        public StylesheetUpgrade(Vector2 position) : base()
        {
            this.position = position;
            LoadAnimation("scrollingUpgrade@3x1", "upgradeStates", true, 0.10f);
            PlayAnimation("upgradeStates");

            origin = Center;
        }
    }
}
