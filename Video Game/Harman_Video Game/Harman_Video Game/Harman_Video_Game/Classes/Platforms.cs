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
    class Platforms: MovingGameItem
    {
        // Creates a bool variable didCharLand
        private bool didCharLand;
        // Creates a bool variable didCharPlatHitL
        private bool didCharPlatHitL;
        // Creates a bool variable didCharPlatHitR
        private bool didCharPlatHitR;

        // Creates the Platforms constructor and provides parameters.
        public Platforms(Rectangle rect, Texture2D texture, Color color, SoundEffect sound, int speed, bool isCharLanded): base(rect, texture, color, sound, speed)
        {
            // Sets didCharLand equal to the user entered value of isCharLanded.
            this.didCharLand = isCharLanded;
        }

        // Creates a method to get the character land status
        public bool getCharLandStatus()
        {
            // Returns the value of didCharLand.
            return didCharLand;
        }

        // Creates a method to set the character land status.
        public void setCharLandStatus(bool isCharLanded)
        {
            // Sets didCharLand to the user entered value of isCharLanded.
            didCharLand = isCharLanded;
        }

        // Creates a method to get the character platform hit status from the left.
        public bool getCharPlatHitL()
        {
            // Returns the value of didCharPlatHitL.
            return didCharPlatHitL;
        }

        // Creates a method to set the character platform hit status from the left.
        public void setCharPlatHitL(bool isCharPlatHitL)
        {
            // Sets didCharPlatHitL to the user entered value of isCharPlatHitL.
            didCharPlatHitL = isCharPlatHitL;
        }

        // Creates a method to get the character platform hit status from the right.
        public bool getCharPlatHitR()
        {
            // Returns the value of didCharPlatHitR.
            return didCharPlatHitR;
        }

        // Creates a method to set the character platform hit status from the right.
        public void setCharPlatHitR(bool isCharPlatHitR)
        {
            // Sets didCharPlatHitR to the user entered value of isCharPlatHitR.
            didCharPlatHitR = isCharPlatHitR;
        }

        // Creates a method to check whether the character has landed on top of the platform or not.
        public void checkCharLandStatus (Characters other)
        {
            // Checks if the character's rectangle intersects with a platform's rectangle.
            if (other.getRectangle().Intersects(rectangle))
            {
                // Checks if the bottom of the character's rectangle is greater than or equal to the top of the platform's rectangle and is less than or equal to the sum of the values of the top of the platform's rectangle and 5.
                if (other.getRectangle().Bottom >= rectangle.Top && other.getRectangle().Bottom <= rectangle.Top + 5)
                {
                    // Set didCharLand to true.
                    didCharLand = true;
                    // Sets the jumping of the character to false.
                    other.setJumping(false);
                }
                // Works if the previous if statement is untrue.
                else
                {
                    // Sets didCharLand to false.
                    didCharLand = false;
                }
            }
        }

        public void HitTest (Characters other)
        {
            // Checks whether the character intersects with the platform and the right side of the character is greater than or equal to the left side of the platform and less than or equal to the sum of the value of the left side of the platform and 5.
            if (rectangle.Intersects(other.getRectangle()) && rectangle.Left >= other.getRectangle().Right && rectangle.Left + 5 <= other.getRectangle().Right)
            {
                // Sets didCharPlatHitR to true.
                didCharPlatHitR = true;                
            }
            // Works if the previous if statement is untrue.
            else
            {
                // Sets didCharPlatHitR to false.
                didCharPlatHitR = false;
            }

            // Checks whether the character intersects with the platform and the left side of the character is greater than or equal to the right side of the platform and less than or equal to the difference of the value of the right side of the platform and 5.
            if (rectangle.Intersects(other.getRectangle()) && rectangle.Right <= other.getRectangle().Left && rectangle.Right - 5 >= other.getRectangle().Right)
            {
                // Sets didCharPlatHitL to true.
                didCharPlatHitL = true;                                                                               
            }
            // Works if the previous if statement is untrue.
            else
            {
                // Sets didCharPlatHitL to false.
                didCharPlatHitL = false;
            }
        }        
    }
}
