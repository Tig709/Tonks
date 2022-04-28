using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{

    class Button : SpriteGameObject
    {
        Vector2 spawningPosition;
        bool selected;
        string buttonFunction;

        public Button(string spriteName, Vector2 spawningPosition, string buttonFunction) : base(spriteName)
        {
            origin = Center;
            position = spawningPosition;
        }
    }
}
