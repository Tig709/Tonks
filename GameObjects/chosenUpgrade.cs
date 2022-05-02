using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class chosenUpgrade : SpriteGameObject
    {
        public chosenUpgrade(string assetnames, Vector2 position) : base(assetnames)
        {
            this.position = position;
            origin = Center;

        }
    }
}
