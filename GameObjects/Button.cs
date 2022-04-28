using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{

    class Button : SpriteGameObject
    {
        float spawningPositionY;
        public bool selected;
        public int buttonIndex;
        int buttonStandardPositionX = 1450;
        int buttonOffScreenPositionX = 3000;

        public Button(string spriteName, float spawningPositionY, int buttonIn) : base(spriteName)
        {
            origin = Center;

            buttonIndex = buttonIn;
            if(this.buttonIndex == 0 || this.buttonIndex == 5 || this.buttonIndex == 6 || this.buttonIndex == 7)
            {
                selected = true;
                position = new Vector2(buttonStandardPositionX, spawningPositionY);
            }
            if(this.buttonIndex == 1 || this.buttonIndex == 2 || this.buttonIndex == 3 || this.buttonIndex == 4)
            {
                selected = false;
                position = new Vector2(buttonOffScreenPositionX, spawningPositionY);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (selected)
            {
                position.X = buttonStandardPositionX;
            }
            if (!selected)
            {
                position.X = buttonOffScreenPositionX;
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
