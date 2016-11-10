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
            float minX = element.Rectangle.x2;
            float minY = element.Rectangle.y2;
            float maxX = 0f;
            float maxY = 0f;
            foreach (var child in element.Children)
            {
                minX = Math.Min(minX, child.RectangleWithMargin.x);
                minY = Math.Min(minY, child.RectangleWithMargin.y);
                maxX = Math.Max(maxX, child.RectangleWithMargin.x2);
                maxY = Math.Max(maxY, child.RectangleWithMargin.y2);
            }
            element.Rectangle.Width = (maxX-minX);
            element.Rectangle.Height = (maxY-minY);
            // Shift elements to be within shrunk container.
            foreach (var child in element.Children)
            {
                child.Rectangle.Translate(-minX, -minY);
            }
        }
    }
}
