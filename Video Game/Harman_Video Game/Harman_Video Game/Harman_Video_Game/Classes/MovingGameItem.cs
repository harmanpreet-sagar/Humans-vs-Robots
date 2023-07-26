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
    class MovingGameItem : GameItem
    {
        // Declares a SoundEffect variable sound
        protected SoundEffect sound;
        // Declares an int variable speed.
        protected int speed;

        // Creates the MovingGameItem constructor and provides parameters.
        public MovingGameItem(Rectangle rect, Texture2D aTexture, Color color, SoundEffect aSound, int aSpeed) : base(rect, aTexture, color)
        {
            // Sets speed equal to the user entered value of aSpeed.
            this.speed = aSpeed;

            // Sets sound to the user entered value of aSound.
            this.sound = aSound;
        }

        // Creates an Update method to Update the MovingGameItems
        public void Update()
        {
            // Changes the X position of the rectangle based on the set speed.
            this.rectangle.X += speed;
        }

        // Creates a method to get speed.
        public int getSpeed()
        {
            // Returns the value of speed
            return speed;
        }

        // Creates a method to set the value of speed.
        public void setSpeed(int aSpeed)
        {
            // Sets the value of speed to the user entered value of aSpeed.
            speed = aSpeed;
        }
        // Creates a method to get color.
        public SoundEffect getSound()
        {
            // Returns the value of sound.
            return sound;
        }

        // Creates a method to set the value of sound.
        public void setSound(SoundEffect aSound)
        {
            // Sets the value of sound to the user entered value of aSound.
            sound = aSound;
        }
    }
}
