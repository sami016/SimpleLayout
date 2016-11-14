using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Enums;

namespace SimpleLayout.Layout.Standard
{
    public class RowLayout : ILayout
    {
        public VerticalAlign Alignment { get; set; }
        public float Spacing { get; set; }

        public RowLayout(VerticalAlign alignment)
        {
            Alignment = alignment;
        }

        private float _x;
        private ILayoutElement _container;

        public void Reset(ILayoutElement container)
        {
            _container = container;
            _x = 0f;
        }

        public void Process(ILayoutElement layoutElement)
        {
            switch (Alignment)
            {
                case VerticalAlign.Top:
                    layoutElement.MoveTo(_x, 0f);
                    break;
                case VerticalAlign.Middle:
                    layoutElement.MoveTo(_x, (_container.Rectangle.Height - layoutElement.RectangleWithMargin.Height) / 2f);
                    break;
                case VerticalAlign.Bottom:
                    layoutElement.MoveTo(_x, _container.Rectangle.Height - layoutElement.RectangleWithMargin.Height);
                    break;
            }
            _x += layoutElement.RectangleWithMargin.Width + Spacing;
        }
    }
}
