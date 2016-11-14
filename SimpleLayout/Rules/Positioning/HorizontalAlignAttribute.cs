using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Enums;
using SimpleLayout.Layout;

namespace SimpleLayout.Rules.Positioning
{
    public class HorizontalAlignAttribute : PostLayoutRule
    {
        public HorizontalAlign Align { get; }

        public HorizontalAlignAttribute(HorizontalAlign align)
        {
            Align = align;
        }

        public override void Process(ILayoutElement layoutElement)
        {
        }
    }
}
