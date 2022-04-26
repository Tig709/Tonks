using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace BaseProject
{

    class Bullet : RotatingSpriteGameObject
    {
        GameObjectList wall;
        int frameCounter;
        Vector2 startPosition;
        Vector2 startSnelheid;
        float turningspeed = 1.57f;
        public Bullet(Vector2 startPosition, Vector2 startSnelheid, GameObjectList wall) : base("tank_bullet")
        {

            origin = Center;
            this.position = startPosition;
            this.startPosition = startPosition;
            this.startSnelheid = startSnelheid;
            this.wall = wall;
            velocity += startSnelheid;

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
        public override void Reset()
        {
            base.Reset();
            this.position.X = -1000;
            this.position.Y = -1000;
            this.velocity.X = 0;
            this.velocity.Y = 0;
            
        }
        public override void Update(GameTime gameTime)
        {
            foreach (UnbreakableWall wall in wall.Children)
            {
                if (this.CollidesWith(wall))
                {
                    if (Position.X < wall.Position.X)
                    {
                        Console.WriteLine("collision1");
                        Velocity *= new Vector2(-1, 1);
                        position.X = wall.Position.X - Width - wall.Width;
                    }
                    if (Position.X > wall.Position.X)
                    {
                        Console.WriteLine("collision2");
                        Velocity *= new Vector2(-1, 1);
                        position.X = wall.Position.X + Width + wall.Width;
                    }
                    /* if (Position.Y > wall.Position.Y)
                     {
                         Console.WriteLine("collision3");
                         Velocity *= new Vector2(1, -1);
                         position.Y = wall.Position.Y - Height - wall.Height;
                     }
                     if (Position.Y < wall.Position.Y)
                     {
                         Console.WriteLine("collision4");
                         Velocity *= new Vector2(1, -1);
                         position.Y = wall.Position.Y + Height + wall.Height;
                     }*/
                }
            }
            base.Update(gameTime);
            WrapScreen();
            frameCounter++; 
          
        }
        public void WrapScreen()
        {
            if (position.X < 0)
            {
                position.X = GameEnvironment.Screen.ToVector2().X;
            }
            else if (position.X > GameEnvironment.Screen.ToVector2().X)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = GameEnvironment.Screen.ToVector2().Y;
            }
            else if (position.Y > GameEnvironment.Screen.ToVector2().Y)
            {
                position.Y = 0;
            }
        }

    }
}