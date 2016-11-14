using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Enums;

namespace SimpleLayout.Layout.Standard
{
    public class ColumnLayout : ILayout
    {
        public HorizontalAlign Alignment { get; set; }
        public float Spacing { get; set; }

        public ColumnLayout(HorizontalAlign alignment)
        {
            Alignment = alignment;
        }

        private float _y = 0f;
        private ILayoutElement _container;

        public void Reset(ILayoutElement container)
        {
            _container = container;
            _y = 0f;
        }

        public void Process(ILayoutElement layoutElement)
        {
            switch (Alignment)
            {
                case HorizontalAlign.Left:
                    layoutElement.MoveTo(0f, _y);
                    break;
                case HorizontalAlign.Center:
                    layoutElement.MoveTo((_container.Rectangle.Width - layoutElement.RectangleWithMargin.Width) / 2f, _y);
                    break;
                case HorizontalAlign.Right:
                    layoutElement.MoveTo(_container.Rectangle.Width - layoutElement.RectangleWithMargin.Width, _y);
                    break;
            }
            _y += layoutElement.RectangleWithMargin.Height + Spacing;
        }
    }
}
