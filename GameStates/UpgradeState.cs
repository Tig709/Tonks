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
        string[] upgradeArray = new string[] { "spr_double_lives", "spr_dash", "spr_invisibility" }; 
        GameObject upgradeName;
        AnimatedGameObject scrollingUpgrade;
        Vector2 upgradeOffset = new Vector2(80, 120);
        
        public static bool dashingP1;
        public static bool dashingP2;

        public UpgradeState()
        {
            ChosenUpgrade();
            stylesheetUpgrade(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2));
        }

        public void ChosenUpgrade()
        {
            Random rnd = new Random();
            int index = rnd.Next(upgradeArray.Length);
            upgradeName = new chosenUpgrade(upgradeArray[index], new Vector2(0, 0));           

        }

        public void stylesheetUpgrade(Vector2 position)
        {
            this.position = position - upgradeOffset;
            scrollingUpgrade = new AnimatedGameObject();
            scrollingUpgrade.LoadAnimation("scrollingUpgrade@3x1", "upgradeStates", true, 0.10f);

            this.Add(scrollingUpgrade);

            scrollingUpgrade.PlayAnimation("upgradeStates");
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter))
                this.Add(upgradeName);


            if (inputHelper.KeyPressed(Keys.E))
               GameEnvironment.GameStateManager.SwitchTo("Play");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Console.WriteLine(PlayingState.firstPlayerTankWon);
            //Console.WriteLine(dashingP1);

            
            //if (index == 0)
            //{
                if (PlayingState.firstPlayerTankWon)
                    dashingP1 = true;
                
                if (PlayingState.secondPlayerTankWon)
                    dashingP2 = true;
            //}
            /*if (index == 1)
            {
                if (PlayingState.firstPlayerTankWon)
                    dashingP1 = true;
                if (PlayingState.secondPlayerTankWon)
                    dashingP2 = true;
            //}

            if (index == 2)
            {
                if (PlayingState.firstPlayerTankWon)
                    dashingP1 = true;
                if (PlayingState.secondPlayerTankWon)
                    dashingP2 = true;
            }*/

            //Console.WriteLine(PlayingState.secondPlayerTankWon);


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
