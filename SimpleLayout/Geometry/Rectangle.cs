using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLayout.Geometry
{
    public class Rectangle 
    {
        private float _x = 0f;
        private float _y = 0f;
        private float _x2 = 0f;
        private float _y2 = 0f;

        public float Area
        {
            get
            {
                return Height * Width;
            }
        }

        public float xMean
        {
            get { return (_x + _x2)/2f; }
        }

        public float yMean
        {
            get { return (_y + _y2)/2f; }
        }


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

        public float x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float x2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public float y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        public void MoveTo(float x, float y)
        {
            float width = Width;
            float height = Height;

            _x = x;
            _y = y;
            Height = height;
            Width = width;
        }

        public void Translate(float xOffset, float yOffset)
        {
            _x += xOffset;
            _x2 += xOffset;
            _y += yOffset;
            _y2 += yOffset;
        }


        public void SetBounds(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            Width = width;
            Height = height;
        }
    }
}
