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
    class Enemy: Characters
    {
        // Creates an int variable damageInflictedEnemy.
        private int damageInflictedEnemy;
        // Creates a bool variable goingUp and sets default value to true.
        private bool goingUp = true;

        // Creates the Enemy constructor and provides parameters.
        public Enemy(Rectangle rect, Texture2D texture, Color color, SoundEffect sound, int speed, int health, int maxHealth, int aDamageInflicted): base(rect, texture, color, sound, speed, health, maxHealth)
        {
            // Sets the damageInflictedEnemy to the user entered value of aDamageInflicted.            
            this.damageInflictedEnemy = aDamageInflicted;
        }

        // Creates a method to get damageInflictedEnemy.
        public int getDamageInflictedEnemy()
        {
            // Returns the value of damageInflictedEnemy
            return damageInflictedEnemy;
        }

        // Creates a method to set the value of damageInflictedEnemy.
        public void setDamageInflictedEnemy(int aDamageInflictedEnemy)
        {
            // Sets the value of damageInflictedEnemy to the user entered value of aDamageInflictedEnemy.
            damageInflictedEnemy = aDamageInflictedEnemy;
        }

        // Creates a method to Update the enemy class.
        public void Update(GameTime gameTime)
        {
            // Checks if goingUp is false and the speed is less than 0.
            if (!goingUp && speed < 0)
            {
                // Multiplies the current speed by -1.
                speed *= -1;
            }
            // Works if the previous if statement is untrue.
            // Checks if goingUp is true and the speed is greater than 0.
            else if (goingUp && speed > 0)
            {
                // Multiplies the current speed by -1.
                speed *= -1;
            }

            // Checks if the Y value of the enemy's rectangle is less than or equal to 0.
            if (rectangle.Y <= 0)
            {
                // Sets goingUp to false.
                goingUp = false;
            }
            // Checks if the bottom of the enemy's rectangle is greater than or equal to 480.
            if (rectangle.Bottom >= 480)
            {
                // Sets goingUp to true.
                goingUp = true;
            }

            // Changes the Y position of the enemy's rectangle based on the set speed.
            rectangle.Y += speed;
        }
    }
}
