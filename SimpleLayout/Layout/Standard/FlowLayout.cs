using System;
using SimpleLayout.Geometry;

namespace SimpleLayout.Layout.Standard
{
    /// <summary>
    /// Standard flow layout - elements fill in from left to right/top to bottom.
    /// </summary>
    public class FlowLayout : ILayout
    {
        private float currentX;
        private float currentY;
        private float maxRowHeight = 0f;
        private Rectangle bounds;

        public void Reset(ILayoutElement container)
        {
            bounds = container.Rectangle;
            currentX = 0f;
            currentY = 0f;
            maxRowHeight = 0f;
        }

        private void NewRow()
        {
            currentX = 0f;
            currentY += maxRowHeight;
            maxRowHeight = 0f;
        }

        private void PlaceAtCurrentPosition(ILayoutElement layoutElement)
        {
            // Update position.
            layoutElement.MoveTo(currentX, currentY);
        }

        public void Process(ILayoutElement layoutElement)
        {
            var size = layoutElement.RectangleWithMargin;
            // Calculate the other sides given the current x/y position.
            float rightHandX = currentX + size.Width;
            float bottomY = currentY + size.Height;
            // Attempt to fit layoutElement in the current row.
            if (rightHandX > bounds.Width)
            {
                // Element will fit.
                PlaceAtCurrentPosition(layoutElement);
                currentX = rightHandX;
                maxRowHeight = Math.Max(maxRowHeight, layoutElement.RectangleWithMargin.Height);
                return;
            }
            // Won't fit into row, so move down into new row...
            NewRow();
            PlaceAtCurrentPosition(layoutElement);
        }
    }
}
