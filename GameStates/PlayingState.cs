
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using BaseProject;


namespace BaseProject
{
    class PlayingState : GameObjectList
    {
        GameObjectList bullets, bullets2;
        TankFirstPlayer firstPlayerTank;
        FirstPlayerShaft firstPlayerShaft;
        TankSecondPlayer secondPlayerTank;
        SecondPlayerShaft secondPlayerShaft;
        SpriteGameObject breakableWall;
        GameObjectList pit;
        Warning theWarning;
        RotatingSpriteGameObject propeller;
        Helicopter theHelicopter;
        GameObjectList mineExplosion, explosion;
        GameObjectList score, walls;
        GameObjectList minePlayer1, minePlayer2;
        GameObjectList hpBar;
        GameObjectList bulletBar;
        GameObjectList track;
        Vector2 minePosition1, minePosition2;
        Vector2 offset_heli = new Vector2(5, 25);
        int explosionTimer1 = 0;
        int explosionTimer2 = 0;
        int frameCounter = 0;
        int bulletTimer = 100;
        int bulletTimer2 = 100;
        public static int invincibilityTimerP1 = 0;
        public static int invincibilityTimerP2 = 0;
        int dashTimerP1 = 0;
        int dashTimerP2 = 0;
        int explosionTimer = 0;
        int healthbarFirst = 100;
        int totalHealthFirst = 100;
        int healthbarSecond = 100;
        int totalHealthSecond = 100;
        float helicopterHealth = 600;
        float helicopterTotalHealth = 600;
        int wallHealth = 180;
        Boolean explosionDamage1 = true;
        Boolean explosionDamage2 = true;
        Boolean mine1Placed = false;
        Boolean mine2Placed = false;
        Boolean p1Explosion = false;
        Boolean p2Explosion = false;
        public static int roundCounter1, roundCounter2;
        public static bool firstPlayerTankWon, secondPlayerTankWon = false;
        public static bool dashingP1, dashingP2 = false;
        int maxMines1 = 1, maxMines2 = 1;
        string[] assetNamesScore = { "text_0", "text_1", "text_2", "text_3", "text_dots", };
        string[] mineType = { "spr_mine", "spr_mine2" };

        const int BULLET_BAR_OFFSET_X = 50;
        const int BULLET_BAR_OFFSET_Y = 10;
        const int WALL_TO_PIT_DIST = 300;
        const int BULLET_RELOAD_TIME = 100;
        const int SCORE_OFFSET = 50;
        const int MINEDAMAGE = 60;
        const int DOUBLE_BULLETS_OFFSET = 20;

        GameObject score1, score2, scoreText;
        bool wasHelicopterOnScreen;
        bool invincibilityActivatedP1;
        bool invincibilityActivatedP2;
        public static bool doubleBulletsP1;
        public static bool doubleBulletsP2;
        public static bool invincibilityP1;
        public static bool invincibilityP2;

        float soundPanning;
        float volumePan;

        public static int RoundCounterP1
        {
            get { return roundCounter1; }
            set { RoundCounterP1 = roundCounter1; }
        }

        public static int RoundCounterP2
        {
            get { return roundCounter2; }

            set { RoundCounterP2 = roundCounter2; }
        }

