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
    class Player: Characters
    {
        // Creates an int variable lives.
        private int lives;
        // Creates an int variable points.
        private int points;

        // Creates the Player constructor and provides parameters.
        public Player (Rectangle rect, Texture2D texture, Color color, SoundEffect sound, int speed, int health, int maxHealth, int aLives, int aPoints): base(rect, texture, color, sound, speed, health, maxHealth)
        {
            // Sets lives equal to the user entered value of aLives.
            this.lives = aLives;
            // Sets points equal to the user entered value of aPoints.
            this.points = aPoints;
        }

        // Creates a method to get lives.
        public int getLives()
        {
            // Returns the value of lives
            return lives;
        }

        // Creates a method to set the value of lives.
        public void setLives(int aLives)
        {
            // Sets the value of lives to the user entered value of aLives.
            lives = aLives;
        }

        // Creates a method to get points.
        public int getPoints()
        {
            // Returns the value of points.
            return points;
        }

        // Creates a method to set the value of points.
        public void setPoints(int aPoints)
        {
            // Sets the value of points to the user entered value of aPoints.
            points = aPoints;
        }
               
        // Creates a bool return method PlayerEnemyHitTest to conduct and return the result of the hit test between the player and the enemy.
        public bool PlayerEnemyHitTest(Enemy enemy)
        {
            // Checks if the player and the enemy intersect.
            if (this.rectangle.Intersects(enemy.getRectangle()))
            {
                // Reduces the health of the player by 10.
                this.health -= 10;
                // Returns true.
                return true;               
            }
            // Works if the previous if statement is untrue.
            else
            {
                // Returns false.
                return false;
            }
        }
    }
}
