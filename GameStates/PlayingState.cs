using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
 class PlayingState : GameObjectList
    {
        Tank tank;

        public PlayingState()
        {
            this.Add(new SpriteGameObject("background"));

            tank = new Tank();
            this.Add(tank);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
