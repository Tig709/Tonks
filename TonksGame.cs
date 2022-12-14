using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//test

namespace BaseProject
{
    public class TonksGame : GameEnvironment
    {
        /*int sec = 0;*/
        protected override void LoadContent()
        {
            base.LoadContent();

            screen = new Point(1920, 1080);
            //this.FullScreen = true;
            ApplyResolutionSettings();

            // TODO: use
            //
            //
            //
            // this.Content to load your game content here
            GameStateManager.AddGameState("Play", new PlayingState());
            GameStateManager.AddGameState("Settings", new SettingsState());
            GameStateManager.AddGameState("Sound", new SoundState());
            GameStateManager.AddGameState("Controls", new ControlState());
            GameStateManager.AddGameState("Begin", new MainState());
            GameStateManager.AddGameState("Tie", new TieState());
            GameStateManager.AddGameState("winState_player_1", new WinState1());
            GameStateManager.AddGameState("winState_player_2", new WinState2());
            GameStateManager.AddGameState("End", new EndOfRoundState());
            GameStateManager.AddGameState("Upgrade", new UpgradeState());
            GameStateManager.SwitchTo("Begin");

        }

    }
}
