using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace BaseProject
{

    class Button : SpriteGameObject
    {
        float spawningPositionY;
        public bool selected;
        public int buttonIndex;
        public float standardX;
        public float offScreenX;

        public Button(string spriteName, float buttonStandardPositionX, float buttonOffScreenPositionX, float spawningPositionY, int buttonIn, bool selectedBool) : base(spriteName)
        {
            origin = Center;
            selected = selectedBool;
            buttonIndex = buttonIn;
            if (selected)
            {
                position = new Vector2(buttonStandardPositionX, spawningPositionY);
            }
            else
            {
                position = new Vector2(buttonOffScreenPositionX, spawningPositionY);
            }
            standardX = buttonStandardPositionX;
            offScreenX = buttonOffScreenPositionX;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (selected)
            {
                position.X = standardX;
            }
            if (!selected)
            {
                position.X = offScreenX;
            }
        }
    }

    class Text : SpriteGameObject
    {
        public int textIndex;

        public Text(string spriteName, int textIn) : base(spriteName)
        {
            origin = Center;
            textIndex = textIn;
        }
    }
}
