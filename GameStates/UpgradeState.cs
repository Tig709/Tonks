using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class UpgradeState : GameObjectList
    {
        string[] upgradeArray = new string[] { "spr_dash", "spr_double_bullets", "spr_invincibility" };
        GameObject upgradeName;
        AnimatedGameObject scrollingUpgrade;
        Vector2 upgradeOffset = new Vector2(80, 50);
        bool spinnedForUpgrade;
        int spinTimer = 60;
        int index;

        SpriteGameObject upgradeDisplay = new SpriteGameObject("spr_dash");

        public UpgradeState()
        {
            if (PlayingState.firstPlayerTankWon)
                this.Add(new SpriteGameObject("second_player_tank_upgrade"));
            if (PlayingState.secondPlayerTankWon)
                this.Add(new SpriteGameObject("first_player_tank_upgrade"));

            ChosenUpgrade();
            this.Add(new ScrollingUpgrade(new Vector2(GameEnvironment.Screen.X / 2 - upgradeOffset.X, GameEnvironment.Screen.Y / 2 + upgradeOffset.Y)));
        }

        public void Load()
        {
            SpriteGameObject background = new SpriteGameObject("second_player_tank_upgrade");

            if (PlayingState.firstPlayerTankWon)
                background = new SpriteGameObject("second_player_tank_upgrade", -1);
            if (PlayingState.secondPlayerTankWon)
                background = new SpriteGameObject("first_player_tank_upgrade", -1);
            this.Add(background);

            ChosenUpgrade();
        }

        public void ChosenUpgrade()
        {
            Random rnd = new Random();
            index = rnd.Next(upgradeArray.Length);
            upgradeName = new ChosenUpgrade(upgradeArray[index], new Vector2(GameEnvironment.Screen.X / 2 - upgradeOffset.X, GameEnvironment.Screen.Y / 2 + upgradeOffset.Y));
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
            { 
                this.Add(upgradeName);
                spinnedForUpgrade = true;
            }
            if (spinnedForUpgrade)
                spinTimer--;

            if (spinTimer <= 10)
            {
                this.Remove(upgradeName);
            }

            if (spinTimer <= 0 && inputHelper.KeyPressed(Keys.Enter))
            {
                GameEnvironment.GameStateManager.SwitchTo("Play");
                spinnedForUpgrade = false;
                spinTimer = 60;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Console.WriteLine(PlayingState.firstPlayerTankWon);
            //Console.WriteLine(PlayingState.secondPlayerTankWon);
            //Console.WriteLine(dashingP1);            

            if (index == 0)
            {
                if (PlayingState.secondPlayerTankWon)
                    PlayingState.dashingP1 = true;
                if (PlayingState.firstPlayerTankWon)
                    PlayingState.dashingP2 = true;
            }
            if (index == 1)
            {
                if (PlayingState.secondPlayerTankWon)
                    PlayingState.doubleBulletsP1 = true;
                if (PlayingState.firstPlayerTankWon)
                    PlayingState.doubleBulletsP2 = true;
            }

            if (index == 2)
            {
                if (PlayingState.secondPlayerTankWon)
                    PlayingState.invincibilityP1 = true;
                if (PlayingState.firstPlayerTankWon)
                    PlayingState.invincibilityP2 = true;
            }
            //Console.WriteLine(PlayingState.secondPlayerTankWon);


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
