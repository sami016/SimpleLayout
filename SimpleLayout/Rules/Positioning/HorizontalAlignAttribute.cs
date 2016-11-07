using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Enums;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    public class HorizontalAlignAttribute : IStyleRule
    {
        public HorizontalAlign Align { get; }

        public HorizontalAlignAttribute(HorizontalAlign align)
        {
            Align = align;
        }

        public void Process(IElement element)
        {
        }
    }
}
