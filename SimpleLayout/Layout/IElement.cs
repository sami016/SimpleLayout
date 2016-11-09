using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLayout.Geometry;
using SimpleLayout.Rules;

namespace SimpleLayout.Layout
{

    public interface IElement
    {
        /// <summary>
        /// The element's styling.
        /// </summary>
        IList<IStyleRule> StyleRules { set;  get; }

        /// <summary>
        /// The element's position and size.
        /// Position is relative to the parent's position.
        /// </summary>
        Rectangle Rectangle { set;  get; }

        /// <summary>
        /// Determines the element's visibility.
        /// If false, no render will be performed.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Margin spacing.
        /// </summary>
        SurroundSpacing Margin { get; set; }

        /// <summary>
        /// Padding spacing.
        /// </summary>
        SurroundSpacing Padding { get; set; }

        /// <summary>
        /// The element's size and position including padding.
        /// Read only property, change by altering padding.
        /// </summary>
        Rectangle RectangleWithPadding { get; }

        /// <summary>
        /// The element's size and positiong including margin.
        /// Read only property, change by altering pagging and margin.
        /// </summary>
        Rectangle RectangleWithMargin { get; }

        /// <summary>
        /// Converts a rectangle from it's relative position to it's absolute position for this element.
        /// </summary>
        Rectangle Absolute(Rectangle rectangle);

        /// <summary>
        /// Moves an element to a given position, taking padding and margin into account.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        void MoveTo(float x, float y);

        /// <summary>
        /// The element's layout, only applicable if it has children.
        /// </summary>
        ILayout Layout { set;  get; }

        /// <summary>
        /// Element's children elements.
        /// </summary>
        IList<IElement> Children { get; set; }

        /// <summary>
        /// The element's parent. 
        /// Null for root elements.
        /// </summary>
        IElement Parent { get; set; }

        /// <summary>
        /// Initialises the elements sizing before layout or style are applied.
        /// </summary>
        void DefaultSizing();

        /// <summary>
        /// Refreshes the layout for this element and it's children.
        /// </summary>
        void RefreshLayout();
    }
}
