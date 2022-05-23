using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
  class Tracks : RotatingSpriteGameObject
    {
        Vector2 startPosition;
        public Tracks(Vector2 startPosition) : base("spr_tracks")
        {
            this.startPosition = startPosition; 
        }
    }
}