        public PlayingState()
        {
            this.Add(new SpriteGameObject("spr_dirt"));

            breakableWall = new SpriteGameObject("spr_breakable_wall");
            this.Add(breakableWall);

            pit = new GameObjectList();
            this.Add(pit);
            pit.Add(new Pit("spr_pit", new Vector2(GameEnvironment.Screen.X / 2 - WALL_TO_PIT_DIST, GameEnvironment.Screen.Y / 2)));
            pit.Add(new Pit("spr_pit", new Vector2(GameEnvironment.Screen.X / 2 + WALL_TO_PIT_DIST, GameEnvironment.Screen.Y / 2)));

            walls = new GameObjectList();
            this.Add(walls);

            hpBar = new GameObjectList();
            this.Add(hpBar);

            bullets = new GameObjectList();
            this.Add(bullets);

            bullets2 = new GameObjectList();
            this.Add(bullets2);

            minePlayer1 = new GameObjectList();
            this.Add(minePlayer1);

            minePlayer2 = new GameObjectList();
            this.Add(minePlayer2);

            track = new GameObjectList();
            this.Add(track);

            firstPlayerTank = new TankFirstPlayer();
            this.Add(firstPlayerTank);

            firstPlayerShaft = new FirstPlayerShaft();
            this.Add(firstPlayerShaft);

            secondPlayerTank = new TankSecondPlayer();
            this.Add(secondPlayerTank);

            secondPlayerShaft = new SecondPlayerShaft();
            this.Add(secondPlayerShaft);

            //shows score on screen
            score = new GameObjectList();
            this.Add(score);
            score1 = new Score(assetNamesScore[roundCounter1], new Vector2(GameEnvironment.Screen.X / 2 - SCORE_OFFSET, SCORE_OFFSET));
            scoreText = new Score(assetNamesScore[4], new Vector2(GameEnvironment.Screen.X / 2, SCORE_OFFSET));
            score2 = new Score(assetNamesScore[roundCounter2], new Vector2(GameEnvironment.Screen.X / 2 + SCORE_OFFSET, SCORE_OFFSET));
            this.Add(score1);
            this.Add(scoreText);
            this.Add(score2);

            //these 2 for-loops give 4 positions where the walls are spawning
            for (int i = 128; i <= 928; i = i + 800)
            {
                for (int j = 265; j <= 1715; j = j + 1450)
                {
                    walls.Add(new UnbreakableWall("unbreakable_wall", new Vector2(j, i)));

                }
            }

            theHelicopter = new Helicopter();
            this.Add(theHelicopter);

            theWarning = new Warning();
            this.Add(theWarning);

            propeller = new RotatingSpriteGameObject("attack_heli_propeller");
            propeller.Origin = propeller.Center;
            this.Add(propeller);
            explosion = new GameObjectList();
            this.Add(explosion);

            mineExplosion = new GameObjectList();
            this.Add(mineExplosion);

            hpBar = new GameObjectList();
            bulletBar = new GameObjectList();

            //each for loop with i inside is used for calculating the length of the bar, the j loop is used for giving the length and position later
            for (int j = 0; j < 5; j++)
            {
                //helicopter hpbar
                for (int i = 0; i < helicopterHealth / 2; i++)
                {
                    hpBar.Add(new Bar("healthBar", i, j));
                }

                //firsplayertank hpbar
                for (int i = 0; i < healthbarFirst; i++)
                {
                    hpBar.Add(new Bar("healthBar", i, j));
                }

                //secondplayertank hpbar
                for (int i = 0; i < healthbarSecond; i++)
                {
                    hpBar.Add(new Bar("healthBar", i, j));
                }

                //firstplayertank bulletbar
                for (int i = 0; i < bulletTimer; i++)
                {
                    bulletBar.Add(new Bar("spr_bulletBar", i, j));
                }

                //secondplayertank bulletbar
                for (int i = 0; i < bulletTimer2; i++)
                {
                    bulletBar.Add(new Bar("spr_bulletBar", i, j));
                }
            }
            this.Add(hpBar);
            this.Add(bulletBar);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.L) && bulletTimer >= BULLET_RELOAD_TIME && doubleBulletsP1)
            {
                bullets.Add(new Bullet("tank_bullet", new Vector2(firstPlayerShaft.Position.X - DOUBLE_BULLETS_OFFSET, firstPlayerShaft.Position.Y - DOUBLE_BULLETS_OFFSET), new Vector2(firstPlayerShaft.AngularDirection.X * 500, firstPlayerShaft.AngularDirection.Y * 500)));
                bullets.Add(new Bullet("tank_bullet", new Vector2(firstPlayerShaft.Position.X + DOUBLE_BULLETS_OFFSET, firstPlayerShaft.Position.Y + DOUBLE_BULLETS_OFFSET), new Vector2(firstPlayerShaft.AngularDirection.X * 500, firstPlayerShaft.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer = 0;
                generateSound("monoShoot", 1.0f, -0.2f, firstPlayerTank.position.X, true);
                bulletBar.Reset();
            }
            if (inputHelper.KeyPressed(Keys.L) && bulletTimer >= BULLET_RELOAD_TIME && !doubleBulletsP1)
            {
                bullets.Add(new Bullet("tank_bullet", new Vector2(firstPlayerShaft.Position.X, firstPlayerShaft.Position.Y), new Vector2(firstPlayerShaft.AngularDirection.X * 500, firstPlayerShaft.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer = 0;
                generateSound("monoShoot", 1.0f, -0.2f, firstPlayerTank.position.X, true);
                bulletBar.Reset();
            }

            else
            {
                if (frameCounter >= 6)
                {
                    velocity.X = 0;
                    position.X = 0;
                    frameCounter = 0;
                }
            }

            
            if (inputHelper.KeyPressed(Keys.Space) && bulletTimer2 >= BULLET_RELOAD_TIME && doubleBulletsP2)
            {
                bullets2.Add(new Bullet("tank_bullet1", new Vector2(secondPlayerShaft.Position.X - DOUBLE_BULLETS_OFFSET, secondPlayerShaft.Position.Y - DOUBLE_BULLETS_OFFSET), new Vector2(secondPlayerShaft.AngularDirection.X * 500, secondPlayerShaft.AngularDirection.Y * 500)));
                bullets2.Add(new Bullet("tank_bullet1", new Vector2(secondPlayerShaft.Position.X + DOUBLE_BULLETS_OFFSET, secondPlayerShaft.Position.Y + DOUBLE_BULLETS_OFFSET), new Vector2(secondPlayerShaft.AngularDirection.X * 500, secondPlayerShaft.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer2 = 0;
                generateSound("monoShoot", 1.0f, -0.2f, secondPlayerTank.position.X, true);
                bulletBar.Reset();
            }

            if (inputHelper.KeyPressed(Keys.Space) && bulletTimer2 >= BULLET_RELOAD_TIME && !doubleBulletsP2)
            {
                bullets2.Add(new Bullet("tank_bullet1", new Vector2(secondPlayerShaft.Position.X, secondPlayerShaft.Position.Y), new Vector2(secondPlayerShaft.AngularDirection.X * 500, secondPlayerShaft.AngularDirection.Y * 500)));
                ScreenShake();
                bulletTimer2 = 0;
                generateSound("monoShoot", 1.0f, -0.2f, secondPlayerTank.position.X, true);
                bulletBar.Reset();
            }

            //If player1 does not have a mine already on the field and presses the mine button a mine will spawn at the position of player1
            if (inputHelper.KeyPressed(Keys.X) && minePlayer1.Children.Count < maxMines1)
            {
                minePosition1 = this.firstPlayerTank.position;
                minePlayer1.Add(new Mine(mineType[0], minePosition1));
                mine1Placed = true;
            }

            //If player2 does not have a mine already on the field and presses the mine button a mine will spawn at the position of player2
            if (inputHelper.KeyPressed(Keys.B) && minePlayer2.Children.Count < maxMines2)
            {
                minePosition2 = this.secondPlayerTank.position;
                minePlayer2.Add(new Mine(mineType[1], minePosition2));
                mine2Placed = true;
            }

            //If player1 has a mine already on the field and presses the explosion button the mine will explode
            if (inputHelper.KeyPressed(Keys.M) && mine1Placed)
            {
                p1Explosion = true;
            }

            //If player2 has a mine already on the field and presses the explosion button the mine will explode
            if (inputHelper.KeyPressed(Keys.N) && mine2Placed)
            {
                p2Explosion = true;
            }

            //Dashing
            if (inputHelper.KeyPressed(Keys.M) && dashingP1 == true && dashTimerP1 <= 0)
            {
                firstPlayerTank.position += firstPlayerTank.AngularDirection * 150;
                foreach (UnbreakableWall wall in walls.Children)
                {
                    if (firstPlayerTank.CollidesWith(wall))
                    {
                        Bounce();
                    }
                }
                dashTimerP1 = 300;
            }


            if (inputHelper.KeyPressed(Keys.N) && dashingP2 == true && dashTimerP2 <= 0) 
            {
                secondPlayerTank.position += secondPlayerTank.AngularDirection * 150;
                foreach (UnbreakableWall wall in walls.Children)
                {
                    if (secondPlayerTank.CollidesWith(wall))
                    {
                        Bounce();
                    }
                }
                dashTimerP2 = 300;
            }

            if (inputHelper.KeyPressed(Keys.P) && invincibilityP1 && invincibilityTimerP1 <= 120 && !invincibilityActivatedP1)
            {
                firstPlayerTank.Invincibility();
                firstPlayerShaft.Invincibility();
                invincibilityActivatedP1 = true;
                //invincibilityTimerP1 = 0; 
            }
            
            if (inputHelper.KeyPressed(Keys.O) && invincibilityP2 && invincibilityTimerP2 <= 120 && !invincibilityActivatedP2)
            {
                secondPlayerTank.Invincibility();
                secondPlayerShaft.Invincibility();
                invincibilityActivatedP2 = true;
                //invincibilityTimerP2 = 0;
            }
        }

        public void Reset()
        {
            firstPlayerTank.Reset();
            secondPlayerTank.Reset();
            bullets.Reset();
            bullets2.Reset();
            minePlayer1.Reset();
            minePlayer2.Reset();
            mineExplosion.Reset();
            explosion.Reset();
            mineExplosion.Visible = false;
            track.Reset();
        }
        public void Bounce()
        {
            firstPlayerTank.position -= firstPlayerTank.AngularDirection * 100;
        }
        public void ScreenShake()
        {
            velocity.X = 1000;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            frameCounter++;
            explosionTimer++;
            bulletTimer++;
            bulletTimer2++;
            dashTimerP1--;
            dashTimerP2--;
            
            if (invincibilityActivatedP1)
            {
                invincibilityTimerP1++;
                if (invincibilityTimerP1 >= 120)
                {
                    firstPlayerTank.InvincibilityExpired();
                    firstPlayerShaft.InvincibilityExpired();
                    invincibilityActivatedP1 = false;
                }
            }

            if (invincibilityActivatedP2)
            {
                invincibilityTimerP2++;
                if (invincibilityTimerP2 >= 120)
                {
                    secondPlayerTank.InvincibilityExpired();
                    secondPlayerShaft.InvincibilityExpired();
                    invincibilityActivatedP2 = false;
                }
            }

            MineDetonate();

            track.Add(new Tracks(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y), new Vector2(firstPlayerTank.AngularDirection.X, firstPlayerTank.AngularDirection.Y)));
            track.Add(new Tracks(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y), new Vector2(secondPlayerTank.AngularDirection.X, secondPlayerTank.AngularDirection.Y)));

            theWarning.position.X = theHelicopter.position.X;

            if (wasHelicopterOnScreen == false && theWarning.helicopterOnScreen == true)
            {
                wasHelicopterOnScreen = true;
                generateSound("helicopterFlyBy", 0.8f, 0, theHelicopter.position.X, true);
            }

            if (wasHelicopterOnScreen == true && theWarning.helicopterOnScreen == false)
                wasHelicopterOnScreen = false;

            if (theHelicopter.position.Y > 0 - theHelicopter.Height / 2 && theHelicopter.position.Y < GameEnvironment.Screen.Y + theHelicopter.Height / 2)
            {
                theWarning.helicopterOnScreen = true;
            }
            else
            {
                theWarning.helicopterOnScreen = false;
            }

            propeller.Degrees += 10;
            propeller.Position = theHelicopter.Position + offset_heli;
            propeller.velocity *= propeller.Degrees;
            if (GameEnvironment.Screen.X > 400)
            {
                velocity.X = -velocity.X;
            }
            if (GameEnvironment.Screen.X < 0)
            {
                velocity.X = +velocity.X;
            }
            //collision helicopter
            if (firstPlayerTank.CollidesWith(theHelicopter))
            {
                explosion.Add(new Explosion(new Vector2(firstPlayerTank.Position.X, firstPlayerTank.Position.Y)));
                healthbarFirst -= 90;
                HelicopterCollision();
            }

            if (secondPlayerTank.CollidesWith(theHelicopter))
            {
                explosion.Add(new Explosion(new Vector2(secondPlayerTank.Position.X, secondPlayerTank.Position.Y)));
                healthbarSecond -= 90;
                HelicopterCollision();
            }

            if (firstPlayerTank.CollidesWith(secondPlayerTank))
            {
                GameEnvironment.GameStateManager.SwitchTo("Tie");
                Reset();
            }

            else if (explosionTimer >= 15)
            {
                explosionTimer = 0;
                explosion.Visible = false;
            }

          
            //collision firstplayer bullets
            foreach (Bullet bullet in bullets.Children)
            {

                if (bullet.CollidesWith(breakableWall))
                {
                    bullet.Reset();
                    wallHealth -= 60;
                }

                if (wallHealth <= 0)
                {
                    breakableWall.Visible = false;
                }
                if (bullet.CollidesWith(secondPlayerTank))
                {
                    bullet.Reset();
                    track.Reset();
                    if (invincibilityActivatedP2 == false || invincibilityTimerP2 >= 120)
                        healthbarSecond -= 60;


                }

                foreach (UnbreakableWall wall in walls.Children)
                {
                    if (bullet.CollidesWith(wall))
                    {
                        bullet.WrapWallBullet(wall.position, wall.Height, wall.Width);
                    }
                }

                if (bullet.CollidesWith(theHelicopter))
                {
                    bullet.Reset();
                    helicopterHealth -= 60;
                    theHelicopter.Scale -= 0.5f;
                }
                else
                {
                    theHelicopter.Scale = 1;
                }

            }
            //collision secondplayer collision
            foreach (Bullet bullet2 in bullets2.Children)
            {
                if (bullet2.CollidesWith(breakableWall))
                {
                    bullet2.Reset();
                    wallHealth -= 60;
                }
                if (wallHealth <= 0)
                {
                    breakableWall.Visible = false;
                }
                foreach (UnbreakableWall wall in walls.Children)
                {
                    if (bullet2.CollidesWith(wall))
                    {
                        bullet2.WrapWallBullet(wall.position, wall.Height, wall.Width);
                    }
                }
                if (bullet2.CollidesWith(firstPlayerTank))
                {
                    bullet2.Reset();
                    track.Reset();
                    if (invincibilityActivatedP1 == false || invincibilityTimerP1 >= 120)
                        healthbarFirst -= 60;
                }
                if (bullet2.CollidesWith(theHelicopter))
                {
                    bullet2.Reset();
                    helicopterHealth -= 60;
                    theHelicopter.Scale -= 0.5f;
                }
                else
                {
                    theHelicopter.Scale = 1;
                }
            }


            //if healthbar of player 1 is zero or lower, player 2 will get 1 point and the game resets
            if (healthbarFirst <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("End");
                this.Remove(score2);
                roundCounter2++;
                secondPlayerTankWon = true;
                score.Add(new Score(assetNamesScore[roundCounter2], new Vector2(GameEnvironment.Screen.X / 2 + 50, 50)));
                this.Add(score);
                healthbarFirst = 100;
                healthbarSecond = 100;
                Reset();

            }
            //if healthbar of player 2 is zero or lower, player 1 will get 1 point and the game resets
            if (healthbarSecond <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("End");
                this.Remove(score1);
                roundCounter1++;
                firstPlayerTankWon = true;
                score.Add(new Score(assetNamesScore[roundCounter1], new Vector2(GameEnvironment.Screen.X / 2 - 50, 50)));
                this.Add(score);
                healthbarSecond = 100;
                healthbarFirst = 100;
                Reset();
            }
            if (helicopterHealth <= 0)
            {
                helicopterHealth = 600;
                theHelicopter.Reset();
            }
            foreach (Bullet bullet in bullets2.Children)
            {
                if (bullet.CollidesWith(firstPlayerTank))
                {
                    /*firstPlayerTank.Reset();*/
                    bullet.Reset();
                    if (invincibilityP2 && invincibilityTimerP2 <= 120)
                        healthbarSecond -= 0;
                    else
                        healthbarSecond -= 60;
                }
            }
            if (roundCounter2 == 3)
            {
                //MOET NOG GEMAAKT WORDEN : WINSTATE VOOR PLAYER2, SPEL IS OVER ETC.
                GameEnvironment.GameStateManager.SwitchTo("winState_player_2");
            }

            if (roundCounter1 == 3)
            {
                GameEnvironment.GameStateManager.SwitchTo("winState_player_1");
            }

            //player 2 wins if score is 3
            if (roundCounter2 == 3)
            {
                GameEnvironment.GameStateManager.SwitchTo("winState_player_2");
            }
            //collision with Unbreakablewalls
            foreach (UnbreakableWall wall in walls.Children)
            {

                if (wall.CollidesWith(firstPlayerTank))
                {
                    if (firstPlayerTank.Position.X <= wall.Position.X || firstPlayerTank.Position.X >= wall.Position.X)
                    {
                        firstPlayerTank.WallCorrect();
                    }

                }
                else if (wall.CollidesWith(secondPlayerTank))
                {
                    if (secondPlayerTank.Position.X >= wall.Position.X || secondPlayerTank.Position.X <= wall.Position.X)
                    {
                        secondPlayerTank.WallCorrect();
                    }

                }
            }
            //collision breakablewall
            if (breakableWall.CollidesWith(firstPlayerTank))
            {
                if (firstPlayerTank.Position.X <= breakableWall.Position.X || firstPlayerTank.Position.X >= breakableWall.Position.X)
                {
                    firstPlayerTank.WallCorrect();
                }
            }
            if (breakableWall.CollidesWith(secondPlayerTank))
            {
                if (secondPlayerTank.Position.X <= breakableWall.Position.X || secondPlayerTank.Position.X >= breakableWall.Position.X)
                {
                    secondPlayerTank.WallCorrect();
                }
            }


            //if tanks collides with pits the shaft will spin and the velocity will be higher
            foreach (Pit pit in pit.Children)
            {

                if (pit.CollidesWith(firstPlayerTank))
                {
                    firstPlayerTank.velocity = firstPlayerTank.velocity * 1.2f;
                    firstPlayerShaft.Angle++;
                }

                if (pit.CollidesWith(secondPlayerTank))
                {
                    secondPlayerTank.velocity = secondPlayerTank.velocity * 1.2f;
                    secondPlayerShaft.Angle++;
                }
            }

            //gives bulletbar a position and length
            foreach (Bar bar in bulletBar.Children)
            {
                if (bar.dedicatedObject == 3)
                {
                    bar.position = new Vector2(10000, 10000);
                    if (bar.barIndex <= bulletTimer)
                    {
                        bar.position = new Vector2(firstPlayerTank.position.X + bar.barIndex - BULLET_BAR_OFFSET_X, firstPlayerTank.position.Y + firstPlayerTank.Height / 2 + BULLET_BAR_OFFSET_Y);
                    }
                }
                if (bar.dedicatedObject == 4)
                {
                    bar.position = new Vector2(10000, 10000);
                    if (bar.barIndex <= bulletTimer2)
                    {
                        bar.position = new Vector2(secondPlayerTank.position.X + bar.barIndex - BULLET_BAR_OFFSET_X, secondPlayerTank.position.Y + secondPlayerTank.Height / 2 + BULLET_BAR_OFFSET_Y);
                    }
                }
            }

            foreach (Bar bar in hpBar.Children)
            {
                if (bar.dedicatedObject == 0)
                {
                    if (bar.barIndex <= helicopterHealth / 2)
                    {
                        bar.position = new Vector2(theHelicopter.position.X - helicopterTotalHealth / 2 + bar.barIndex + theHelicopter.Width / 2, theHelicopter.position.Y + theHelicopter.Height / 2);
                    }
                    else
                    {
                        bar.position = new Vector2(10000, 10000);
                    }
                }

                if (bar.dedicatedObject == 1)
                {
                    if (bar.barIndex <= healthbarFirst)
                    {
                        bar.position = new Vector2(firstPlayerTank.position.X - totalHealthFirst / 2 + bar.barIndex, firstPlayerTank.position.Y + firstPlayerTank.Height / 2);
                    }
                    else
                    {
                        bar.position = new Vector2(10000, 10000);
                    }
                }

                if (bar.dedicatedObject == 2)
                {
                    if (bar.barIndex <= healthbarSecond)
                    {
                        bar.position = new Vector2(secondPlayerTank.position.X - totalHealthSecond / 2 + bar.barIndex, secondPlayerTank.position.Y + secondPlayerTank.Height / 2);
                    }
                    else
                    {
                        bar.position = new Vector2(10000, 10000);
                    }
                }

            }

            firstPlayerShaft.position = firstPlayerTank.position;
            secondPlayerShaft.position = secondPlayerTank.position;
        }
        //sound for shooting and helicopter.
        public void generateSound(string assetName, float volume, float pitch, float positionX, bool stereoPanning)
        {
            if (stereoPanning)
            {
                soundPanning = (positionX - GameEnvironment.Screen.X) / (GameEnvironment.Screen.X);
                volumePan = 1 - (float)Math.Sqrt(Math.Pow(soundPanning, 2));
                GameEnvironment.AssetManager.PlaySound(assetName, volume * volumePan, pitch, 1.0f);
                GameEnvironment.AssetManager.PlaySound(assetName, volume * (1 - volumePan), pitch, -1.0f);
            }
            else
            {
                GameEnvironment.AssetManager.PlaySound(assetName, volume, pitch, 0.0f);
            }
        }
        //mine explosion
        public void MineDetonate()
        {
            //adds explosion sprite if detonated
            if (p1Explosion == true)
            {
                mineExplosion.Add(new Explosion(minePosition1));
                explosionTimer1++;
                explosion.Visible = true;

            }

            //adds explosion sprite if detonated
            if (p2Explosion == true)
            {
                mineExplosion.Add(new Explosion(minePosition2));
                explosionTimer2++;
                explosion.Visible = true;

            }

            //shows explosion sprite for 1 second the resets the explosion and mines
            if (explosionTimer1 >= 60)
            {
                explosionTimer1 = 0;
                mineExplosion.Reset();
                minePlayer1.Reset();
                maxMines1 = maxMines1 + 1;
                explosion.Visible = false;
                p1Explosion = false;
                mine1Placed = false;
                explosionDamage1 = true;
                explosionDamage2 = true;
            }

            //shows explosion sprite for 1 second the resets the explosion and mines
            if (explosionTimer2 >= 60)
            {
                explosionTimer2 = 0;
                mineExplosion.Reset();
                minePlayer2.Reset();
                maxMines2 = maxMines2 + 1;
                explosion.Visible = false;
                p2Explosion = false;
                mine2Placed = false;
                explosionDamage1 = true;
                explosionDamage2 = true;
            }

            //collision between tank and explosion
            foreach (Explosion explosion in mineExplosion.Children)
            {
                if (firstPlayerTank.CollidesWith(explosion) && explosionDamage1) { healthbarFirst = healthbarFirst - MINEDAMAGE; explosionDamage1 = false; }
                if (secondPlayerTank.CollidesWith(explosion) && explosionDamage2) { healthbarSecond = healthbarSecond - MINEDAMAGE; explosionDamage2 = false; }

            }
        }

        public void HelicopterCollision() {
            explosionTimer++;
            explosion.Visible = true;
            theHelicopter.Reset();
            theWarning.helicopterOnScreen = false;
            track.Reset();
            ScreenShake();
        }

    }
}


