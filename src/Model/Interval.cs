using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Cadd9.Util;

using static Cadd9.Model.Name;
using static Cadd9.Model.Interval.Generic;
using static Cadd9.Model.Constants;

namespace Cadd9.Model
{
    ///<summary>
    ///  Represents a musical width between notes or pitches.
    ///</summary>
    public class Interval : IEquatable<Interval>
    {
        ///<summary>
        ///  Represents a generic interval between two notes or pitches independent of semitone width
        ///</summary>
        ///<remarks>
        ///  For instance, the generic interval between any F and any A is always a third. From F to A♯ is an augmented
        ///  third (5 semitones), and from F to A♭ is a minor third (3 semitones) but the generic interval is always a
        ///  third. In other words, this is the number of note names shifted from the bottom to top of the interval.
        ///</remarks>
        public enum Generic : int
        {
            #pragma warning disable CS1591
            UNISON, SECOND, THIRD, FOURTH, FIFTH, SIXTH, SEVENTH, OCTAVE, NINTH, TENTH, ELEVENTH, TWELFTH, THIRTEENTH,
            FOURTEENTH, FIFTEENTH
            #pragma warning restore CS1591
        }

        ///<summary>
        ///  The generic width of this Interval, in other words, the difference in note names from bottom to top.
        ///</summary>
        public Generic GenericWidth { get; }

        ///<summary>
        ///  The specific width of this Interval, in other words, the semitones shifted between the bottom and top.
        ///</summary>
        public int SpecificWidth { get; }

        ///<summary>
        ///  Creates an Interval with the given generic and specific widths.
        ///</summary>
        ///<param name="genericWidth">The number of note names spanned by the interval</param>
        ///<param name="specificWidth">The number of semitones spanned by the interval</param>
        public Interval(Generic genericWidth, int specificWidth)
        {
            GenericWidth = genericWidth;
            SpecificWidth = specificWidth;
        }

        ///<summary>
        ///  A string representation of this Interval, useful for debugging.
        ///</summary>
        override public string ToString() => $"Interval[Generic={GenericWidth}, Specific={SpecificWidth}]";

        ///<summary>
        ///  Returns the generic width from unison to seventh that is enharmonic with the given generic width
        ///</summary>
        private static Generic ReducedGenericWidth(Generic generic) =>
            (Generic) ((int) generic).Modulus(NAMES_PER_OCTAVE);

        ///<summary>
        ///  Returns the name of the given generic width
        ///</summary>
        private static string GenericName(Generic generic) =>
            GENERIC_NAMES.ContainsKey(generic) ? GENERIC_NAMES[generic] : ((int)generic + 1).Ordinal();

        ///<summary>
        ///  A long-form formatted description of the interval, like "Perfect Fourth"
        ///</summary>
        public string Description
        {
            get
            {
                var reducedGeneric = ReducedGenericWidth(GenericWidth);
                var intervalDiff = SpecificWidth.Modulus(SEMITONES_PER_OCTAVE) - MAJOR_SEMITONES[reducedGeneric];
                var modifiers = IS_PERFECT[reducedGeneric] ? PERFECT_MODIFIERS : IMPERFECT_MODIFIERS;
                return $"{modifiers[intervalDiff]} {GenericName(GenericWidth)}";
            }
        }

        ///<summary>
        ///  A short formatted description of the interval, like "P4"
        ///</summary>
        public string Abbreviation
        {
            get
            {
                var reducedGeneric = ReducedGenericWidth(GenericWidth);
                var intervalDiff = SpecificWidth.Modulus(SEMITONES_PER_OCTAVE) - MAJOR_SEMITONES[reducedGeneric];
                var modifiers = IS_PERFECT[reducedGeneric] ? PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
                return $"{modifiers[intervalDiff]}{(int)GenericWidth + 1}";
            }
        }

        ///<summary>
        ///  Parses the given input using "formal" notation, or null if it cannot be parsed accordingly
        ///</summary>
        ///<exception cref="ArgumentException">If an illegal modifier is supplied for the interval</exception>
        ///<remarks>
        ///  "Formal" notation indicates "P4" for a perfect fourth, "m3" for a minor third, etc.
        ///</remarks>
        private static Interval ParseFormal(string input)
        {
            var match = Regex.Match(input, @"^([PdmMA])(\d+)$");
            if (!match.Success)
            {
                return null;
            }

            var generic = (Generic) int.Parse(match.Groups[2].Value) - 1;
            var reducedGeneric = ReducedGenericWidth(generic);
            var isPerfect = IS_PERFECT[reducedGeneric];
            
            var modifierPart = match.Groups[1].Value;
            if (isPerfect && (modifierPart.Equals("m") || modifierPart.Equals("M")))
            {
                throw new ArgumentException($"{GenericName(generic)} is a perfect interval");
            }
            if (!isPerfect && (modifierPart.Equals("P")))
            {
                throw new ArgumentException($"{GenericName(generic)} is not a perfect interval");
            }

            var lookup = isPerfect ? PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
            var modifier = lookup.Where(kvp => kvp.Value.Equals(modifierPart)).First().Key;

            var specific = SEMITONES_PER_OCTAVE * ((int) generic / NAMES_PER_OCTAVE) +
                MAJOR_SEMITONES[reducedGeneric] + modifier;

            return new Interval(generic, specific);
        }

