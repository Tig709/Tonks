using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class PlayingState : GameObjectList
    {
        const int PLAYER_COUNT = 2;

        Tank[] tanks = new Tank[PLAYER_COUNT];

        public PlayingState()
        {
            this.Add(new SpriteGameObject("background"));

            for (int i = 0; i < PLAYER_COUNT; i++)
            {
                tanks[i] = new Tank(i);
                this.Add(tanks[i]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
