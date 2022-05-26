using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class ScrollingUpgrade : AnimatedGameObject
    {
        //Vector2 upgradeOffset = new Vector2(67, 67);
        public ScrollingUpgrade(Vector2 position) : base()
        {
            LoadAnimation("scrollingUpgrade@3x1", "upgradeStates", true, 0.10f);
            PlayAnimation("upgradeStates");
            this.position = position;

            //origin = Center;
            
        }
    }
}
