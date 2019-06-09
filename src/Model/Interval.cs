using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Cadd9.Util;

using static Cadd9.Model.Constants;
using static Cadd9.Model.Name;

namespace Cadd9.Model
{
    ///<summary>
    ///Represents a musical width between notes or pitches.
    ///</summary>
    public class Interval : IEquatable<Interval>
    {
        ///<summary>
        ///The number of note names shifted between the bottom and top of this Interval:
        ///for example a minor third, major third, and augmented third would all have
        ///a Generic value of 2, and when applied to a C with any accidentals will produce
        ///an E with accidentals determined by this Interval's <c>Specific</c> value.
        ///</summary>
        public int Generic { get; }

        ///<summary>
        ///The number of semitones shifted between the bottom and top of this Interval.
        ///For example, a minor third and augmented second both have a Specific value of 3,
        ///because both move up 3 semitones, like from C to E♭/D♯ respectively.
        ///</summary>
        public int Specific { get; }

        ///<summary>
        ///Creates an Interval with the given generic and specific widths.
        ///</summary>
        ///<param name="generic">The number of note names spanned by the interval</param>
        ///<param name="specific">The number of semitones spanned by the interval</param>
        public Interval(int generic, int specific)
        {
            this.Generic = generic;
            this.Specific = specific;
        }

        ///<summary>
        ///A string representation of this Interval, useful for debugging.
        ///</summary>
        override public string ToString() => $"Interval[Generic={Generic}, Specific={Specific}]";

        ///<summary>
        ///A long-form formatted description of the interval, like "Perfect Fourth"
        ///</summary>
        public string Description
        {
            get
            {
                var intervalDiff = Specific.Modulus(SEMITONES_PER_OCTAVE) -
                    MAJOR_SPECIFIC_INTERVAL[Generic.Modulus(NAMES_PER_OCTAVE)];
                
                var lookup = IS_PERFECT[Generic.Modulus(NAMES_PER_OCTAVE)] ?
                    PERFECT_MODIFIERS : IMPERFECT_MODIFIERS;
                
                return $"{lookup[intervalDiff]} {GenericIntervalName(Generic)}";
            }
        }

        ///<summary>
        ///A short formatted description of the interval, like "P4"
        ///</summary>
        public string Abbreviation
        {
            get
            {
                var intervalDiff = Specific.Modulus(SEMITONES_PER_OCTAVE) -
                    MAJOR_SPECIFIC_INTERVAL[Generic.Modulus(NAMES_PER_OCTAVE)];
                
                var lookup = IS_PERFECT[Generic.Modulus(NAMES_PER_OCTAVE)] ?
                    PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
                
                return $"{lookup[intervalDiff]}{Generic + 1}";
            }
        }

        ///<summary>
        ///Returns the name of an interval with the given generic width, for example
        ///0 -> "Unison", 4 -> "Fifth", 22 -> "23rd"
        ///</summary>
        private static string GenericIntervalName(int generic) =>
            generic < GENERIC_INTERVAL_NAMES.Length ?
                GENERIC_INTERVAL_NAMES[generic] :
                (generic + 1).Ordinal();

        ///<summary>
        ///Parses the given input using "formal" notation: "P4" for a perfect fourth, "m3" for a
        ///minor third, etc. Returns null if the input cannot be parsed accordingly.
        ///</summary>
        ///<exception cref="ArgumentException">If an illegal modifier is supplied for the interval</exception>
        private static Interval ParseFormal(string input)
        {
            var match = Regex.Match(input, @"^([PdmMA])(\d+)$");
            if (!match.Success)
            {
                return null;
            }

            var generic = int.Parse(match.Groups[2].Value) - 1;
            var isPerfect = IS_PERFECT[generic.Modulus(NAMES_PER_OCTAVE)];
            
            var modifierPart = match.Groups[1].Value;
            if (isPerfect && (modifierPart.Equals("m") || modifierPart.Equals("M")))
            {
                throw new ArgumentException($"{GenericIntervalName(generic)} is a perfect interval");
            }
            if (!isPerfect && (modifierPart.Equals("P")))
            {
                throw new ArgumentException($"{GenericIntervalName(generic)} is not a perfect interval");
            }

            var lookup = isPerfect ? PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
            var modifier = lookup.Where(kvp => kvp.Value.Equals(modifierPart)).First().Key;

            var specific = SEMITONES_PER_OCTAVE * (generic / NAMES_PER_OCTAVE) +
                MAJOR_SPECIFIC_INTERVAL[generic.Modulus(NAMES_PER_OCTAVE)] +
                modifier;

            return new Interval(generic, specific);
        }

