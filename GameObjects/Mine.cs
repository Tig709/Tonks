using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Mine : SpriteGameObject
    {
        public Mine(string assetNames, Vector2 startPosition) : base(assetNames)
        {
            origin = Center;
            this.position = startPosition;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
        public override void Reset()
        {
            base.Reset();
            visible = false;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}