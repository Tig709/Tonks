using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Mine : SpriteGameObject
    {
        int frameCounter;
        Vector2 startPosition;
        
      
        public Mine(string assetNames, Vector2 startPosition) : base(assetNames)
        {
            origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            
         }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
        public override void Reset()
        {
            base.Reset();
         

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
  
            frameCounter++;

        }

    }
}