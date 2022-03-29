using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Upgrades : GameObjectList
    {
        Boolean activated = false;
        int health;
        SpriteGameObject healthUpgrade;
        
        public Upgrades()
        {
            UpgradeEssentials();
        }

        virtual public void UpgradeEssentials()
        {
            healthUpgrade = new SpriteGameObject("tankie");
            this.Add(healthUpgrade);
            healthUpgrade.position = new Vector2(400, 50);
            health = 100;
        }
        
        virtual public void Modifier()
        {
            health = 100 * 2;
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
