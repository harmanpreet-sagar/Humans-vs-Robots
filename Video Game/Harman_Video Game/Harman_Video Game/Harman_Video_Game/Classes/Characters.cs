using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Harman_Video_Game.Classes
{
    class Characters: MovingGameItem
    {
        // Declares an int variable health.
        protected int health;
        // Declares an int variable maxHealth.
        protected int maxHealth;
        // Declares a bool variable jumping.
        private bool jumping;
        // Declares a bool variable falling.
        private bool falling;
        // Declares an int variable gravitationalForce.
        private int gravitationalForce;
        // Declares an int variable upwardMomentum
        private int upwardMomentum;
        // Declares an int variable bottomYLimit.
        private int bottomYLimit;
        // Declares a string variable direction.
        private string direction = "Front";
        // Declares a bool variable didCharPlatHitL.
        private bool didCharPlatHitL;
        // Declares a bool variable didCharPlatHitR.
        private bool didCharPlatHitR;
        // Declares a bool variable isButtonBPressed.
        private bool isButtonBPressed;
        // Declares a bool variable isCharMoving.
        private bool isCharMoving;

        // Creates the Characters constructor and provides parameters.
        public Characters(Rectangle rect, Texture2D aTexture, Color color, SoundEffect aSound, int aSpeed, int aHealth, int aMaxHealth): base(rect, aTexture, color, aSound, aSpeed)
        {
            // Sets health equal to the user entered value of aHealth.
            this.health = aHealth;
            // Sets maxHealth equal to the user entered value of aMaxHealth.
            this.maxHealth = aMaxHealth;
        }

        // Creates a method to get health.
        public int getHealth()
        {
            // Returns the value of health
            return health;
        }

        // Creates a method to set the value of health.
        public void setHealth(int aHealth)
        {
            // Sets the value of health to the user entered value of aHealth.
            health = aHealth;
        }

        // Creates a method to get maxHealth.
        public int getMaxHealth()
        {
            // Returns the value of maxHealth
            return maxHealth;
        }

        // Creates a method to set the value of maxHealth.
        public void setMaxHealth(int aMaxHealth)
        {
            // Sets the value of maxHealth to the user entered value of aMaxHealth.
            maxHealth = aMaxHealth;
        }

        // Creates a method to get jumping.
        public bool getJumping()
        {
            // Returns the value of jumping
            return jumping;
        }

        // Creates a method to set the value of jumping.
        public void setJumping(bool isJumping)
        {
            // Sets the value of jumping to the user entered value of isJumping.
            jumping = isJumping;
        }

        // Creates a method to get falling.
        public bool getFalling()
        {
            // Returns the value of falling
            return falling;
        }

        // Creates a method to set the value of falling.
        public void setFalling(bool isFalling)
        {
            // Sets the value of falling to the user entered value of isFalling.
            falling = isFalling;
        }

        // Creates a method to get gravitationalForce.
        public int getGravity()
        {
            // Returns the value of gravitationalForce
            return gravitationalForce;
        }

        // Creates a method to set the value of gravitationalForce.
        public void setGravity(int gravity)
        {
            // Sets the value of gravitationalForce to the user entered value of gravity.
            gravitationalForce = gravity;
        }

        // Creates a method to get upwardMomentum.
        public int getUpwardMomentum()
        {
            // Returns the value of upwardMomentum
            return upwardMomentum;
        }

        // Creates a method to set the value of upwardMomentum.
        public void setUpwardMomentum(int upMomentum)
        {
            // Sets the value of upwardMomentum to the user entered value of upMomentum.
            upwardMomentum = upMomentum;
        }

        // Creates a method to get bottomYLimit.
        public int getBottomY()
        {
            // Returns the value of bottomYLimit
            return bottomYLimit;
        }

        // Creates a method to set the value of bottomYLimit.
        public void setBottom(int bottom)
        {
            // Sets the value of bottomYLimit to the user entered value of bottom.
            bottomYLimit = bottom;
        }

        // Creates a method to get direction.
        public string getDirection()
        {
            // Returns the value of direction
            return direction;
        }

        // Creates a method to set the value of direction.
        public void setDirection(string aDirection)
        {
            // Sets the value of direction to the user entered value of aDirection.
            direction = aDirection;
        }

        // Creates a method to get whether character and platform hit left.
        public bool getCharPlatHitL()
        {
            // Returns the value of didCharPlatHitL.
            return didCharPlatHitL;
        }

        // Creates a method to set whether character and platform hit left.
        public void setCharPlatHitL(bool isCharPlatHitL)
        {
            // Sets the value of didCharPlatHitL to the user entered value of isCharPlatHitL.
            didCharPlatHitL = isCharPlatHitL;
        }

        // Creates a method to get whether character and platform hit right.
        public bool getCharPlatHitR()
        {
            // Returns the value of didCharPlatHitR
            return didCharPlatHitR;
        }

        // Creates a method to set whether character and platform hit right.
        public void setCharPlatHitR(bool isCharPlatHitR)
        {
            // Sets the value of didCharPlatHitR to the user entered value of isCharPlatHitR.
            didCharPlatHitR = isCharPlatHitR;
        }

        // Creates a method to get the status of the pressing of the B button.
        public bool getBPressedStatus()
        {
            // Returns the value of isButtonBPressed.
            return isButtonBPressed;
        }

        // Creates a method to set the status of the pressing of the B button.
        public void setBPressedStatus(bool buttonBPressedStatus)
        {
            // Sets the value of isButtonBPressed to the user entered value of buttonBPressedStatus.
            isButtonBPressed = buttonBPressedStatus;
        }

        // Creates a method to get whether the character is moving.
        public bool getCharMoveStatus()
        {
            // Returns the value of isCharMoving.
            return isCharMoving;
        }

        // Creates a method to set whether the character is moving.
        public void setCharMoveStatus(bool didCharMove)
        {
            // Sets the value of isCharMoving to the user entered value of didCharMove.
            isCharMoving = didCharMove;
        }

        // Creates a method to conduct the hit test between the character and the platform.
        public void CharPlatHitTest(Platforms platform)
        {
            // Checks whether the character intersects with the platform and the left side of the character is greater than or equal to the right side of the platform and less than or equal to the sum of the value of the right side of the platform and 5.
            if (this.rectangle.Intersects(platform.getRectangle()) && this.rectangle.Left >= platform.getRectangle().Right && this.rectangle.Left + 5 <= platform.getRectangle().Right)
            {
                // Set didCharPlathitR to true.
                didCharPlatHitR = true;
            }
            // Works if the previous if statement is untrue.
            else
            {
                // Set didCharPlatHitR to false.
                didCharPlatHitR = false;
            }

            // Checks whether the character intersects with the platform and the right side of the character is less than or equal to the left side of the platform and greater than or equal to the difference of the value of the left side of the platform and 5.
            if (this.rectangle.Intersects(platform.getRectangle()) && this.rectangle.Right <= platform.getRectangle().Left && this.rectangle.Left - 5 >= platform.getRectangle().Right)
            {
                // Set didCharPlatHitL to true.
                didCharPlatHitL = true;
            }
            // Works if the previous statement is untrue.
            else
            {
                // Set didCharPlatHitL to true.
                didCharPlatHitL = false;
            }
        }

        // Creates a method to move the character(s).
        public void Move(GamePadState pad1, KeyboardState kb, Rectangle projectileRect)//, Platforms platform)
        {
            // Checks if the value of X position of the left thumb stick of the controller is less than 0 or the left key on the keyboard is pressed.
            if (pad1.ThumbSticks.Left.X < 0 || kb.IsKeyDown(Keys.Left))
            {
                // Checks if the X value of the rectangle is less than or equal to 0 or didCharPlatHitL is true.
                // The remaining commented out code of this statement performed the same functions as didCharPlatHitL.
                if (rectangle.X <= 0 || didCharPlatHitL)// || (platform.getRectangle().Intersects(rectangle) && platform.getRectangle().Right >= rectangle.Left && platform.getRectangle().Right - 5 <= rectangle.Left))
                {                    
                    // Prevents the pic from moving in the same direction
                    rectangle.X -= 0;                    
                }
                else
                {
                    // Changes the X position of the image.
                    rectangle.X -= speed;
                    isCharMoving = true;
                }
            }

            // Checks if the value of X position of the left thumb stick of the controller is greater than 0 or the right key on the keyboard is pressed.
            if (pad1.ThumbSticks.Left.X > 0 || kb.IsKeyDown(Keys.Right))
            {
                // Checks if the X value of the rectangle + the width of the rectangle is greater than or equal to 800 (Width of the graphics window).
                if ((rectangle.X + rectangle.Width) >= 800 || didCharPlatHitR)// || (platform.getRectangle().Intersects(rectangle) && platform.getRectangle().Left <= rectangle.Right && platform.getRectangle().Left + 5 >= rectangle.Right))
                {
                    // Prevents the pic from moving in the same direction.
                    rectangle.X += 0;
                }
                else
                {
                    // Changes the X position of the image.
                    rectangle.X += speed;
                    // Sets isCharMoving to true.
                    isCharMoving = true;
                }
            }

            // Checks if the value of X position of the left thumb stick of the controller is less than 0 or the left key on the keyboard is pressed.
            if (pad1.ThumbSticks.Left.X < 0 || kb.IsKeyDown(Keys.Left))
            {
                // Sest direction equal to "Left"
                direction = "Left";
            }
            // Works if the previous statement is untrue
            // Checks if the value of X position of the left thumb stick of the controller is greater than 0 or the right key on the keyboard is pressed.
            else if (pad1.ThumbSticks.Left.X > 0 || kb.IsKeyDown(Keys.Right))
            {
                // Sets direction equal to "Right"
                direction = "Right";
            }
            // Works if the previous statements are untrue
            else
            {
                // Sets direction equal to "Front"
                direction = "Front";
            }
            
            // Checks whether jumping is false and the bottom of the character rectangle is greater than or equal to the bottomYLimit            
            if (!jumping && rectangle.Bottom >= bottomYLimit)
            {
                // Checks if the A Button on the game pad or the space bar on the keyboard is pressed.
                if (pad1.Buttons.A == ButtonState.Pressed || kb.IsKeyDown(Keys.Space))
                {
                    // Sets jumping to true.                   
                    jumping = true;
                    // Sets upwardMomentum to the user entered value of upwardMomemntum.
                    upwardMomentum = this.getUpwardMomentum();
                    // Sets gravitationalForce to the user entered value of gravity.
                    gravitationalForce = this.getGravity();
                    
                }
            }
            
            // Checks if the B button on the game pad or the B key on the keyboard is pressed.
            if (pad1.Buttons.B == ButtonState.Pressed || kb.IsKeyDown(Keys.B))
            {
                // Sets isButtonBPressed to true.
                isButtonBPressed = true;
            }
            // Works if the previous if statement is untrue
            else
            {
                // Sets isButtonBPressed to false.
                isButtonBPressed = false;
            }           
        }
        
        // Creates a bool return method setBottomYLimit to carry out the vertical hit test between the platforms and the character and also set the bottom Y limit.
        public bool setBottomYLimit (Platforms platform)
        {
            // Checks if the bottom of the character's rectangle is less than or equal to the Y value of the platform's rect.
            if (this.rectangle.Bottom <= platform.getRectangle().Y)
            {
                // Checks if the right side of the character's rectangle is greater than or equal to the left side of the platform's rect and the left side of the character's rectangle is less than the right side of the platform's rectangle .
                if ((this.rectangle.Right >= platform.getRectangle().X) && (this.rectangle.Left <= platform.getRectangle().X + platform.getRectangle().Width))
                {
                    // Sets the bottomYLimit to the Y position of the platform.
                    this.bottomYLimit = platform.getRectangle().Y;
                    // Return true.
                    return true;
                }
                // Works if the previous if statement is untrue.
                else
                {
                    // Sets the bottomYLimit to 480.
                    this.bottomYLimit = 480;
                    // Return false.
                    return false;                    
                }
            }
            // Works if the previous if statement is untrue.
            else
            {
                // Sets the bottomYLimit to 480.
                this.bottomYLimit = 480;
                // Return false.
                return false;
            }
        }        

        // Creates a method to Update the characters.
        public void UpdateChar()
        {
            // Checks if the bottom of the rectangle is less than the bottomYLimit.
            if (this.rectangle.Bottom < bottomYLimit)
            {
                // Sets falling is true.
                falling = true;
            }

            // Checks if jumping is true.
            if (jumping)
            {
                // Checks if the Y value of the rectangle is less than or equal to 0.
                // The commented out code checks whether the top of the player's rectangle is hitting the bottom of the platform's rectangle.
                if (rectangle.Y <= 0)// || (platform.getRectangle().Intersects(rectangle) && platform.getRectangle().Bottom >= rectangle.Top && platform.getRectangle().Bottom <= rectangle.Top + 5))
                {
                    // Set upwardMomentum to 0.
                    upwardMomentum = 0;
                    // Set jumping equal to false
                    jumping = false;
                    // Set falling equal to true.
                    falling = true;
                }

                // Changes the Y position of the character's rectangle with the set upwardMomentum.
                rectangle.Y -= upwardMomentum;

                // Checks if upwardMomentum is greater than 0.
                if (upwardMomentum > 0)
                {
                    // Decrements the value of upwardMomentum by 1.
                    upwardMomentum--;
                    // Sets jumping to true.
                    jumping = true;
                }
                // Works if the previous if statement is untrue.
                else
                {
                    // Sets falling to true.
                    falling = true;
                    // Sets jumping to false.
                    jumping = false;

                }

                // Checks if the bottom of the character rectangle is greater than or equal to bottomYLimit
                if (this.rectangle.Bottom >= bottomYLimit)
                {
                    // Sets gravitationalForce to 0.
                    gravitationalForce = 0;
                    // Sets jumping to true.
                    jumping = false;
                    // Sets the Y coordinate of the character's rectangle to the difference of the bottomYLimit and the height of the player's rectangle.
                    this.rectangle.Y = bottomYLimit - rectangle.Height;
                }
            }

            // Checks if falling is false.
            if (falling)
            {
                // Checks if the Y value of the rectangle is greater than or equal to bottomYLimit.
                // The commented code checks whether the character has landed on the platform.
                if (this.rectangle.Bottom >= bottomYLimit)// || platform.getCharLandStatus().Equals(true))
                {
                    // Sets gravitationalForce to 0.
                    gravitationalForce = 0;
                    // Set falling equal to false
                    falling = false;
                    // Sets the Y coordinate of the character's rectangle to the difference of the bottomYLimit and the height of the player's rectangle.
                    this.rectangle.Y = bottomYLimit - this.rectangle.Height;
                }

                // Changes the Y position of the image based on the set gravitationForce.
                this.rectangle.Y += gravitationalForce;
            }

            // Checks if the health of the character is less than or equal to 0.
            if (this.getHealth() <= 0)
            {
                // Sets the health of the character to 0.
                this.setHealth(0);
            }
        }
    }
}