        ///<summary>
        ///Parses the given input using "simple" notation: "3" for a major third, "b5" for a flat fifth,
        ///etc. This format is commonly used to describe the component intervals of chords.
        ///</summary>
        private static Interval ParseSimple(string input)
        {
            var match = Regex.Match(input, @"^([b#]*)(\d+)$");
            if (!match.Success)
            {
                return null;
            }

            var generic = int.Parse(match.Groups[2].Value) - 1;
            
            var modifierPart = match.Groups[1].Value;
            var accidental = Accidental.Parse(modifierPart);

            var specific = SEMITONES_PER_OCTAVE * (generic / NAMES_PER_OCTAVE) +
                MAJOR_SPECIFIC_INTERVAL[generic.Modulus(NAMES_PER_OCTAVE)] +
                accidental.Semitones;

            return new Interval(generic, specific);
        }

        ///<summary>
        ///Returns a new Interval by parsing the given string input. Two formats are accepted:
        ///Formal, like <c>P4</c> and </c>d3</c>, or simple, like <c>b5</c> and <c>#9</c>. If
        ///the simple form is used, then the major/perfect matching interval is sharped the
        ///given number of times. The formal form understands (P)erfect, (d)iminished,
        ///(m)inor, (M)ajor, and (A)ugmented descriptors for each interval.
        ///</summary>
        ///<param name="input">The input to parse</param>
        ///<exception cref="FormatException">The given input cannot be parsed</exception>
        ///<exception cref="ArgumentException">If an illegal modifier is supplied for the interval</exception>
        public static Interval Parse(string input)
        {
            var formal = ParseFormal(input);
            if (formal != null)
            {
                return formal;
            }

            var simple = ParseSimple(input);
            if (simple != null)
            {
                return simple;
            }
            
            throw new FormatException("Unrecognized interval: " + input);
        }

        ///<summary>
        ///Returns true if <c>other</c> is enharmonically equivalent to this interval, or in
        ///other words, the two intervals have the same specific width. Perfect unison and
        ///diminished second, for example, are enharmonic despite having different generic
        ///widths.
        ///</summary>
        ///<param name="other">The other Interval to compare</param>
        public bool Enharmonic(Interval other) => Specific == other.Specific;

