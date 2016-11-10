# Simple Layout

A simple layout library intended for the implementation of a user interface system.

## Interfaces:

`IStyleRule` : 
    'Style' rules that are applied to an interface element using an attribute.

 `IElement` :
    An element within the interface that has a position. 
    Elements use the box model, with a contained space surrounded by padding and margin.
    Elements may contain children, allowing for nesting of interfaces.

 `ILayoutEngine` : 
    Component that performs the layout run for an interface.
    An individual element should implement `RefreshLayout()` to perform a local layout run for the element and it's children.
    
  `ILayout` : 
    Applied to elements to determine how their child elements are arranged.
    A set of standard layouts are provided with this library.

## Standard Layouts:

 - ColumnLayout
 - RowLayout
 - PassiveLayout
 - FlowLayout
 - SwitchLayout :
    For a container for rendering a single element. 
    One of multiple children are selected for viewing.
    Useful for tab systems.