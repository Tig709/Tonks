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
        Vector2 centerOffset = new Vector2(-35, 0);
        const int MAX_TRACK_COUNT_AMOUNT = 30;
        //set the Origin of the sprite on Center
        //give the constructer a variable startposition and a rotation
        public Tracks(Vector2 startPosition, Vector2 rotation) : base("spr_tracks")
        {
            Origin = Center - centerOffset;
            this.position = startPosition;
            AngularDirection = rotation;
            visible = true;
        }
        // let the tracks disappear after 100 frames
        public override void Update(GameTime gameTime)
        {
            trackcounter++;
            base.Update(gameTime);

            if (trackcounter == MAX_TRACK_COUNT_AMOUNT)
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
