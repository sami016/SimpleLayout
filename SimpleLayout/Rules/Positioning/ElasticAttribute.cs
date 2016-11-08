using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLayout.Geometry;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    public class ElasticAttribute : MidLayoutRule
    {


        public override void Process(IElement element)
        {
            float maxX = 0f;
            float maxY = 0f;
            foreach (var child in element.Children)
            {
                maxX = Math.Max(maxX, child.RectangleWithMargin.x2);
                maxY = Math.Max(maxY, child.RectangleWithMargin.y2);
            }
            element.Rectangle.Width = maxX;
            element.Rectangle.Height = maxY;
        }
    }
}
