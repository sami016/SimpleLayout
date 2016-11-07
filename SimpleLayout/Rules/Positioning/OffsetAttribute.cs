using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class OffsetAttribute : Attribute, IStyleRule
    {
        public float xOffset { get; set; }
        public float yOffset { get; set; }

        public OffsetAttribute(float xOffset, float yOffset)
        {
            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        public void Process(IElement element)
        {
            element.Rectangle.Translate(xOffset, yOffset);
        }
    }
}
