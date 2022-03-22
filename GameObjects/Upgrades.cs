using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Upgrades : SpriteGameObject
    {
        Boolean activated = false;
        int health = 100;

        public Upgrades() : base("")
        {
            
        }
        void HealthMultiplier()
        {
            health = 200;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (activated == true)
            {
                HealthMultiplier();
            }
        }

    }
}
