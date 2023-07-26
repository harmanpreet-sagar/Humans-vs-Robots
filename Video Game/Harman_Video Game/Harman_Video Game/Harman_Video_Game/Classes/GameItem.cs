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
    class GameItem
    {
        // Declares a Rectangle variable rectangle.
        protected Rectangle rectangle;
        // Declares a Texture2D variable texture.
        protected Texture2D texture;
        // Declares a Color variable clr.
        protected Color clr;
        
        // Creates the GameItem constructor and provides parameters.
        public GameItem(Rectangle rect, Texture2D aTexture, Color color)
        {
            // Sets rectangle to the user entered value of rect.
            this.rectangle = rect;
            // Sets texture to the user entered value of aTexture.
            this.texture = aTexture;
            // Sets clr to the user entered value of color.
            this.clr = color;
        }

        // Creates a method to get rectangle.
        public Rectangle getRectangle()
        {
            // Returns the value of rectangle
            return rectangle;
        }

        // Creates a method to set the value of rectangle.
        public void setRectangle(Rectangle aRect)
        {
            // Sets the value of rectangle to the user entered value of aRect.
            rectangle = aRect;
        }

        // Creates a method to get texture.
        public Texture2D getTexture()
        {
            // Returns the value of texture.
            return texture;
        }

        // Creates a method to set the value of texture.
        public void setTexture(Texture2D aTexture)
        {
            // Sets the value of texture to the user entered value of aTexture.
            texture = aTexture;
        }

        // Creates a method to get color.
        public Color getColor()
        {
            // Returns the value of clr.
            return clr;
        }

        // Creates a method to set the value of clr.
        public void setColor(Color aColor)
        {
            // Sets the value of clr to the user entered value of aColor.
            clr = aColor;
        }
       
        // Creates a method to carry out the hit test among various elements.
        public bool HitTest(Rectangle otherRect)
        {
            // Checks if the rectangle intersects with the other rectangle.
            if (this.rectangle.Intersects(otherRect))
            {
                // Returns true.
                return true;
            }
            // Works if the previous statement is untrue.
            else
            {
                // Returns false.
                return false;
            }
        }

        // Creates a method to draw the sprite (image).
        public void DrawSprite(SpriteBatch spriteBatch)
        {
            // Draws the image.
            spriteBatch.Draw(texture, rectangle, clr);
        }
    }
}
