using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class ChosenUpgrade : SpriteGameObject
    {
        Vector2 upgradeOffset = new Vector2(67, 67);
        public ChosenUpgrade(string assetnames, Vector2 position) : base(assetnames)
        {
            origin = Center;
            this.position = position + upgradeOffset;
        }
    }
}
