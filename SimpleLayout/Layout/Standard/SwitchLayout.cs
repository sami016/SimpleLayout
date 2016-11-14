using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLayout.Layout.Standard
{
    /// <summary>
    /// Layout in which a single configured item is displayed.
    /// 
    /// Recommended to be used with a constant size to avoid confusion.
    /// </summary>
    public class SwitchLayout : ILayout
    {
        public ILayoutElement Active { get; set; }

        public SwitchLayout()
        {
            Active = null;
        }

        public void Reset(ILayoutElement container)
        {
            if (Active == null)
            {
                Active = container.Children.First() ?? null;
            }
        }

        public void Process(ILayoutElement layoutElement)
        {
            layoutElement.Rectangle.x = 0f;
            layoutElement.Rectangle.y = 0f;
            layoutElement.Visible = layoutElement == Active;
        }
    }
}