        ///<summary>
        ///  Parses the given input using "simple" notation, or returns null if it cannot be parsed accordingly
        ///</summary>
        ///<remarks>
        ///  This notation uses "3" for a major third, "b5" for a flat fifth, etc. Commonly used to describe the
        ///  component intervals of chords.
        ///</remarks>
        private static Interval ParseSimple(string input)
        {
            var match = Regex.Match(input, @"^([b#]*)(\d+)$");
            if (!match.Success)
            {
                return null;
            }

            var generic = (Generic) int.Parse(match.Groups[2].Value) - 1;
            var reducedGeneric = ReducedGenericWidth(generic);
            
            var modifierPart = match.Groups[1].Value;
            var accidental = Accidental.Parse(modifierPart);

            var specific = SEMITONES_PER_OCTAVE * ((int) generic / NAMES_PER_OCTAVE) +
                MAJOR_SEMITONES[reducedGeneric] + accidental.Semitones;

            return new Interval(generic, specific);
        }

        ///<summary>
        ///  Returns a new Interval by parsing the given string input.
        ///</summary>
        ///<param name="input">The input to parse</param>
        ///<exception cref="FormatException">The given input cannot be parsed</exception>
        ///<exception cref="ArgumentException">If an illegal modifier is supplied for the interval</exception>
        ///<remarks>
        ///  Two formats are accepted: Formal, like <c>P4</c> and <c>d3</c>, or simple, like <c>b5</c> and <c>#9</c>. If
        ///  the simple form is used, then the major/perfect matching interval is sharped the given number of times. The
        ///  formal form understands (P)erfect, (d)iminished, (m)inor, (M)ajor, and (A)ugmented descriptors for each
        ///  interval as appropriate.
        ///</remarks>
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
        ///  Returns true if <c>other</c> is enharmonically equivalent to this interval.
        ///</summary>
        ///<param name="other">The other Interval to compare</param>
        ///<remarks>
        ///  Two intervals are enharmonic if they have the same specific width. Perfect unison and diminished second,
        ///  for example, are enharmonic despite having different generic widths.
        ///</remarks>
        public bool Enharmonic(Interval other) => SpecificWidth == other.SpecificWidth;

        ///<summary>
        ///  Returns a new Interval representing the width between two <see cref="Name"/>s.
        ///</summary>
        ///<param name="bottom">The lower <see cref="Name"/> to compare</param>
        ///<param name="top">The higher <see cref="Name"/> to compare</param>
        ///<remarks>
        ///  It is always assumed that the interval is going up from first to second: C to B would give an interval of a
        ///  major seventh (despite being much closer to go down a minor second). Also for this reason, this method will
        ///  always produce an interval between unison (inclusive) and an octave (exclusive).
        ///</remarks>
        public static Interval Between(Name bottom, Name top)
        {
            var generic = (Generic) (top - bottom).Modulus(NAMES_PER_OCTAVE);
            var topSemitones = MAJOR_SEMITONES[DISTANCE_FROM_C[top]];
            var bottomSemitones = MAJOR_SEMITONES[DISTANCE_FROM_C[bottom]];
            var semitones = (topSemitones - bottomSemitones).Modulus(SEMITONES_PER_OCTAVE);

            return new Interval(generic, semitones);
        }

        ///<summary>
        ///  Returns a new Interval representing the width between two <see cref="Note"/>s.
        ///</summary>
        ///<param name="bottom">The lower <see cref="Note"/> to compare</param>
        ///<param name="top">The higher <see cref="Note"/> to compare</param>
        ///<remarks>
        ///  It is always assumed that the interval is going up from first to second: C♯ to B would give an interval of
        ///  a minor seventh (despite being much closer to go down a major second). Also for this reason, this method
        ///  will always produce an interval between unison (inclusive) and an octave (exclusive).
        ///</remarks>
        public static Interval Between(Note bottom, Note top)
        {
            var betweenNames = Interval.Between(bottom.Name, top.Name);
            return new Interval(betweenNames.GenericWidth,
                betweenNames.SpecificWidth + top.Accidental.Semitones - bottom.Accidental.Semitones);
        }

