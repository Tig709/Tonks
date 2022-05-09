using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class MineExplosion : SpriteGameObject
    {
        Vector2 startPosition;
        public MineExplosion(String assetNames) : base(assetNames)
        {
            Origin = Center;
            visible = true;
           
        }

        public override void Reset()
        {
            base.Reset();
         
        }
        public void Detonate(String bombNames, Vector2 explosionPosition)
        {//Zorg dat de methode een positie als argument accepteert
            this.position = explosionPosition; //Zet de positie van het object op de meegegeven positie

            
            visible = true;

        }
    }
}
