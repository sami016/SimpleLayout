using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class PaddingAttribute : Attribute, IStyleRule
    {
        protected SurroundSpacing Padding { get; }

        public PaddingAttribute(float left = 0, float right = 0, float top = 0, float bottom = 0)
        {
            Padding = new SurroundSpacing
            {
                Left = left,
                Right = right,
                Top = top,
                Bottom = bottom
            };
        }

        public void Process(IElement element)
        {
            element.Padding = Padding;
        }
    }
}
