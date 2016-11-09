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
            // Sort the rules for each element.
            InitialPass(root, elements);
            // Apply initial styles - usually sizing information.
            StylePass(root, elements, Phase.PRE_LAYOUT);
            // First layout pass - estimate initial positions.
            LayoutPass(root, elements);
            // Use estimated position for mid layout styling. e.g. elastic containers.
            StylePass(root, elements, Phase.MID_LAYOUT);
            // Perform the final layout pass to adjust for mid styling rules.
            LayoutPass(root, elements);
            // Apply final post layout styling.
            StylePass(root, elements, Phase.POST_LAYOUT);
        }

        /// <summary>
        /// Sorts the rules for each element in order of which should be evalutated first.
        /// Resets each elements position.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="elements"></param>
        public void InitialPass(IElement root, IList<IElement> elements)
        {
            foreach (var element in elements)
            {
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    InitialPass(element, element.Children);
                }

                SortStylesForElement(element);
                element.Rectangle.x = 0;
                element.Rectangle.y = 0;
                element.DefaultSizing();
            }
        }

        public void StylePass(IElement root, IList<IElement> elements, Phase phase)
        {
            foreach (var element in elements)
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
                        releventStyles= element.StyleRules.Where(x => x is PostLayoutRule);
                        break;
                }

                foreach (var style in releventStyles)
                {
                    style.Process(element);
                }
                // Recurse for nested elements.
                if (element.Children != null)
                {
                    StylePass(element, element.Children, phase);
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
            element.StyleRules = element.StyleRules.OrderBy(x => _ruleOrdering.IndexOf(x.GetType())).ToList();
        }
    }
}
