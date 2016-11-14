using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class MarginAttribute : PreLayoutRule
    {
        protected SurroundSpacing Margin { get; }

        public MarginAttribute(float left = 0, float right = 0, float top = 0, float bottom = 0)
        {
            Margin = new SurroundSpacing
            {
                Left = left,
                Right = right,
                Top = top,
                Bottom = bottom
            };
        }

        public override void Process(ILayoutElement layoutElement)
        {
            layoutElement.Margin = Margin;
        }
    }
}