        ///<summary>
        ///  Returns a new Interval representing the width between two <see cref="Pitch"/>es.
        ///</summary>
        ///<param name="bottom">The lower <see cref="Pitch"/> to compare</param>
        ///<param name="top">The higher <see cref="Pitch"/> to compare</param>
        ///<remarks>
        ///  It is always assumed that the interval is going up from first to second: C♯3 to B4 would give an interval
        ///  of a minor fifteenth.
        ///</remarks>
        public static Interval Between(Pitch bottom, Pitch top)
        {
            var semitones = top.Midi - bottom.Midi;
            var octaves = semitones / SEMITONES_PER_OCTAVE;
            var reducedGeneric = Interval.Between(bottom.Note.Name, top.Note.Name).GenericWidth;
            return new Interval(reducedGeneric + (octaves * NAMES_PER_OCTAVE), semitones);
        }

        ///<summary>
        ///  Creates a new compound Interval by combining two others.
        ///</summary>
        ///<remarks>
        ///  For example, adding together a perfect octave and a perfect fifth produces a perfect thirteenth.
        ///</remarks>
        public static Interval operator +(Interval a, Interval b) =>
            new Interval(a.GenericWidth + (int)b.GenericWidth, a.SpecificWidth + b.SpecificWidth);

        ///<summary>
        ///  Creates a new compound Interval by subtracting one from the other.
        ///</summary>
        ///<remarks>
        ///  For example, subtracting a minor second from a perfect octave produces a major seventh.
        ///</remarks>
        public static Interval operator-(Interval a, Interval b) =>
            new Interval(a.GenericWidth - (int)b.GenericWidth, a.SpecificWidth - b.SpecificWidth);

        #region Internal constants

        private static readonly IDictionary<Generic, bool> IS_PERFECT = new Dictionary<Generic, bool>()
        {
            [UNISON] = true, [SECOND] = false, [THIRD] = false, [FOURTH] = true, [FIFTH] = true, [SIXTH] = false,
            [SEVENTH] = false
        };

        private static readonly IDictionary<Generic, int> MAJOR_SEMITONES = new Dictionary<Generic, int>()
        {
            [UNISON] = 0, [SECOND] = 2, [THIRD] = 4, [FOURTH] = 5, [FIFTH] = 7, [SIXTH] = 9, [SEVENTH] = 11
        };

        private static readonly IDictionary<Name, Generic> DISTANCE_FROM_C = new Dictionary<Name, Generic>()
        {
            [C] = UNISON, [D] = SECOND, [E] = THIRD, [F] = FOURTH, [G] = FIFTH, [A] = SIXTH, [B] = SEVENTH
        };

        private static readonly IDictionary<Generic, string> GENERIC_NAMES = new Dictionary<Generic, string>()
        {
            [UNISON] = "Unison", [SECOND] = "Second", [THIRD] = "Third", [FOURTH] = "Fourth", [FIFTH] = "Fifth",
            [SIXTH] = "Sixth", [SEVENTH] = "Seventh", [OCTAVE] = "Octave", [NINTH] = "Ninth", [TENTH] = "Tenth",
            [ELEVENTH] = "Eleventh", [TWELFTH] = "Twelfth", [THIRTEENTH] = "Thirteenth", [FOURTEENTH] = "Fourteenth",
            [FIFTEENTH] = "Fifteenth"
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
        ///  Determines whether two Intervals are value-equivalent
        ///</summary>
        ///<param name="other">The Intervals to compare</param>
        public bool Equals(Interval other) =>
            GenericWidth == other.GenericWidth && SpecificWidth == other.SpecificWidth;

        private static readonly int HASH_CODE_SEED = 59;
        private static readonly int HASH_CODE_STEP = 223;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Intervals are guaranteed to produce the
        ///  same result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                hashCode = (HASH_CODE_STEP * hashCode) ^ (int)GenericWidth;
                hashCode = (HASH_CODE_STEP * hashCode) ^ SpecificWidth;
                return hashCode;
            }
        }

        #endregion

        #region Typical values
        #pragma warning disable CS1591

