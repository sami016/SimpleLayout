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

        public RowLayout(VerticalAlign alignment)
        {
            Alignment = alignment;
        }

        private float _x = 0f;
        private IElement _container;

        public void Reset(IElement container)
        {
            _container = container;
        }

        public void Process(IElement element)
        {
            switch (Alignment)
            {
                case VerticalAlign.Top:
                    element.MoveTo(_x, 0f);
                    break;
                case VerticalAlign.Middle:
                    element.MoveTo(_x, (_container.Rectangle.Height - element.Rectangle.Height) / 2f);
                    break;
                case VerticalAlign.Bottom:
                    element.MoveTo(_x, _container.Rectangle.Height - element.Rectangle.Height);
                    break;
            }
            _x += element.RectangleWithMargin.Width;
        }
    }
}
