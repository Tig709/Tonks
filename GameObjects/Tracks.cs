using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
  class Tracks : RotatingSpriteGameObject
    {
        Vector2 startPosition;
        Vector2 rotation;
        int trackcounter = 0;
        
        public Tracks(Vector2 startPosition, Vector2 rotation) : base("spr_tracks")
        {
            Origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            this.rotation = rotation;
            AngularDirection = rotation;
            visible = true;
        }
        public override void Update(GameTime gameTime)
        {
            trackcounter++;
            base.Update(gameTime);
            if(trackcounter == 100)
            {
                trackcounter = 0;
                visible = false;
            }
        }
        public override void Reset()
        {
            base.Reset();
            visible = false;
        }
    }
}
