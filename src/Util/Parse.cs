using System;

namespace Util
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ParseAttribute : Attribute
    {
        public string Parse { get; }

        public ParseAttribute(string parse)
        {
            this.Parse = parse;
        }
    }
}