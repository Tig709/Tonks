﻿using Microsoft.Xna.Framework;
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
        Vector2 upgradeOffset = new Vector2(65, 55);
        bool spinnedForUpgrade;
        int spinTimer = 240;
        int index;

        SpriteGameObject upgradeDisplay = new SpriteGameObject("spr_dash");

        public UpgradeState()
        {
            if (PlayingState.firstPlayerTankWon)
                this.Add(new SpriteGameObject("second_player_tank_upgrade"));
            if (PlayingState.secondPlayerTankWon)
                this.Add(new SpriteGameObject("first_player_tank_upgrade"));

            ChosenUpgrade();
        }

        public void Load()
        {
            SpriteGameObject background = new SpriteGameObject("second_player_tank_upgrade");

            if (PlayingState.firstPlayerTankWon)
                background = new SpriteGameObject("second_player_tank_upgrade", -1);
            if (PlayingState.secondPlayerTankWon)
                background = new SpriteGameObject("first_player_tank_upgrade", -1);
            this.Add(background);

            scrollingUpgrade = new ScrollingUpgrade(new Vector2(GameEnvironment.Screen.X / 2 - upgradeOffset.X, GameEnvironment.Screen.Y / 2 + upgradeOffset.Y));
            this.Add(scrollingUpgrade);
            
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
            spinTimer--;

            if (spinTimer <= 60)
            { 
                this.Add(upgradeName);
                this.Remove(scrollingUpgrade);
                spinnedForUpgrade = true;
            }
            

            if (spinTimer <= 0 && inputHelper.KeyPressed(Keys.Enter))
            {
                this.Remove(upgradeName);
                PlayingState.invincibilityTimerP1 = 0;
                PlayingState.invincibilityTimerP2 = 0;
                PlayingState.firstPlayerTankWon = false;
                PlayingState.secondPlayerTankWon = false;
                GameEnvironment.GameStateManager.SwitchTo("Play");
                spinnedForUpgrade = false;
                spinTimer = 240;
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
            Console.WriteLine(PlayingState.doubleBulletsP2);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
