using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;

namespace SimpleLayout.Layout
{
    public interface ILayout
    {
        void Reset(ILayoutElement container);
        void Process(ILayoutElement layoutElement);
    }
}
