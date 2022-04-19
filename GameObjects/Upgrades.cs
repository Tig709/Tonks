using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Upgrades : GameObjectList
    {
        public Boolean activated = false;
        int health;
        SpriteGameObject healthUpgrade;
        
        public Upgrades()
        {
            UpgradeEssentials();
        }

        virtual public void UpgradeEssentials()
        {
            healthUpgrade = new SpriteGameObject("HealthUpgrade");
            this.position = new Vector2(100, 50);
            health = 100;
        }
        
        virtual public void Modifier()
        {
            health = 100 * 2;
            this.Add(healthUpgrade);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (activated == true)
            {
                Modifier();
            }
        }
        
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.E))
            {
                activated = true;
            }
        }

    }
}
