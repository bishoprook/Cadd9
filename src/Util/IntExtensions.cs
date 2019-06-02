using System;

namespace Cadd9.Util
{
    public static class IntExtensions
    {
        public static int Modulus(this int operand, int modulus)
        {
            return operand >= 0 ? operand % modulus : modulus + (operand % modulus);
        }

        // What a weird method
        public static int Demodulus(this int operand, int modulus)
        {
            var result = operand.Modulus(modulus);
            return result < modulus / 2 ? result : result - modulus;
        }

        public static string Ordinal(this int n)
        {
            switch(n % 100)
            {
                case 11:
                case 12:
                case 13:
                    return $"{n}th";
            }

            switch(n % 10)
            {
                case 1:
                    return $"{n}st";
                case 2:
                    return $"{n}nd";
                case 3:
                    return $"{n}rd";
                default:
                    return $"{n}th";
            }
        }
    }
}