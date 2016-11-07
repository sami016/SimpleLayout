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
        public delegate void InitialiseElement(IElement element);

        public static T Load<T>(InitialiseElement initialiseElement = null)
            where T : class, IElement, new()
        {
            var type = typeof(T);
            var instance = new T();
            initialiseElement?.Invoke(instance);

            return AddChildFields(instance, initialiseElement) as T;
        }


        private static IElement AddChildFields(IElement element, InitialiseElement initialiseElement = null)
        {
            var type = element.GetType();
            foreach (var field in type.GetFields())
            {
                if (!typeof(IElement).IsAssignableFrom(field.FieldType))
                {
                    continue;
                }
                var child = field.GetValue(element) as IElement;
                initialiseElement?.Invoke(child);
                ApplyAttributes(field.GetCustomAttributes(true), child);
                // Recurse to child, filling in it's children if it has any.
                AddChildFields(child, initialiseElement);
                element.Children.Add(child);
                child.Parent = element;
            }
            foreach (var property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes(true);
                if (!property.PropertyType.IsAssignableFrom(typeof(IElement))
                    || !attributes.Any(x => x is ElementAttribute))
                {
                    continue;
                }
                var child = property.GetValue(element, new object[0]) as IElement;
                initialiseElement?.Invoke(child);
                // Recurse to child, filling in it's children if it has any.
                AddChildFields(child, initialiseElement);
                element.Children.Add(child);
                ApplyAttributes(attributes, child);
                child.Parent = element;
            }
            return element;
        }

        private static void ApplyAttributes(object[] attributes, IElement element)
        {
            foreach (var attribute in attributes)
            {
                if (attribute is IStyleRule)
                {
                    element.StyleRules.Add(attribute as IStyleRule);
                }
            }
        }
    }
}
