using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Upgrades : SpriteGameObject
    {
        Boolean activated = false;
        int health;
        Vector2 imagePos;

        public Upgrades() : base("tankie")
        {
            imagePos = new Vector2(400, 50);
            health = 100;
        }
        void HealthMultiplier()
        {
            health = 200;
            position = imagePos;
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (activated == true)
            {
                HealthMultiplier();
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
