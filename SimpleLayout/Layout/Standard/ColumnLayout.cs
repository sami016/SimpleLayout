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
        private IElement _container;

        public void Reset(IElement container)
        {
            _container = container;
            _y = 0f;
        }

        public void Process(IElement element)
        {
            switch (Alignment)
            {
                case HorizontalAlign.Left:
                    element.MoveTo(0f, _y);
                    break;
                case HorizontalAlign.Center:
                    element.MoveTo((_container.Rectangle.Width - element.Rectangle.Width) / 2f, _y);
                    break;
                case HorizontalAlign.Right:
                    element.MoveTo(_container.Rectangle.Width - element.Rectangle.Width, _y);
                    break;
            }
            _y += element.RectangleWithMargin.Height + Spacing;
        }
    }
}
