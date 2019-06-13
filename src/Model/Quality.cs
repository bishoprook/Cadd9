using System;
using System.Collections.Generic;
using System.Linq;

using static Cadd9.Model.Interval;
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
        public Interval[] Intervals { get; }

        ///<summary>
        ///  Returns a new Quality
        ///</summary>
        ///<param name="intervals">The set of Intervals that define this chord quality</param>
        ///<exception cref="ArgumentException">Thrown if a generic interval appears multiple times</exception>
        public Quality(Interval[] intervals)
        {
            if (intervals.Select(i => i.Generic).Distinct().Count() != intervals.Count())
            {
                throw new ArgumentException("All generic intervals must appear at most once");
            }
            Intervals = intervals.OrderBy(i => i.Generic).ToArray();
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
        public Quality(params string[] intervals) : this(intervals.Select(I).ToArray()) {}

        ///<summary>
        ///  A string representation of this Mode, useful for debugging.
        ///</summary>
        override public string ToString() => $"Quality[Intervals={String.Join(",", Intervals.ToList())}]";

        ///<summary>
        ///  Returns a new Quality by adding the given Interval
        ///</summary>
        ///<param name="add">The Interval to add</param>
        ///<remarks>
        ///  This can be used to create a chord with arbitrary extensions, like 9th, 13th, etc.
        ///</remarks>
        public Quality Add(Interval add) => new Quality(Intervals.Append(add).ToArray());

        ///<summary>
        ///  Returns a new Quality by applying the given Alteration.
        ///</summary>
        ///<param name="alt">The Alteration to apply</param>
        ///<remarks>
        ///  This is generally used to modify the 3rd or 5th of the quality, like creating a sus2 or a flat-5 chord.
        ///</remarks>
        public Quality Alter(Alteration alt) {
            IEnumerable<Interval> newIntervals = Intervals;
            if (alt.Drop.HasValue) {
                newIntervals = newIntervals.Where(i => i.Generic != alt.Drop.Value);
            }
            if (alt.Add != null) {
                newIntervals = newIntervals.Append(alt.Add);
            }
            return new Quality(newIntervals.ToArray());
        }

        ///<summary>
        ///  Returns a sequence of Notes by applying all of this Quality's Intervals to the given root.
        ///</summary>
        public IEnumerable<Note> Apply(Note root) => Intervals.OrderBy(i => i.Generic).Select(i => root.Apply(i));

        ///<summary>
        ///  Returns a sequence of Pitches by applying all of this Quality's Intervals to the given root.
        ///</summary>
        public IEnumerable<Pitch> Apply(Pitch root) => Intervals.OrderBy(i => i.Generic).Select(i => root.Apply(i));

        #region Alterations

        ///<summary>
        ///  Encapsulates an alteration of a chord quality, by dropping, adding, or replacing some intervals.
        ///</summary>
        public class Alteration
        {
            ///<summary>
            ///  The generic interval to be removed by this modification, or null if nothing is removed.
            ///</summary>
            public int? Drop { get; }

            ///<summary>
            ///  The interval that is added as part of this modification, or null if nothing is added.
            ///</summary>
            public Interval Add { get; }

            ///<summary>
            ///  Returns a new Alteration
            ///</summary>
            public Alteration(int? drop, Interval add)
            {
                Drop = drop;
                Add = add;
            }

            #pragma warning disable CS1591

            public static readonly Alteration DROP1 = new Alteration(0, null);
            public static readonly Alteration DROP3 = new Alteration(2, null);
            public static readonly Alteration DROP5 = new Alteration(4, null);
            public static readonly Alteration SUS2 = new Alteration(2, I("2"));
            public static readonly Alteration SUS4 = new Alteration(2, I("4"));
            public static readonly Alteration FLAT5 = new Alteration(4, I("b5"));
            public static readonly Alteration SHARP5 = new Alteration(4, I("#5"));
            public static readonly Alteration ADD6 = new Alteration(null, I("6"));
            public static readonly Alteration DOM7 = new Alteration(null, I("b7"));
            public static readonly Alteration MAJ7 = new Alteration(null, I("7"));
            public static readonly Alteration ADD9 = new Alteration(null, I("9"));
            public static readonly Alteration FLAT9 = new Alteration(null, I("b9"));
            public static readonly Alteration SHARP9 = new Alteration(null, I("#9"));
            public static readonly Alteration ADD11 = new Alteration(null, I("11"));
            public static readonly Alteration FLAT11 = new Alteration(null, I("b11"));
            public static readonly Alteration SHARP11 = new Alteration(null, I("#11"));
            public static readonly Alteration ADD13 = new Alteration(null, I("13"));
            public static readonly Alteration FLAT13 = new Alteration(null, I("b13"));
            public static readonly Alteration SHARP13 = new Alteration(null, I("#13"));

            #pragma warning restore CS1591
        }

        #endregion

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
        #pragma warning disable CS1591

        public static Quality MAJOR_TRIAD = new Quality("1", "3", "5");
        public static Quality MINOR_TRIAD = new Quality("1", "b3", "5");
        public static Quality DOMINANT_SEVENTH = new Quality("1", "3", "5", "b7");
        public static Quality MAJOR_SEVENTH = new Quality("1", "3", "5", "7");
        public static Quality MINOR_SEVENTH = new Quality("1", "b3", "5", "b7");
        public static Quality SIXTH = new Quality("1", "3", "5", "6");
        public static Quality SIX_NINE = new Quality("1", "3", "5", "6", "9");
        public static Quality MINOR_SIXTH = new Quality("1", "b3", "5", "6");
        public static Quality DIMINISHED = new Quality("1", "b3", "b5");
        public static Quality DIMINISHED_SEVENTH = new Quality("1", "b3", "b5", "bb7");
        public static Quality HALF_DIMINISHED_SEVENTH = new Quality("1", "b3", "b5", "b7");
        public static Quality AUGMENTED = new Quality("1", "3", "#5");
        public static Quality SUS2_TRIAD = new Quality("1", "2", "5");
        public static Quality SUS4_TRIAD = new Quality("1", "4", "5");

        #pragma warning restore CS1591
        #endregion
    }
}