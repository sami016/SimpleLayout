using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules
{
    public abstract class PostLayoutRule : Attribute, IStyleRule
    {
        public abstract void Process(ILayoutElement layoutElement);
    }
}
