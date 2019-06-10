using System;
using System.Collections.Generic;
using System.Linq;

using static Cadd9.Util.ParseHelpers;

namespace Cadd9.Model
{
    ///<summary>
    ///  Represents a particular chord quality that may be applied with any given root
    ///</summary>
    public class Quality : IEquatable<Quality>
    {
        ///<summary>
        ///  The set of Intervals that define this chord quality
        ///</summary>
        public ISet<Interval> Intervals { get; }

        ///<summary>
        ///  Returns a new Quality
        ///</summary>
        ///<param name="intervals">The set of Intervals that define this chord quality</param>
        ///<exception cref="ArgumentException">Thrown if a generic interval appears multiple times</exception>
        public Quality(ISet<Interval> intervals)
        {
            if (intervals.Select(i => i.Generic).Distinct().Count() != intervals.Count)
            {
                throw new ArgumentException("All generic intervals must appear only once");
            }
            Intervals = intervals;
        }

        ///<summary>
        ///  Returns a new Quality
        ///</summary>
        ///<param name="intervals">String representations of the Intervals for this chord quality</param>
        ///<exception cref="ArgumentException">Thrown if a generic interval appears multiple times</exception>
        ///<remarks>
        ///  The intervals given in this constructor will be parsed according to the behavior in
        ///  <see cref="Interval.Parse(string)" /> which allows short-hand construction.
        ///</remarks>
        public Quality(params string[] intervals) : this(intervals.Select(I).ToHashSet()) {}

        ///<summary>
        ///  A string representation of this Mode, useful for debugging.
        ///</summary>
        override public string ToString() =>
            $"Quality[Intervals={String.Join(",", Intervals.OrderBy(i => i.Generic))}]";

        ///<summary>
        ///  Returns a new Quality by adding the given Intervals
        ///</summary>
        ///<param name="adds">The Intervals to add</param>
        ///<remarks>
        ///  This can be used to create a chord with arbitrary extensions, like 9th, 13th, etc.
        ///</remarks>
        public Quality Add(params Interval[] adds) => new Quality(Intervals.Union(adds).ToHashSet());

        ///<summary>
        ///  Returns a sequence of Notes by applying all of this Quality's Intervals to the given root.
        ///</summary>
        public IEnumerable<Note> Apply(Note root) => Intervals.OrderBy(i => i.Generic).Select(i => root.Apply(i));

        ///<summary>
        ///  Returns a sequence of Pitches by applying all of this Quality's Intervals to the given root.
        ///</summary>
        public IEnumerable<Pitch> Apply(Pitch root) => Intervals.OrderBy(i => i.Generic).Select(i => root.Apply(i));

        #region Value equality

        ///<summary>
        ///  Determines whether two Qualities are value-equivalent
        ///</summary>
        ///<param name="other">The other Quality to compare</param>
        public bool Equals(Quality other) => !Intervals.Except(other.Intervals).Any();

        private static readonly int HASH_CODE_SEED = 13;
        private static readonly int HASH_CODE_STEP = 439;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Qualities are guaranteed to produce the
        ///  same result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                foreach (Interval interval in Intervals.OrderBy(i => i.Generic))
                {
                    hashCode = (HASH_CODE_STEP * hashCode) ^ interval.GetHashCode();
                }
                return hashCode;
            }
        }
        
        #endregion

        #region Typical values

        public static Quality MAJOR_TRIAD = new Quality("1", "3", "5");
        public static Quality MINOR_TRIAD = new Quality("1", "b3", "5");
        public static Quality DOMINANT_SEVENTH = new Quality("1", "3", "5", "b7");
        public static Quality MAJOR_SEVENTH = new Quality("1", "3", "5", "7");
        public static Quality MINOR_SEVENTH = new Quality("1", "b3", "5", "b7");
        public static Quality SIXTH = new Quality("1", "3", "5", "6");
        public static Quality MINOR_SIXTH = new Quality("1", "b3", "5", "6");
        public static Quality DIMINISHED = new Quality("1", "b3", "b5");
        public static Quality DIMINISHED_SEVENTH = new Quality("1", "b3", "b5", "bb7");
        public static Quality HALF_DIMINISHED_SEVENTH = new Quality("1", "b3", "b5", "b7");
        public static Quality AUGMENTED = new Quality("1", "3", "#5");
        public static Quality SEVENTH_SHARP_FIFTH = new Quality("1", "3", "#5", "b7");
        public static Quality NINTH = new Quality("1", "3", "5", "b7", "#9");
        public static Quality SEVENTH_SHARP_NINE = new Quality("1", "3", "5", "b7", "#9");
        public static Quality MAJOR_NINTH = new Quality("1", "3", "5", "7", "9");

        #endregion
    }
}