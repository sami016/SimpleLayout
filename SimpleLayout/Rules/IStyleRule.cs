using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules
{
    public interface IStyleRule
    {
        void Process(ILayoutElement layoutElement);
    }
}
