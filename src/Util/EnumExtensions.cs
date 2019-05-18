using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public static class EnumExtensions
    {
        public static T ParseEnum<T>(this string input)
            where T : Enum
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                foreach (ParseAttribute parse in value.GetAttributes<ParseAttribute>())
                {
                    if (parse.Parse.Equals(input))
                    {
                        return value;
                    }
                }
            }
            throw new FormatException("Unrecognized input: " + input);
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            return value.GetAttributes<TAttribute>().FirstOrDefault();
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttributes<TAttribute>();
        }
        public static string Describe(this Enum value)
        {
            return value.GetAttribute<DescribeAttribute>().Descriptor;
        }
    }
}