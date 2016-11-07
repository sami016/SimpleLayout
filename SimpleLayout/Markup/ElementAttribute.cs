using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLayout.Markup
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class ElementAttribute : Attribute
    {
    }
}