        public static readonly Interval PERFECT_UNISON = new Interval(UNISON, 0);
        public static readonly Interval DIMINISHED_SECOND = new Interval(SECOND, 0);
        public static readonly Interval MINOR_SECOND = new Interval(SECOND, 1);
        public static readonly Interval MAJOR_SECOND = new Interval(SECOND, 2);
        public static readonly Interval AUGMENTED_SECOND = new Interval(SECOND, 3);
        public static readonly Interval DIMINISHED_THIRD = new Interval(THIRD, 2);
        public static readonly Interval MINOR_THIRD = new Interval(THIRD, 3);
        public static readonly Interval MAJOR_THIRD = new Interval(THIRD, 4);
        public static readonly Interval AUGMENTED_THIRD = new Interval(THIRD, 5);
        public static readonly Interval DIMINISHED_FOURTH = new Interval(FOURTH, 4);
        public static readonly Interval PERFECT_FOURTH = new Interval(FOURTH, 5);
        public static readonly Interval AUGMENTED_FOURTH = new Interval(FOURTH, 6);
        public static readonly Interval DIMINISHED_FIFTH = new Interval(FIFTH, 6);
        public static readonly Interval PERFECT_FIFTH = new Interval(FIFTH, 7);
        public static readonly Interval AUGMENTED_FIFTH = new Interval(FIFTH, 8);
        public static readonly Interval DIMINISHED_SIXTH = new Interval(SIXTH, 7);
        public static readonly Interval MINOR_SIXTH = new Interval(SIXTH, 8);
        public static readonly Interval MAJOR_SIXTH = new Interval(SIXTH, 9);
        public static readonly Interval AUGMENTED_SIXTH = new Interval(SIXTH, 10);
        public static readonly Interval DIMINISHED_SEVENTH = new Interval(SEVENTH, 9);
        public static readonly Interval MINOR_SEVENTH = new Interval(SEVENTH, 10);
        public static readonly Interval MAJOR_SEVENTH = new Interval(SEVENTH, 11);
        public static readonly Interval AUGMENTED_SEVENTH = new Interval(SEVENTH, 12);
        public static readonly Interval DIMINISHED_OCTAVE = new Interval(OCTAVE, 11);
        public static readonly Interval PERFECT_OCTAVE = new Interval(OCTAVE, 12);
        public static readonly Interval AUGMENTED_OCTAVE = new Interval(OCTAVE, 13);
        public static readonly Interval DIMINISHED_NINTH = new Interval(NINTH, 12);
        public static readonly Interval MINOR_NINTH = new Interval(NINTH, 13);
        public static readonly Interval MAJOR_NINTH = new Interval(NINTH, 14);
        public static readonly Interval AUGMENTED_NINTH = new Interval(NINTH, 15);
        public static readonly Interval DIMINISHED_TENTH = new Interval(TENTH, 14);
        public static readonly Interval MINOR_TENTH = new Interval(TENTH, 15);
        public static readonly Interval MAJOR_TENTH = new Interval(TENTH, 16);
        public static readonly Interval AUGMENTED_TENTH = new Interval(TENTH, 17);
        public static readonly Interval DIMINISHED_ELEVENTH = new Interval(ELEVENTH, 16);
        public static readonly Interval PERFECT_ELEVENTH = new Interval(ELEVENTH, 17);
        public static readonly Interval AUGMENTED_ELEVENTH = new Interval(ELEVENTH, 18);
        public static readonly Interval DIMINISHED_TWELFTH = new Interval(TWELFTH, 18);
        public static readonly Interval PERFECT_TWELFTH = new Interval(TWELFTH, 19);
        public static readonly Interval AUGMENTED_TWELFTH = new Interval(TWELFTH, 20);
        public static readonly Interval DIMINISHED_THIRTEENTH = new Interval(THIRTEENTH, 19);
        public static readonly Interval MINOR_THIRTEENTH = new Interval(THIRTEENTH, 20);
        public static readonly Interval MAJOR_THIRTEENTH = new Interval(THIRTEENTH, 21);
        public static readonly Interval AUGMENTED_THIRTEENTH = new Interval(THIRTEENTH, 22);
        public static readonly Interval DIMINISHED_FOURTEENTH = new Interval(FOURTEENTH, 21);
        public static readonly Interval MINOR_FOURTEENTH = new Interval(FOURTEENTH, 22);
        public static readonly Interval MAJOR_FOURTEENTH = new Interval(FOURTEENTH, 23);
        public static readonly Interval AUGMENTED_FOURTEENTH = new Interval(FOURTEENTH, 24);
        public static readonly Interval DIMINISHED_FIFTEENTH = new Interval(FIFTEENTH, 23);
        public static readonly Interval PERFECT_FIFTEENTH = new Interval(FIFTEENTH, 24);
        public static readonly Interval AUGMENTED_FIFTEENTH = new Interval(FIFTEENTH, 25);

        #pragma warning restore CS1591
        #endregion
    }
}