using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Enums;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class VerticalAlignAttribute : Attribute, IStyleRule
    {
        public VerticalAlign Align { get; }

        public VerticalAlignAttribute(VerticalAlign align)
        {
            Align = align;
        }

        public void Process(IElement element)
        {
        }
    }
}
