using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BaseProject
{
    class Bar : SpriteGameObject
    {
        public int barIndex;
        public bool active;
        public int dedicatedObject;
        public Bar(String assetName, int barId, int assignedObject) : base(assetName)
        {
            barIndex = barId;
            dedicatedObject = assignedObject;
        }
    }
}
