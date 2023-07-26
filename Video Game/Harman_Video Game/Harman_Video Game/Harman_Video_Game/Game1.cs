/*
Name: Harmanpreet Singh Sagar
Assignment: Video Game Project
Class: ICS 4U1
Date: 02 November 2021
Purpose: To create a fun video game that can be enjoyed by all playing the game.
NOTE: Parts of the code relating to the creation of the platforms have bbueen left inside the code but have been commented. They have been commented in order to showcase the effort put in to solving the hit test between the platforms and the player. However, due to the lack of time, the code was unresolved and thus needed to be removed. Therefore, in this game, the platforms are not visible, but the code that tried to make the hit tests between the player and the platforms has been left in there for reference. Furthermore, I intended to play a background music, however, when I was adding the background sound into the game, the game was lagging severely. Thus, I was forced into removing the background music altogether from my game.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Harman_Video_Game.Classes;

namespace Harman_Video_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //-----------------------------------------------------------------------------------------------
        // DECLARES RECTANGLES

        // Declares a Rectangle variable screenRect.
        Rectangle screenRect;
        // Declares a Rectangle variable soldierRect.
        Rectangle soldierRect;
        // Declares a Rectangle variable enemyRect.
        Rectangle enemyRect;
        // Declares a Rectangle variable soldierProjectileRect.
        Rectangle soldierProjectileRect;
        // Declares a Rectangle variable enemyProjectileRect.
        Rectangle enemyProjectileRect;
        // Declares a Rectangle variable soldierHealthBar.
        Rectangle soldierHealthBar;
        // Declares a Rectangle variable enemyHealthBar.
        Rectangle enemyHealthBar;
        // Declares a Rectangle array variable platformRect.
        //Rectangle[] platformRect = new Rectangle[8];

        //-----------------------------------------------------------------------------------------------
        // DECLARES TEXTURES

        // Declares a Texture2D variable backgroundPic.
        Texture2D backgroundPic;
        // Declares a Texture2D variable soldierStraightGun.
        Texture2D soldierStraightGun;
        // Declares a Texture2D variable soldierLeft.
        Texture2D soldierLeft;
        // Declares a Texture2D variable soldierRight.
        Texture2D soldierRight;
        // Declares a Texture2D variable enemyPic.
        Texture2D enemyPic;
        // Declares a Texture2D variable oneByOnePixel.
        Texture2D oneByOnePixel;
        // Declares a Texture2D variable bulletRight.
        Texture2D bulletRight;
        // Declares a Texture2D variable bulletLeft.
        Texture2D bulletLeft;
        // Declares a Texture2D variable instructions.
        Texture2D instructions;
        // Declares a Texture2D variable playerWinnerScreen.
        Texture2D playerWinnerScreen;
        // Declares a Texture2D variable enemyWinnerScreen.
        Texture2D enemyWinnerScreen;
        // Declares a Texture2D variable gameTiedScreen.
        Texture2D gameTiedScreen;

        //-----------------------------------------------------------------------------------------------
        // DECLARES SOUND EFFECTS

        // Declares a soundEffect variable walkingSound.
        SoundEffect walkingSound;
        // Declares a soundEffect variable gunshot.
        SoundEffect gunshot;

        //-----------------------------------------------------------------------------------------------
        // DECLARES GAME VARIABLES

        // Declares a GameItem variable game.
        GameItem game;
        // Declares a GamePadState variable pad1.
        GamePadState pad1;
        // Declares a GamePadState variable oldPad1.
        GamePadState oldPad1;
        // Declares a KeyboardState variable kb.
        KeyboardState kb;
        // Declares a KeyboardState variable oldKb.
        KeyboardState oldKb;
        // Declares a Platforms array variable platforms
        //Platforms[] platforms;
        // Declares a Player variable soldier.
        Player soldier;
        // Declares an Enemy variable enemy.
        Enemy enemy;
        // Declares a bool variable charLandStatus.
        // bool charLandStatus;
        // Declares a Projectile List playerBullet.
        List <Projectile> playerBullet;
        // Declares a Projectile List enemyBullet.
        List<Projectile> enemyBullet;
        // Declares a SpriteFont variable spriteFont1.
        SpriteFont spriteFont1;

        // Creates int arrays for the x and y positions and width of the platform.
        //int[] platformX = new int[] { 0, 490, 315, 0, 529, 60, 329, 90 };
        //int[] platformY = new int[] { 90, 90, 195, 265, 315, 365, 440, 450 };
        //int[] platformX = new int[] { 90, 329, 60, 529, 0, 315, 490, 0 };
        //int[] platformY = new int[] { 450, 450, 365, 315, 265, 195, 90, 90 };
        /*int[] platformX = new int[] { 70, 0, 530, 230, 30, 600, 100, 600 };
        int[] platformY = new int[] { 90, 150, 150, 230, 320, 330, 400, 450 };
        int[] platformWidth = new int[] { 400, 250, 70, 250, 150, 70, 400, 70 };*/

        // Creates a int variable playerTimeDelay for counting the number of ticks between each player bullet shot.
        int playerTimeDelay = 0;
        // Creates a int variable healthBarTimeDelay for counting the number of ticks between each decrease of health bar when player is hitting the enemy.
        int healthBarTimeDelay = 0;
        // Creates a int variable enemyTimeDelay for counting the number of ticks between each player enemy shot.
        int enemyTimeDelay = 0;

        // Declares a bool variable gameStart to check whether the game has started and set default value to false.
        bool gameStart = false;
        // Declares a bool variable gameEnd to check whether the game has started and set default value to false.
        bool gameEnd = false;
        // Declares a bool variable playerWins to check whether the game has started and set default value to false.
        bool playerWins = false;
        // Declares a bool variable enemyWins to check whether the game has started and set default value to false.
        bool enemyWins = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initializes the screenRect by setting the position, width and height of the rectangle.
            screenRect = new Rectangle(0, 0, 800, 480);
            // Initializes the soldierRect by setting the position, width and height of the rectangle.
            soldierRect = new Rectangle(0, 330, 100, 150);
            // Initializes the enemyRect by setting the position, width and height of the rectangle.
            enemyRect = new Rectangle(700, 330, 100, 150);
            // Initializes the soldierProjectileRect by setting the position, width and height of the rectangle.
            soldierProjectileRect = new Rectangle(soldierRect.X + soldierRect.Width, soldierRect.Y + 20, 10, 10);
            // Initializes the enemyProjectileRect by setting the position, width and height of the rectangle.
            enemyProjectileRect = new Rectangle(enemyRect.X, enemyRect.Y + 70, 20, 20);

            // Initializes the platformRect by setting the position, width and height of the rectangles.
            /*for (int i = 0; i < platformX.Length; i++)
            {
                platformRect[i] = new Rectangle(platformX[i], platformY[i], platformWidth[i], 10);
            }
            
            platforms = new Platforms[8];*/

            // Initializes the game parts before the game begins.
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads and holds the image "Space Background"
            backgroundPic = Content.Load<Texture2D>("Space Background");
            // Loads and holds the image "Soldier_Left_Gun_Transparent"
            soldierLeft = Content.Load<Texture2D>("Soldier_Left_Gun_Transparent");
            // Loads and holds the image "Soldier_Right_Gun_Transparent"
            soldierRight = Content.Load<Texture2D>("Soldier_Right_Gun_Transparent");
            // Loads and holds the image "Soldier_Standing_Gun_Transparent"
            soldierStraightGun = Content.Load<Texture2D>("Soldier_Standing_Gun_Transparent");
            // Loads and holds the image "Enemy"
            enemyPic = Content.Load<Texture2D>("Enemy");
            // Loads and holds the image "onebyonepixel"
            oneByOnePixel = Content.Load<Texture2D>("onebyonepixel");
            // Loads and holds the image "Bullet_Left"
            bulletLeft = Content.Load<Texture2D>("Bullet_Left");
            // Loads and holds the image "Bullet_Right"
            bulletRight = Content.Load<Texture2D>("Bullet_Right");
            // Loads and holds the image "Instructions"
            instructions = Content.Load<Texture2D>("Instructions");
            // Loads and holds the image "Soldier_Wins"
            playerWinnerScreen = Content.Load<Texture2D>("Soldier_Wins");
            // Loads and holds the image "Enemy_Wins"
            enemyWinnerScreen = Content.Load<Texture2D>("Enemy_Wins");
            // Loads and holds the image "Game Tied"
            gameTiedScreen = Content.Load<Texture2D>("Game Tied");
            // Loads and holds the soundEffect "Walking"
            walkingSound = Content.Load<SoundEffect>("Walking");
            // Loads and holds the soundEffect "Gunshot"
            gunshot = Content.Load<SoundEffect>("Gunshot");
            // Loads and holds the spriteFont "SpriteFont1"
            spriteFont1 = Content.Load<SpriteFont>("SpriteFont1");

            // Instantiates the GameItem game.           
            game = new GameItem(screenRect, backgroundPic, Color.White);
            // Instantiates the Player soldier.
            soldier = new Player(soldierRect, soldierStraightGun, Color.White, walkingSound, 2, 240, 240, 1, 10);
            // Instantiates the Enemy enemy.
            enemy = new Enemy(enemyRect, enemyPic, Color.White, walkingSound, 2, 300, 300, 10);
            // Creates a new Projectile List for the playerBullet.
            playerBullet = new List<Projectile>();
            // Adds a new Projectile to the playerBullet list.
            playerBullet.Add(new Projectile (soldierProjectileRect, bulletRight, Color.White, gunshot, 10, 1, 1, 20));
            // Creates a new Projectile List for the playerBullet.
            enemyBullet = new List<Projectile>();
            // Adds a new Projectile to the enemyBullet list.
            enemyBullet.Add(new Projectile(enemyProjectileRect, bulletLeft, Color.White, gunshot, -10, 2, 1, 20));

            // Creates the platforms.
            /*for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new Platforms(platformRect[i], oneByOnePixel, Color.White, walkingSound, 0, charLandStatus);
            }*/

            // Instantiates the Rectangle soldierHealthBar.
            soldierHealthBar = new Rectangle(0, 0, soldier.getHealth(), 5);
            // Instantiates the Rectangle enemyHealthBar.
            enemyHealthBar = new Rectangle(800 - enemy.getHealth(), 0, enemy.getHealth(), 5);
            // Sets the upwardMomentum of the soldier to 20.
            soldier.setUpwardMomentum(20);
            // Sets the gravity of the soldier to 3.
            soldier.setGravity(3);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Initializes pad1.
            pad1 = GamePad.GetState(PlayerIndex.One);
            // Initializes kb.
            kb = Keyboard.GetState();

            // Checks if the back button on pad1 is pressed or the escape key on the keyboard is pressed.
            if (pad1.Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
            {
                // Exits the game.
                this.Exit();
            }

            // Checks if gameStart is false and gameEnd is false (Checks if the main game has not started and ended).
            if (!gameStart && !gameEnd)
            {
                // Checks using edge detection whether the start button on game pad or the enter key on the keyboard was pressed.
                if ((oldPad1.Buttons.Start == ButtonState.Released && pad1.Buttons.Start == ButtonState.Pressed) || (oldKb.IsKeyUp(Keys.Enter) && kb.IsKeyDown(Keys.Enter)))
                {
                    // Sets gameStart to true.
                    gameStart = true;
                    // Sets gameEnd to false.
                    gameEnd = false;
                }

                // Sets oldPad1 equal to the last value of pad1.
                oldPad1 = pad1;
                // Sets oldKb equal to kb.
                oldKb = kb;
            }

            // Checks if gameStart is true and gameEnd is false (Checks if the main game has started but has not been ended).
            if (gameStart && !gameEnd)
            {                
                // Uses for loop to update the movement of the playerBullet.
                for (int i = 0; i < playerBullet.Count; i++)
                {
                    playerBullet[i].Update();
                }

                // Uses for loop to update the movement of the enemyBullet.
                for (int i = 0; i < enemyBullet.Count; i++)
                {
                    enemyBullet[i].Update();
                }

                // Checks if the soldier is facing Left.
                if (soldier.getDirection().Equals("Left"))
                {
                    // Sets the image of the soldier to be displayed to soldierLeft.
                    soldier.setTexture(soldierLeft);
                }
                // Works if the previous statement is untrue
                // Checks if the soldier is facing Right.
                else if (soldier.getDirection().Equals("Right"))
                {
                    // Sets the image of the soldier to be displayed to soldierRight.
                    soldier.setTexture(soldierRight);
                }
                // Works if both previous statements are untrue.
                else
                {
                    // Sets the image of the soldier to be displayed to soldierStraightGun.
                    soldier.setTexture(soldierStraightGun);
                }

                // Checks if the B button on the game pad or the B key on the keyboard is pressed.
                if (soldier.getBPressedStatus().Equals(true))
                {
                    // Checks if the soldier is facing Left.
                    if (soldier.getDirection().Equals("Left"))
                    {
                        // Checks if the playerTimeDelay (time since the last shot) is more than 20 ticks.
                        if (playerTimeDelay >= 20)
                        {
                            // Changes the X position of the soldierProjectileRect to the X position of soldier's rectangle.
                            soldierProjectileRect.X = soldier.getRectangle().X;
                            // Adds a new Projectile to the playerBullet List.
                            playerBullet.Add(new Projectile(soldierProjectileRect, bulletLeft, Color.White, gunshot, -10, 5, 1, 20));
                            // Resets the playerTimeDelay to 0.
                            playerTimeDelay = 0;
                            // Plays the gunshot soundEffect.
                            gunshot.Play();                            
                        }

                    }
                    // Works if the previous statement is untrue.
                    // Checks if the soldier is facing Left.
                    else if (soldier.getDirection().Equals("Right"))
                    {
                        // Checks if the playerTimeDelay(time since the last shot) is more than 20 ticks.
                        if (playerTimeDelay >= 20)
                        {
                            // Changes the X position of the soldierProjectileRect to the sum of the X position of soldier's rectangle and the soldier's rectangle's width.
                            soldierProjectileRect.X = soldier.getRectangle().X + soldier.getRectangle().Width;
                            // Adds a new Projectile to the playerBullet List.
                            playerBullet.Add(new Projectile(soldierProjectileRect, bulletRight, Color.White, gunshot, 10, 5, 1, 20));
                            // Resets the playerTimeDelay to 0.
                            playerTimeDelay = 0;
                            // Plays the gunshot soundEffect.
                            gunshot.Play();
                        }
                    }
                }

                // Updates the Y position of the soldierProjectileRect to the sum of the Y position of soldier's rectangle and 55.
                soldierProjectileRect.Y = soldier.getRectangle().Y + 55;

                // Checks if enemyTimeDleay(time since the last shot)
                if (enemyTimeDelay >= 60)
                {
                    // Updates the X position of the enemyProjectileRect to the X position of enemy's rectangle.
                    enemyProjectileRect.X = enemy.getRectangle().X;
                    // Updates the Y position of the enemyProjectileRect to the sum of the Y position of the enemy's rectangle and 70.
                    enemyProjectileRect.Y = enemy.getRectangle().Y + 70;
                    // Adds a new Projectile to the enemyBullet List.
                    enemyBullet.Add(new Projectile(enemyProjectileRect, bulletRight, Color.White, gunshot, -10, 2, 1, 20));
                    // Resets the enemyTimeDelay to 0.
                    enemyTimeDelay = 0;
                    // Plays the gunshot soundEffect.
                    gunshot.Play();
                }

                // Begins for loop
                /*for (int i = 0; i < platforms.Length; i++)
                {
                    // Checks whether a platform intersected with the soldier's rectangle.
                    if (platforms[i].getRectangle().Intersects(soldier.getRectangle()))
                    {
                        // Checks whether the setBottomYLimit (which also has the hit test) returns true.
                        if (soldier.setBottomYLimit(platforms[i]))
                        {
                            // Sets the bottom y limit to the top of the platform.
                            soldier.setBottom(platforms[i].getRectangle().Y);
                            // Sets falling to false.
                            //soldier.setFalling(false);
                            // Carries out the hit test for the sides of the platforms.
                            soldier.CharPlatHitTest(platforms[i]);
                            // Breaks out of the loop.
                            break;
                        }
                    }
                }*/


                // Begins for loop.
                /*for(int i=0; i< platforms.Length; ++i)
                {
                    // Checks if the bottom of the soldier's rectangle was less than the top of a platform.
                    if(soldier.getRectangle().Bottom < platforms[i].getRectangle().Top)
                    {
                        // Checks if the left of the soldier's rectangle is greater than or equal to the right of the platform and the right of the soldier's rectangle is lesser than or equal to the left of the platform.
                        if(soldier.getRectangle().Left>= platforms[i].getRectangle().Right && soldier.getRectangle().Right <= platforms[i].getRectangle().Left)
                        {
                            // Sets the bottom Y limit to the top of the platform.
                            soldier.setBottom(platforms[i].getRectangle().Top);
                            // breaks out of the loop
                            break;
                        }
                        // Works if the previous if statement was untrue.
                        else
                        {
                            // Sets the bottom Y limit to the height of the screen.
                            soldier.setBottom(GraphicsDevice.Viewport.Height);
                        }
                    }
                }*/

                // Begin for loop
                // There are two for loop statements as there were two attempts to check the hit test, backwards and forwards.
                /*for (int i = platforms.Length - 1; i >= 0; i--)
                for (int i = 0; i < platforms.Length; i++)
                {
                    // Carries out the hit test for the sides of the platforms.
                    //soldier.CharPlatHitTest(platforms[i]);
                    // Checks whether the setBottomYLimit (which also has the hit test) returns true.
                    if (soldier.setBottomYLimit(platforms[i]))
                    {
                        // Sets the bottom y limit to the top of the platform.
                        soldier.setBottom(platforms[i].getRectangle().Y);

                        // The next part was a desperate effort to get the hit test to work but was not part of the code, other than 2 times, when it was run generally.

                        // Checks if the bottom Y value is equal to 90.
                        /*if (soldier.getBottomY().Equals(90))
                        {
                            // Sets the Y position of the soldier's rectangle to 90 - soldier's height.
                            soldierRect.Y = 90 - soldierRect.Height;
                        }
                        // Works if the previous if statement does not work
                        // Checks if the bottom Y value is equal to 150.
                        else if (soldier.getBottomY().Equals(150))
                        {
                            // Sets the Y position of the soldier's rectangle to 150 - soldier's height.
                            soldierRect.Y = 150 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 230.
                        else if (soldier.getBottomY().Equals(230))
                        {
                            // Sets the Y position of the soldier's rectangle to 230 - soldier's height.
                            soldierRect.Y = 230 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 320.
                        else if (soldier.getBottomY().Equals(320))
                        {
                            // Sets the Y position of the soldier's rectangle to 320 - soldier's height.
                            soldierRect.Y = 320 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 330.
                        else if (soldier.getBottomY().Equals(330))
                        {
                            // Sets the Y position of the soldier's rectangle to 330 - soldier's height.
                            soldierRect.Y = 330 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 400.
                        else if (soldier.getBottomY().Equals(400))
                        {
                            // Sets the Y position of the soldier's rectangle to 400 - soldier's height.
                            soldierRect.Y = 400 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 450.
                        else if (soldier.getBottomY().Equals(450))
                        {
                            // Sets the Y position of the soldier's rectangle to 450 - soldier's height.
                            soldierRect.Y = 450 - soldierRect.Height;
                        }
                        // Works if the previous if statements do not work
                        // Checks if the bottom Y value is equal to 480.
                        else if (soldier.getBottomY().Equals(480))
                        {
                            // Sets the Y position of the soldier's rectangle to 480 - soldier's height.
                            soldierRect.Y = 480 - soldierRect.Height;
                        }
                        // Breaks out of the loop.
                        break;*/
                //}
                // Works if the previous if statement does not work.
                /*else
                {
                    // Carries out the hit test to check whether the soldier landed or not.
                    platforms[i].checkCharLandStatus(soldier);
                }*/

                // Carries out the hit test for the sides of the platforms.
                //soldier.CharPlatHitTest(platforms[i]);                    
                // }

                // Checks if the bottom Y value is equal to 90.
                /*if (soldier.getBottomY().Equals(90))
                {
                    // Sets the Y position of the soldier's rectangle to 90 - soldier's height.
                    soldierRect.Y = 90 - soldierRect.Height;
                }
                // Works if the previous if statement does not work
                // Checks if the bottom Y value is equal to 150.
                else if (soldier.getBottomY().Equals(150))
                {
                    // Sets the Y position of the soldier's rectangle to 150 - soldier's height.
                    soldierRect.Y = 150 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 230.
                else if (soldier.getBottomY().Equals(230))
                {
                    // Sets the Y position of the soldier's rectangle to 230 - soldier's height.
                    soldierRect.Y = 230 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 320.
                else if (soldier.getBottomY().Equals(320))
                {
                    // Sets the Y position of the soldier's rectangle to 320 - soldier's height.
                    soldierRect.Y = 320 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 330.
                else if (soldier.getBottomY().Equals(330))
                {
                    // Sets the Y position of the soldier's rectangle to 330 - soldier's height.
                    soldierRect.Y = 330 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 400.
                else if (soldier.getBottomY().Equals(400))
                {
                    // Sets the Y position of the soldier's rectangle to 400 - soldier's height.
                    soldierRect.Y = 400 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 450.
                else if (soldier.getBottomY().Equals(450))
                {
                    // Sets the Y position of the soldier's rectangle to 450 - soldier's height.
                    soldierRect.Y = 450 - soldierRect.Height;
                }
                // Works if the previous if statements do not work
                // Checks if the bottom Y value is equal to 480.
                else if (soldier.getBottomY().Equals(480))
                {
                    // Sets the Y position of the soldier's rectangle to 480 - soldier's height.
                    soldierRect.Y = 480 - soldierRect.Height;
                }
                // Breaks out of the loop.*/
                
                // The following code checks manually the hit test for the platform and the player.
                /*platforms[0].checkCharLandStatus(soldier);
                platforms[1].checkCharLandStatus(soldier);
                platforms[2].checkCharLandStatus(soldier);
                platforms[3].checkCharLandStatus(soldier);
                platforms[4].checkCharLandStatus(soldier);
                platforms[5].checkCharLandStatus(soldier);
                platforms[7].checkCharLandStatus(soldier);
                platforms[7].checkCharLandStatus(soldier);*/

                // Calls the move method to ensure that the user is able to control the movement of the soldier.
                soldier.Move(pad1, kb, soldierProjectileRect);
                // Sets the bottom Y limit to th height of the graphics device.
                soldier.setBottom(GraphicsDevice.Viewport.Height);
                // Calls the UpdateChar method to make the character jump, fall.
                soldier.UpdateChar();
                // Calls the Update method to make the enemy move up and down constantly.
                enemy.Update(gameTime);

                // Checks whether the healthBarTimeDelay (time since last hit) is greater than or equal to 120 ticks.
                if (healthBarTimeDelay >= 120)
                {
                    // Checks if the player and enemy have collided
                    if (soldier.PlayerEnemyHitTest(enemy).Equals(true))
                    {
                        // Checks if the soldier's health is more than 0
                        if (soldier.getHealth() > 0)
                        {
                            // Reduces the width of the soldier's health bar by 2 every time a hit happens.
                            soldierHealthBar.Width -= 2;
                            // Sets the soldier's health to the current health - 2.
                            soldier.setHealth(soldier.getHealth() - 2);
                            // Resets the healthBarTimeDelay to 0.
                            healthBarTimeDelay = 0;
                        }
                        // Works if the previous if statement is untrue.
                        else
                        {
                            // Stops reducing the soldier's health bar's width.
                            soldierHealthBar.Width -= 0;
                            // Sets the health of soldier equal to 0.
                            soldier.setHealth(0);
                            // Resets the healthBarTimeDelay to 0.
                            healthBarTimeDelay = 0;
                            // Sets the value of gameEnd to true.
                            gameEnd = true;
                        }

                    }
                }

                // Begins for loop.
                for (int i = 0; i < playerBullet.Count; i++)
                {
                    // Checks if the playerBullet hits the enemy.
                    if (playerBullet[i].getRectangle().Intersects(enemy.getRectangle()))
                    {          
                        // Checks if the enemy's health is greater than 0.              
                        if (enemy.getHealth() > 0)
                        {
                            // Changes the X position of enemyHealthBar by 1.
                            enemyHealthBar.X += 1;
                            // Sets the health of the enemy to the current health - 1.
                            enemy.setHealth(enemy.getHealth() - 1);
                        }
                        // Works if the previous if statement is untrue.
                        else
                        {
                            // Stops changing the X position of the enemy's health bar.
                            enemyHealthBar.X += 0;
                            // Sets the health of the enemy to 0.
                            enemy.setHealth(0);
                            // Sets gameEnd to true.
                            gameEnd = true;
                        }
                    }
                }

                // Begins for loop.
                for (int i = 0; i < enemyBullet.Count; i++)
                {
                    // Checks if the enemyBullet hits the soldier.
                    if (enemyBullet[i].getRectangle().Intersects(soldier.getRectangle()))
                    {
                        // Checks if the soldier's health is greater than 0.
                        if (soldier.getHealth() > 0)
                        {
                            // Reduces the width of the soldier's health bar by 2.
                            soldierHealthBar.Width -= 2;
                            // Sets the health of the soldier to the current health - 2.
                            soldier.setHealth(soldier.getHealth() - 2);
                        }
                        // Works if the previous if statement is untrue.
                        else
                        {
                            // Stops reducing the width of the soldier's health bar.
                            soldierHealthBar.Width += 0;
                            // Sets the health of the soldier to 0.
                            soldier.setHealth(0);
                            // Sets gameEnd to true.
                            gameEnd = true;
                        }
                    }
                }
                
                // Sets the width of the soldier's health bar to the value of the soldier's current health.
                soldierHealthBar.Width = soldier.getHealth();
                
                // Checks if the soldier is not jumping.
                if (soldier.getJumping().Equals(false))
                {
                    // Sets the upwardMomentum of the soldier to 20.                    
                    soldier.setUpwardMomentum(20);
                    // Sets the gravity of the soldier to 3.
                    soldier.setGravity(3);
                }
                
                // Increments the value of playerTimeDelay by 1 every time the game updates.
                playerTimeDelay++;
                // Increments the value of healthBarTimeDelay by 1 every time the game updates.
                healthBarTimeDelay++;
                // Increments the value of enemyTimeDelay by 1 every time the game updates.
                enemyTimeDelay++;
            }
            
            // Checks if gameStart is true and gameEnd is true (Checks whether the main game first started and then ended).
            if (gameStart && gameEnd)
            {
                // Checks if the soldier's health is less than or equal to 0 and the enemy's health is greater than 0.
                if (soldier.getHealth() <= 0 && enemy.getHealth() > 0)
                {
                    // Sets playerWins to false.
                    playerWins = false;
                    // Sets enemyWins to true.
                    enemyWins = true;
                }
                // Works if the previous if statement does not work.
                // Checks if the soldier's health is greater than 0 and the enemy's health is less than or equal to 0.
                else if (soldier.getHealth() > 0 && enemy.getHealth() <= 0)
                {
                    // Sets playerWins to true.
                    playerWins = true;
                    // Sets enemyWins to false.
                    enemyWins = false;
                }
                // Works if the previous if statements do not work.
                // Checks if the soldier's health is less than or equal to 0 and the enemy's health is less than or equal to 0.
                else if (soldier.getHealth() <= 0 && enemy.getHealth() <= 0)
                {
                    // Sets playerWins to true.
                    playerWins = true;
                    // Sets enemyWins to true.
                    enemyWins = true;
                }
            }            

            // Updates the game at every tick.
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Begins drawing sprites (images).
            spriteBatch.Begin();

            // Checks if both gameStart and gameEnd are false.
            if (!gameStart && !gameEnd)
            {
                // Displays instructions
                spriteBatch.Draw(instructions, screenRect, Color.White);
            }

            // Checks whether the gameStart is true and gameEnd is false.
            if (gameStart && !gameEnd)
            {
                // Draws the gameItem game.
                game.DrawSprite(spriteBatch);

                // Draws the platforms.
                /*for (int i = 0; i < platforms.Length; i++)
                {
                    platforms[i].DrawSprite(spriteBatch);
                }*/

                // Draws the Player soldier.
                soldier.DrawSprite(spriteBatch);
                // Draws the Enemy enemy.
                enemy.DrawSprite(spriteBatch);

                // Draws the player bullets.
                for (int i = 0; i < playerBullet.Count; i++)
                {
                    playerBullet[i].DrawSprite(spriteBatch);
                }

                // Draws the enemy bullets.
                for (int i = 0; i < enemyBullet.Count; i++)
                {
                    enemyBullet[i].DrawSprite(spriteBatch);
                }
                
                // Displays the health of the enemy in number form.
                spriteBatch.DrawString(spriteFont1, enemy.getHealth().ToString(), new Vector2(765, 15), Color.White);

                // Displays the health of the soldier in number form.
                spriteBatch.DrawString(spriteFont1, soldier.getHealth().ToString(), new Vector2(5, 15), Color.White);
                                
                // Draws the soldier's health bar.
                spriteBatch.Draw(oneByOnePixel, soldierHealthBar, Color.Red);

                // Draws the enemy's health bar.
                spriteBatch.Draw(oneByOnePixel, enemyHealthBar, Color.Red);
                
            }

            // Checks if both gameStart and gameEnd are true.
            if (gameStart && gameEnd)
            {
                // Checks if playerWins is false and enemyWins is true.
                if (!playerWins && enemyWins)
                {
                    // Displays the enemy as the winner.
                    spriteBatch.Draw(enemyWinnerScreen, screenRect, Color.White);
                }
                // Works if the previous if statement is untrue.
                // Checks if playerWins is true and enemyWins is false.
                else if (playerWins && !enemyWins)
                {
                    // Displays the player as the winner.
                    spriteBatch.Draw(playerWinnerScreen, screenRect, Color.White);
                }
                // Works if the previous if statement is untrue.
                // Checks if both playerWins and enemyWins is true.
                else if (playerWins && enemyWins)
                {
                    // Displays that the game has tied.
                    spriteBatch.Draw(gameTiedScreen, screenRect, Color.White);
                }
            }
            // Stops drawing sprites (images).
            spriteBatch.End();

            // Draws the items at every game tick.
            base.Draw(gameTime);
        }
    }
}
