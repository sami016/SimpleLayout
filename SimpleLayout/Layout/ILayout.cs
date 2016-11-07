using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;

namespace SimpleLayout.Layout
{
    public interface ILayout
    {
        void Reset(IElement container);
        void Process(IElement element);
    }
}
