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
    class Weapon: Collectible
    {
        // Creates an int variable ammoCount.
        private int ammoCount;
        // Creates an int variable timeDelay.
        private int timeDelay;

        // Creates the Weapon constructor and provides parameters.
        public Weapon(Rectangle rect, Texture2D aTexture, Color color, SoundEffect sound, int aCollectiblePoints, int aAmmoCount, int delay): base(rect, aTexture, color, aCollectiblePoints)
        {
            // Sets ammoCount equal to the user entered value of aAmmoCount.
            this.ammoCount = aAmmoCount;
            // Sets timeDelay equal to the user entered value of delay.
            this.timeDelay = delay;
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
    }
}
