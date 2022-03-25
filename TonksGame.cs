﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//test

namespace BaseProject
{
    public class TonksGame : GameEnvironment
    {
        int sec = 0;
        protected override void LoadContent()
        {
            base.LoadContent();

            screen = new Point(1920, 1080);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
            GameStateManager.AddGameState("Play", new PlayingState());
            GameStateManager.AddGameState("Begin", new MainState());
            GameStateManager.SwitchTo("Begin");
            
        }
        
    }
}