using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Util {
    public static class AttributeExtensions
    {
        public static TAttribute GetAttribute<THost, TAttribute>(this THost value)
            where TAttribute : Attribute
        {
            var fields = typeof(THost).GetFields();
            foreach (var field in fields)
            {
                if (field.GetValue(typeof(THost)).Equals(value)) {
                    return field.GetCustomAttribute<TAttribute>();
                }
            }
            return null;
        }
    }
}
