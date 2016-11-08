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

        public void Reset(IElement container)
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

        private void PlaceAtCurrentPosition(IElement element)
        {
            // Update position.
            element.MoveTo(currentX, currentY);
        }

        public void Process(IElement element)
        {
            var size = element.RectangleWithMargin;
            // Calculate the other sides given the current x/y position.
            float rightHandX = currentX + size.Width;
            float bottomY = currentY + size.Height;
            // Attempt to fit element in the current row.
            if (rightHandX > bounds.Width)
            {
                // Element will fit.
                PlaceAtCurrentPosition(element);
                currentX = rightHandX;
                maxRowHeight = Math.Max(maxRowHeight, element.RectangleWithMargin.Height);
                return;
            }
            // Won't fit into row, so move down into new row...
            NewRow();
            PlaceAtCurrentPosition(element);
        }
    }
}
