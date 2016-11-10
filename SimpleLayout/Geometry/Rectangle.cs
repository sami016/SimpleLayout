using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLayout.Geometry
{
    public class Rectangle 
    {

        /// <summary>
        /// The area of the rectangle.
        /// </summary>
        public float Area => Height * Width;

        /// <summary>
        /// The mean x position of the rectangle.
        /// </summary>
        public float xMean => (x + x2)/2f;

        /// <summary>
        /// The mean y position of the rectangle.
        /// </summary>
        public float YMean => (y + y2)/2f;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public float Height
        {
            get
            {
                return y2 - y;
            }

            set
            {
                y2 = y + value;
            }
        }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public float Width
        {
            get
            {
                return x2 - x;
            }

            set
            {
                x2 = x + value;
            }
        }
        /// <summary>
        /// The x coordinate of the left hand side.
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// The x coordinate of the right hand side.
        /// </summary>
        public float x2 { get; set; }

        /// <summary>
        /// The y coordinate of the top side.
        /// </summary>
        public float y { get; set; }

        /// <summary>
        /// The y coordinate of the bottom side.
        /// </summary>
        public float y2 { get; set; }

        /// <summary>
        /// Moves the rectangle to a given position.
        /// Retains the width and height of the rectangle.
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        public void MoveTo(float xPosition, float yPosition)
        {
            var width = Width;
            var height = Height;

            x = xPosition;
            y = yPosition;
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Translates the rectangle by a given offset.
        /// </summary>
        /// <param name="xOffset">xPos offset</param>
        /// <param name="yOffset">yPos offset</param>
        public void Translate(float xOffset, float yOffset)
        {
            x += xOffset;
            x2 += xOffset;
            y += yOffset;
            y2 += yOffset;
        }

        /// <summary>
        /// Sets the bounds of the rectangle.
        /// </summary>
        /// <param name="xPos">xPos position</param>
        /// <param name="yPos">yPos position</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public void SetBounds(float xPos, float yPos, float width, float height)
        {
            x = xPos;
            y = yPos;
            Width = width;
            Height = height;
        }
    }
}
