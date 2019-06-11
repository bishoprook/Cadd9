using System;
using System.Text;
using System.Text.RegularExpressions;

using Cadd9.Util;

using static Cadd9.Model.Constants;

namespace Cadd9.Model
{
    ///<summary>
    ///  Represents an accidental that shifts some note or pitch by a certain number of semitones away from natural.
    ///</summary>
    public class Accidental : IEquatable<Accidental>
    {
        ///<summary>
        ///  The number of semitones this accidental shifts a pitch or note. Positive values indicate sharps, negative
        ///  values indicate flats.
        ///</summary>
        public int Semitones { get; }

        ///<summary>
        ///  Returns a new Accidental
        ///</summary>
        ///<param name="semitones">The number of semitones this accidental shifts a pitch or note</param>
        public Accidental(int semitones)
        {
            Semitones = semitones;
        }

        ///<summary>
        ///  Returns a string representation of this Accidental, primarily for debugging purposes.
        ///</summary>
        override public string ToString() => $"Accidental[Semitones={Semitones}]";

        ///<summary>
        ///  A formatted representation of this Accidental as a UTF-8 string.
        ///</summary>
        public string Description
        {
            get
            {
                switch(Semitones)
                {
                    case -2: return "𝄫";
                    case 0: return "♮";
                    case 2: return "𝄪";
                }

                var result = new StringBuilder();
                var symbol = Semitones < 0 ? '♭' : '♯';
                var length = Math.Abs(Semitones);
                for (var i = 0; i < length; i++)
                {
                    result.Append(symbol);
                }
                return result.ToString();
            }
        }

        ///<summary>
        ///  Returns true if <c>other</c> is enharmonic with this Accidental.
        ///</summary>
        ///<param name="other">The Accidental to compare with</param>
        ///<remarks>
        ///  Two accidentals are enharmonic if they are equal or if their <c>Semitones</c> differ by an even multiple of
        ///  12. For example 5 sharps is enharmonic with 7 flats: C♯♯♯♯♯ and C♭♭♭♭♭♭♭ are both enharmonic with each
        ///  other and with F natural.
        ///</remarks>
        public bool Enharmonic(Accidental other) =>
            Semitones.Modulus(SEMITONES_PER_OCTAVE) == other.Semitones.Modulus(SEMITONES_PER_OCTAVE);

        ///<summary>
        ///  Returns a new Accidental based on the given input string.
        ///</summary>
        ///<param name="input">The plain ASCII input string to parse</param>
        ///<exception cref="FormatException">The given input cannot be parsed</exception>
        ///<remarks>
        ///  Assumes the input will be in plain ASCII: "b" for flats and "#" for sharps. An empty string or the string
        ///  <c>"nat"</c> may be used for natural.
        ///</remarks>
        public static Accidental Parse(String input)
        {
            if (input.Equals("") || input.Equals("nat"))
            {
                return NATURAL;
            }

            if (Regex.IsMatch(input, "^b+$"))
            {
                return new Accidental(-input.Length);
            }

            if (Regex.IsMatch(input, "^#+$"))
            {
                return new Accidental(input.Length);
            }

            throw new FormatException($"{input} is not a valid accidental");
        }

        #region Value equality

        ///<summary>
        ///  Determines whether two Accidentals are value-equivalent
        ///</summary>
        ///<param name="other">The Accidental to compare</param>
        public bool Equals(Accidental other) => Semitones == other.Semitones;

        private static readonly int HASH_CODE_SEED = 461;
        private static readonly int HASH_CODE_STEP = 211;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Accidentals are guaranteed to produce the
        ///  same result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked {
                return (HASH_CODE_SEED * Semitones) ^ HASH_CODE_STEP;
            }
        }

        #endregion

        #region Typical values
        #pragma warning disable CS1591

        public static readonly Accidental NATURAL = new Accidental(0);
        public static readonly Accidental SHARP = new Accidental(1);
        public static readonly Accidental DOUBLE_SHARP = new Accidental(2);
        public static readonly Accidental FLAT = new Accidental(-1);
        public static readonly Accidental DOUBLE_FLAT = new Accidental(-2);
        
        #pragma warning restore CS1591
        #endregion
    }
}
