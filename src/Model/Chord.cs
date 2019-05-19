using System;
using System.Collections.Generic;
using System.Linq;

using static Util.ParseHelpers;

namespace Model
{
    public class Chord : IEquatable<Chord>
    {
        public Interval[] Intervals { get; }

        public Chord(Interval[] intervals)
        {
            if (intervals.Zip(intervals.Skip(1), (b, t) => b.Specific >= t.Specific).Any(t => t))
            {
                throw new ArgumentException("Chord intervals must strictly increase");
            }
            Intervals = intervals;
        }

        public Chord(params string[] intervals)
            : this(intervals.Select(I).ToArray()) {}

        public bool Equals(Chord other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }

        public Chord Add(params Interval[] adds)
        {
            return new Chord(
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

        public static Chord MAJOR_TRIAD = new Chord("1", "3", "5");
        public static Chord MINOR_TRIAD = new Chord("1", "b3", "5");
        public static Chord DOMINANT_SEVENTH = new Chord("1", "3", "5", "b7");
        public static Chord MAJOR_SEVENTH = new Chord("1", "3", "5", "7");
        public static Chord MINOR_SEVENTH = new Chord("1", "b3", "5", "b7");
        public static Chord SIXTH = new Chord("1", "3", "5", "6");
        public static Chord MINOR_SIXTH = new Chord("1", "b3", "5", "6");
        public static Chord DIMINISHED = new Chord("1", "b3", "b5");
        public static Chord DIMINISHED_SEVENTH = new Chord("1", "b3", "b5", "bb7");
        public static Chord HALF_DIMINISHED_SEVENTH = new Chord("1", "b3", "b5", "b7");
        public static Chord AUGMENTED = new Chord("1", "3", "#5");
        public static Chord SEVENTH_SHARP_FIFTH = new Chord("1", "3", "#5", "b7");
        public static Chord NINTH = new Chord("1", "3", "5", "b7", "#9");
        public static Chord SEVENTH_SHARP_NINE = new Chord("1", "3", "5", "b7", "#9");
        public static Chord MAJOR_NINTH = new Chord("1", "3", "5", "7", "9");
    }
}