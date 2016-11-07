using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;
using SimpleLayout.Rules.Positioning;

namespace SimpleLayout.Layout.Engine
{
    public class LayoutEngine : ILayoutEngine
    {
        IList<Type> ruleOrdering;

        public LayoutEngine()
        {
            ruleOrdering = new List<Type>();

            // Positioning
            ruleOrdering.Add(typeof(OffsetAttribute));
            ruleOrdering.Add(typeof(SizeAttribute));
        }

        public void PerformLayout(IElement root, IList<IElement> elements)
        {
            // Sort the rules for each element.
            InitialPass(root, elements);
            StylePass(root, elements);
            LayoutPass(root, elements);
        }

        /// <summary>
        /// Sorts the rules for each element in order of which should be evalutated first.
        /// Resets each elements position.
        /// </summary>
        /// <param name="elements"></param>
        public void InitialPass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                SortStylesForElement(element);
                element.Rectangle.x = 0;
                element.Rectangle.y = 0;
                element.DefaultSizing();
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    InitialPass(element, element.Children);
                }
            }
        }

        public void StylePass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                foreach (var style in element.StyleRules)
                {
                    style.Process(element);
                }
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    StylePass(element, element.Children);
                }
            }
        }

        public void LayoutPass(IElement root, IList<IElement> elements)
        {
            root.Layout.Reset(root);
            foreach (var element in elements)
            {
                root.Layout.Process(element);
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    LayoutPass(element, element.Children);
                }
            }
        }

        private void SortStylesForElement(IElement element)
        {
            element.StyleRules = element.StyleRules.OrderBy(x => ruleOrdering.IndexOf(x.GetType())).ToList();
        }
    }
}
