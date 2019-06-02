using System;
using System.Collections.Generic;
using System.Linq;

using static Cadd9.Util.ParseHelpers;

namespace Cadd9.Model
{
    public class Quality : IEquatable<Quality>
    {
        public ISet<Interval> Intervals { get; }

        public Quality(ISet<Interval> intervals)
        {
            Intervals = intervals;
        }

        public Quality(params string[] intervals)
            : this(intervals.Select(I).ToHashSet()) {}

        public Quality Add(params Interval[] adds)
        {
            return new Quality(Intervals.Union(adds).ToHashSet());
        }

        public IEnumerable<Note> Apply(Note root)
        {
            return Intervals.Select(i => root.Apply(i));
        }

        public IEnumerable<Pitch> Apply(Pitch root)
        {
            return Intervals.Select(i => root.Apply(i));
        }

#region Value equality
        private static readonly int HASH_CODE_SEED = 13;
        private static readonly int HASH_CODE_STEP = 439;

        public bool Equals(Quality other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }

        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                foreach (Interval interval in Intervals)
                {
                    hashCode = (HASH_CODE_STEP * hashCode) ^ interval.GetHashCode();
                }
                return hashCode;
            }
        }
#endregion

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
    }
}