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

        public UpgradeState()
        {
            if (PlayingState.firstPlayerTankWon)
                this.Add(new SpriteGameObject("first_player_tank_upgrade"));
            else
                this.Add(new SpriteGameObject("second_player_tank_upgrade"));

            
            
            ChosenUpgrade();
            this.Add(new ScrollingUpgrade(new Vector2(GameEnvironment.Screen.X / 2 - upgradeOffset.X, GameEnvironment.Screen.Y / 2 + upgradeOffset.Y)));
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

            if (inputHelper.KeyPressed(Keys.Enter) && spinnedForUpgrade && spinTimer <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("Play");
                spinnedForUpgrade = false;
            }

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Console.WriteLine(PlayingState.firstPlayerTankWon);
            //Console.WriteLine(dashingP1);
            PlayingState.invincibilityP1 = true;
            PlayingState.invincibilityP2 = true;

            if (index == 0)
            {
                //if (PlayingState.firstPlayerTankWon)
                    PlayingState.dashingP1 = true;
                //if (PlayingState.secondPlayerTankWon)
                    PlayingState.dashingP2 = true;
            }
            if (index == 1)
            {
                //if (PlayingState.firstPlayerTankWon)
                    PlayingState.doubleBulletsP1 = true;
                //if (PlayingState.secondPlayerTankWon)
                    PlayingState.doubleBulletsP2 = true;
            }

            if (index == 2)
            {
                //if (PlayingState.firstPlayerTankWon)
                    PlayingState.invincibilityP1 = true;
                //if (PlayingState.secondPlayerTankWon)
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
