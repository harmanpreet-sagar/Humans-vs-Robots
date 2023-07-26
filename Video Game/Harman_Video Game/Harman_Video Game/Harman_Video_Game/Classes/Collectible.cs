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
    class Collectible: GameItem
    {
        // Creates an int variable collectiblePoints.
        protected int collectiblePoints;

        // Creates the Collectible constructor and provides parameters.
        public Collectible(Rectangle rect, Texture2D aTexture, Color color, int aCollectiblePoints): base(rect, aTexture, color)
        {
            // Sets collectiblePoints to the user set value of aCollectiblePoints.
            this.collectiblePoints = aCollectiblePoints;
        }

        // Creates a method to get collectiblePoints.
        public int getCollectiblePoints()
        {
            // Returns the value of collectiblePoints
            return collectiblePoints;
        }

        // Creates a method to set the value of collectiblePoints.
        public void setCollectiblePoints(int aCollectiblePoints)
        {
            // Sets the value of collectiblePoints to the user entered value of aCollectiblePoints.
            collectiblePoints = aCollectiblePoints;
        }
    }
}
