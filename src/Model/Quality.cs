using System;
using System.Collections.Generic;
using System.Linq;

using static Util.ParseHelpers;

namespace Model
{
    public class Quality : IEquatable<Quality>
    {
        public Interval[] Intervals { get; }

        public Quality(Interval[] intervals)
        {
            if (intervals.Zip(intervals.Skip(1), (b, t) => b.Specific >= t.Specific).Any(t => t))
            {
                throw new ArgumentException("Quality intervals must strictly increase");
            }
            Intervals = intervals;
        }

        public Quality(params string[] intervals)
            : this(intervals.Select(I).ToArray()) {}

        public bool Equals(Quality other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }

        public Quality Add(params Interval[] adds)
        {
            return new Quality(
                Intervals.TakeWhile(i => i.Specific < adds.First().Specific)
                    .Concat(adds)
                    .Concat(Intervals.SkipWhile(i => i.Specific < adds.Last().Specific)
                ).ToArray()
            );
        }

        public IEnumerable<Note> Apply(Note root)
        {
            return Intervals.Select(i => root.Apply(i));
        }

        public IEnumerable<Pitch> Apply(Pitch root)
        {
            return Intervals.Select(i => root.Apply(i));
        }

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