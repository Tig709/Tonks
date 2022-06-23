using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Score : SpriteGameObject
    {
        public Score(string assetnames, Vector2 position) : base(assetnames)
        {
            this.position = position;
            origin = Center;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
