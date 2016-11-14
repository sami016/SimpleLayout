using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;

namespace SimpleLayout.Layout.Engine
{
    public interface ILayoutEngine
    {
        void PerformLayout(ILayoutElement root, IList<ILayoutElement> elements);
    }
}
