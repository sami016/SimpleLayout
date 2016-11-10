using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;
using SimpleLayout.Rules;
using SimpleLayout.Rules.Positioning;

namespace SimpleLayout.Layout.Engine
{
    public class LayoutEngine : ILayoutEngine
    {
        public enum Phase
        {
            PRE_LAYOUT,
            MID_LAYOUT,
            POST_LAYOUT
        }

        private readonly IList<Type> _ruleOrdering;

        public LayoutEngine()
        {
            _ruleOrdering = new List<Type>();

            // Positioning
            _ruleOrdering.Add(typeof(OffsetAttribute));
            _ruleOrdering.Add(typeof(SizeAttribute));
        }

        public void PerformLayout(IElement root, IList<IElement> elements)
        {
            // Sort the rules for each element, also applies pre layout styling.
            InitialPass(root, elements);
            // First layout pass - estimate initial positions.
            LayoutPass(root, elements);
            // Perform the final layout pass to adjust for mid styling rules.
            //SecondLayoutPass(root, elements);
            // Apply final post layout styling.
            FinalStylePass(root, elements);
        }

        /// <summary>
        /// Sorts the rules for each element in order of which should be evalutated first.
        /// Resets each elements position.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="elements"></param>
        // Initial pass is applied from the top down.
        public void InitialPass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                SortStylesForElement(element);
                element.Rectangle.x = 0;
                element.Rectangle.y = 0;
                element.DefaultSizing();
                StyleElement(element, Phase.PRE_LAYOUT);
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    InitialPass(element, element.Children);
                }
            }
        }

        private void StyleElement(IElement element, Phase phase)
        {
            IEnumerable<IStyleRule> releventStyles = null;
            switch (phase)
            {
                case Phase.PRE_LAYOUT:
                    releventStyles = element.StyleRules.Where(x => x is PreLayoutRule);
                    break;
                case Phase.MID_LAYOUT:
                    releventStyles = element.StyleRules.Where(x => x is MidLayoutRule);
                    break;
                case Phase.POST_LAYOUT:
                    releventStyles = element.StyleRules.Where(x => x is PostLayoutRule);
                    break;
            }

            foreach (var style in releventStyles)
            {
                style.Process(element);
            }
        }

        // Style pass is applied from the bottom up.
        public void FinalStylePass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    FinalStylePass(element, element.Children);
                }
                StyleElement(root, Phase.POST_LAYOUT);
            }
        }

        // Layout pass is performed from the bottom up.
        public void LayoutPass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                LayoutPass(element, element.Children);
            }
            // Apply layout to parent after children.
            root.Layout.Reset(root);
            foreach (var element in elements)
            {
                StyleElement(element, Phase.MID_LAYOUT);
                root.Layout.Process(element);
            }
        }


        private void SortStylesForElement(IElement element)
        {
            element.StyleRules = element.StyleRules.OrderBy(x => _ruleOrdering.IndexOf(x.GetType())).ToList();
        }
    }
}
