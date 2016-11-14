using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLayout.Layout;

namespace SimpleLayout.Interaction
{
    public class ElementLocator
    {
        /// <summary>
        /// Gets the layoutElement at a given location for an layoutElement and it's descendants.
        /// If no layoutElement is at the location, returns null.
        /// </summary>
        /// <param name="layoutElement">root layoutElement to search from</param>
        /// <param name="xPos">x position</param>
        /// <param name="yPos">y position</param>
        /// <returns></returns>
        public ILayoutElement GetElementAtLocation(ILayoutElement layoutElement, float xPos, float yPos)
        {
            if (layoutElement == null)
            {
                return null;
            }
            var absoluteBounds = layoutElement.Absolute(layoutElement.RectangleWithPadding);
            // Check if click is in bounds.
            if (absoluteBounds.ContainsPoint(xPos, yPos))
            {
                foreach (var child in layoutElement.Children.Reverse())
                {
                    // Recursive check - attempt to resolve layoutElement clicked on for children.
                    var childResult = GetElementAtLocation(child, xPos, yPos);
                    if (childResult != null)
                    {
                        return childResult;
                    }
                }
                // No child layoutElement clicked, so must be parent.
                return layoutElement;
            }
            // No layoutElement clicked on.
            return null;
        }
    }
}