        ///<summary>
        ///Returns a new Interval representing the width between two <c>Name</c>s. It is
        ///always assumed that the interval is going up from first to second: C to B would
        ///give an interval of a major seventh (despite being much closer to go down a
        ///minor second). Also for this reason, this method will always produce an interval
        ///between unison (inclusive) and an octave (exclusive).
        ///</summary>
        ///<param name="first">The lower Name to compare</param>
        ///<param name="second">The higher Name to compare</param>
        public static Interval Between(Name first, Name second)
        {
            var generic = (second - first).Modulus(NAMES_PER_OCTAVE);
            var specific = (MAJOR_SPECIFIC_INTERVAL[(int) second] - MAJOR_SPECIFIC_INTERVAL[(int) first])
                .Modulus(SEMITONES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        ///<summary>
        ///Returns a new Interval representing the width between two <c>Note</c>s. It is
        ///always assumed that the interval is going up from first to second: C♯ to B would
        ///give an interval of a minor seventh (despite being much closer to go down a
        ///major second). Also for this reason, this method will always produce an interval
        ///between unison (inclusive) and an octave (exclusive).
        ///</summary>
        ///<param name="first">The lower Note to compare</param>
        ///<param name="second">The higher Note to compare</param>
        public static Interval Between(Note first, Note second)
        {
            int generic = (second.Name - first.Name).Modulus(NAMES_PER_OCTAVE);
            int firstPC = MAJOR_SPECIFIC_INTERVAL[(int) first.Name] + first.Accidental.Semitones;
            int secondPC = MAJOR_SPECIFIC_INTERVAL[(int) second.Name] + second.Accidental.Semitones;
            int specific = (secondPC - firstPC).Modulus(SEMITONES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        ///<summary>
        ///Returns a new Interval representing the width between two <c>Pitch</c>es. It is
        ///always assumed that the interval is going up from first to second: C♯3 to B4 would
        ///give an interval of a minor fifteenth.
        ///</summary>
        ///<param name="first">The lower Pitch to compare</param>
        ///<param name="second">The higher Pitch to compare</param>
        public static Interval Between(Pitch first, Pitch second)
        {
            int specific = second.Midi - first.Midi;
            int generic = (second.Note.Name - first.Note.Name).Modulus(NAMES_PER_OCTAVE) +
                ((specific / SEMITONES_PER_OCTAVE) * NAMES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        ///<summary>
        ///Creates a new compound Interval by combining two others. For example, adding together
        ///a perfect octave and a perfect fifth produces a perfect thirteenth.
        ///</summary>
        public static Interval operator +(Interval a, Interval b) =>
            new Interval(a.Generic + b.Generic, a.Specific + b.Specific);

        ///<summary>
        ///Creates a new compound Interval by subtracting one from the other. For example,
        ///subtracting a minor second from a perfect octave produces a major seventh.
        ///</summary>
        public static Interval operator-(Interval a, Interval b) =>
            new Interval(a.Generic - b.Generic, a.Specific - b.Specific);

        #region Internal constants

        private static readonly bool[] IS_PERFECT = new bool[] {true, false, false, true, true, false, false};

        private static readonly int[] MAJOR_SPECIFIC_INTERVAL = new int[] {0, 2, 4, 5, 7, 9, 11};

        private static readonly string[] GENERIC_INTERVAL_NAMES = new string[]
        {
            "Unison", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh",
            "Octave", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth"
        };

        private static readonly Dictionary<int, string> PERFECT_MODIFIERS = new Dictionary<int, string>()
        {
            [-1] = "Diminished", [0] = "Perfect", [1] = "Augmented"
        };

        private static readonly Dictionary<int, string> PERFECT_ABBREVIATIONS = new Dictionary<int, string>()
        {
            [-1] = "d", [0] = "P", [1] = "A"
        };

        private static readonly Dictionary<int, string> IMPERFECT_MODIFIERS = new Dictionary<int, string>()
        {
            [-2] = "Diminished", [-1] = "Minor", [0] = "Major", [1] = "Augmented"
        };

        private static readonly Dictionary<int, string> IMPERFECT_ABBREVIATIONS = new Dictionary<int, string>()
        {
            [-2] = "d", [-1] = "m", [0] = "M", [1] = "A"
        };

        #endregion

        #region Value equality
        ///<summary>
        ///Determines whether two Intervals are value-equivalent
        ///</summary>
        ///<param name="other">The Intervals to compare</param>
        public bool Equals(Interval other) =>
            Generic == other.Generic && Specific == other.Specific;

        private static readonly int HASH_CODE_SEED = 59;
        private static readonly int HASH_CODE_STEP = 223;

        ///<summary>
        ///Produces a high-entropy hash code such that two value-equivalent
        ///Intervals are guaranteed to produce the same result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                hashCode = (HASH_CODE_STEP * hashCode) ^ Generic;
                hashCode = (HASH_CODE_STEP * hashCode) ^ Specific;
                return hashCode;
            }
        }

        #endregion

        #region Typical values

        public static readonly Interval PERFECT_UNISON = new Interval(0, 0);
        public static readonly Interval DIMINISHED_SECOND = new Interval(1, 0);
        public static readonly Interval MINOR_SECOND = new Interval(1, 1);
        public static readonly Interval MAJOR_SECOND = new Interval(1, 2);
        public static readonly Interval AUGMENTED_SECOND = new Interval(1, 3);
        public static readonly Interval MINOR_THIRD = new Interval(2, 3);
        public static readonly Interval MAJOR_THIRD = new Interval(2, 4);
        public static readonly Interval DIMINISHED_FOURTH = new Interval(3, 4);
        public static readonly Interval PERFECT_FOURTH = new Interval(3, 5);
        public static readonly Interval AUGMENTED_FOURTH = new Interval(3, 6);
        public static readonly Interval DIMINISHED_FIFTH = new Interval(4, 6);
        public static readonly Interval PERFECT_FIFTH = new Interval(4, 7);
        public static readonly Interval MINOR_SIXTH = new Interval(5, 8);
        public static readonly Interval MAJOR_SIXTH = new Interval(5, 9);
        public static readonly Interval DIMINISHED_SEVENTH = new Interval(6, 9);
        public static readonly Interval MINOR_SEVENTH = new Interval(6, 10);
        public static readonly Interval MAJOR_SEVENTH = new Interval(6, 11);
        public static readonly Interval PERFECT_OCTAVE = new Interval(7, 12);
        public static readonly Interval MAJOR_NINTH = new Interval(8, 14);
        public static readonly Interval PERFECT_ELEVENTH = new Interval(10, 17);
        public static readonly Interval MAJOR_THIRTEENTH = new Interval(12, 21);
        public static readonly Interval PERFECT_FIFTEENTH = new Interval(14, 24);

        #endregion
    }
}