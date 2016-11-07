using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class SizeAttribute : PreLayoutRule
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public SizeAttribute(float width, float height)
        {
            Width = width;
            Height = height;
        }


        public override void Process(IElement element)
        {
            element.Rectangle.Width = Width;
            element.Rectangle.Height = Height;
        }
    }
}
