using System;

namespace Cadd9.Util
{
    ///<summary>
    ///  Adds extension methods for some useful integer math
    ///</summary>
    public static class IntExtensions
    {
        ///<summary>
        ///  Returns the value of <c>operand</c> mod <c>modulus</c>
        ///</summary>
        ///<remarks>
        ///  Formally this method returns the least non-negative integer <c>N</c> such that
        ///  <c>operand ≡ N (mod modulus)</c>. It differs from C#'s <c>%</c> operator in its
        ///  treatment of negative values: <c>-1 % 7 == -1</c> while <c>-1.Modulus(7) == 6</c>.
        ///<remarks>
        public static int Modulus(this int operand, int modulus)
        {
            return operand >= 0 ? operand % modulus : modulus + (operand % modulus);
        }

        ///<summary>
        ///  Returns the integer congruent to operand (mod modulus) with smallest absolute value.
        ///</summary>
        ///<remarks>
        ///  The range of this method is <c>[-modulus/2, modulus/2)</c> -- basically the goal is
        ///  to return an integer that is modulo-congruent with operand but is as close as
        ///  possible to zero. Primarily this is used to simplify accidentals as much as
        ///  possible: if we have 11 sharps, a more ideal (and enharmonic) accidental would be
        ///  one flat, represented as -1 and congruent to 11 (mod 12).
        ///</remarks>
        public static int Demodulus(this int operand, int modulus)
        {
            var result = operand.Modulus(modulus);
            return result < modulus / 2 ? result : result - modulus;
        }

        ///<summary>
        ///  Returns a string representation of an integer in ordinal form
        ///</summary>
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