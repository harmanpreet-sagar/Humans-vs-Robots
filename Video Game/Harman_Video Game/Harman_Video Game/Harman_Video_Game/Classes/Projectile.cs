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
    class Projectile: MovingGameItem
    {
        // Creates an int variable damageInflictedProjectile.
        private int damageInflictedProjectile;
        // Creates an int variable ammoCount.
        private int ammoCount;
        // Creates an int variable timeDelay.
        private int timeDelay;

        // Creates the Projectile constructor and provides parameters.
        public Projectile(Rectangle rect, Texture2D aTexture, Color color, SoundEffect sound, int speed, int aProjectileDamage, int aAmmoCount, int delay) : base(rect, aTexture, color, sound, speed)
        {
            // Sets damageInflictedProjectile equal to the user entered value of aProjectileDamage.
            this.damageInflictedProjectile = aProjectileDamage;
            // Sets ammoCount equal to the user entered value of aAmmoCount.
            this.ammoCount = aAmmoCount;
            // Sets timeDelay equal to the user entered value of delay.
            this.timeDelay = delay;
        }

        // Creates a method to get damageInflictedProjectile.
        public int getDamageInflictedProjectile()
        {
            // Returns the value of damageInflictedProjectile.
            return damageInflictedProjectile;
        }

        // Creates a method to set the value of damageInflictedProjectile.
        public void setDamageInflictedProjectile(int aProjectileDamage)
        {
            // Sets the value of damageInflictedProjectile to the user entered value of aAmmoCountaProjectileDamage.
            damageInflictedProjectile = aProjectileDamage;
        }

        // Creates a method to get ammoCount.
        public int getAmmoCount()
        {
            // Returns the value of ammoCount
            return ammoCount;
        }

        // Creates a method to set the value of ammoCount.
        public void setAmmoCount(int aAmmoCount)
        {
            // Sets the value of ammoCount to the user entered value of aAmmoCount.
            ammoCount = aAmmoCount;
        }

        // Creates a method to get timeDelay.
        public int getTimeDelay()
        {
            // Returns the value of timeDelay
            return timeDelay;
        }

        // Creates a method to set the value of timeDelay.
        public void setTimeDelay(int delay)
        {
            // Sets the value of timeDelay to the user entered value of aAmmoCountdelay.
            timeDelay = delay;
        }

        // Creates a method to update the Projectiles.
        public void Update(GameTime gameTime, Player player, Enemy enemy, Projectile enemyProjectile)
        {
            // Checks if the projectile intersects with the enemy.
            if (this.rectangle.Intersects(enemy.getRectangle()))
            {
                // Checks if the enemy's health is greater than 0.
                if (enemy.getHealth() > 0)
                {
                    // Sets the health of enemy to the current health - 1.
                    enemy.setHealth(enemy.getHealth() - 1);
                    // Plays the sound.
                    sound.Play();
                }                
            }

            // Checks if the enemy's projectile hits the player.
            if (enemyProjectile.getRectangle().Intersects(player.getRectangle()))
            {
                // Checks if the player's health is greater than 0.
                if (player.getHealth() > 0)
                {
                    // Sets the health of enemy to the current health - 2.
                    player.setHealth(player.getHealth() - 2);
                    // Plays the sound.
                    sound.Play();
                }
            }            
        }
    }
}
