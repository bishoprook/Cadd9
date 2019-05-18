using System;

namespace Util
{
    public class DescribeAttribute : Attribute
    {
        public string Descriptor { get; }

        public DescribeAttribute(string descriptor)
        {
            this.Descriptor = descriptor;
        }
    }
}
