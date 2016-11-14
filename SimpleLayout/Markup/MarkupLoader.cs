using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleLayout.Layout;
using SimpleLayout.Rules;

namespace SimpleLayout.Markup
{
    public static class MarkupLoader
    {
        public delegate void InitialiseElement(ILayoutElement layoutElement);

        public static T Load<T>(InitialiseElement initialiseElement = null)
            where T : class, ILayoutElement, new()
        {
            var type = typeof(T);
            var instance = new T();
            initialiseElement?.Invoke(instance);

            return AddChildFields(instance, initialiseElement) as T;
        }


        private static ILayoutElement AddChildFields(ILayoutElement layoutElement, InitialiseElement initialiseElement = null)
        {
            var type = layoutElement.GetType();
            foreach (var field in type.GetFields())
            {
                if (!typeof(ILayoutElement).IsAssignableFrom(field.FieldType))
                {
                    continue;
                }
                var child = field.GetValue(layoutElement) as ILayoutElement;
                initialiseElement?.Invoke(child);
                ApplyAttributes(field.GetCustomAttributes(true), child);
                // Recurse to child, filling in it's children if it has any.
                AddChildFields(child, initialiseElement);
                layoutElement.Children.Add(child);
                child.Parent = layoutElement;
            }
            foreach (var property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes(true);
                if (!typeof(ILayoutElement).IsAssignableFrom(property.PropertyType)
                    || !attributes.Any(x => x is ElementAttribute))
                {
                    continue;
                }
                var child = property.GetValue(layoutElement, new object[0]) as ILayoutElement;
                initialiseElement?.Invoke(child);
                // Recurse to child, filling in it's children if it has any.
                AddChildFields(child, initialiseElement);
                layoutElement.Children.Add(child);
                ApplyAttributes(attributes, child);
                child.Parent = layoutElement;
            }
            return layoutElement;
        }

        private static void ApplyAttributes(object[] attributes, ILayoutElement layoutElement)
        {
            foreach (var attribute in attributes)
            {
                if (attribute is IStyleRule)
                {
                    layoutElement.StyleRules.Add(attribute as IStyleRule);
                }
            }
        }
    }
}
