using System;
using System.Collections.Generic;
using System.Linq;
using Util;

using static Model.Interval;
using static Util.ParseHelpers;

namespace Model
{
    public class Mode : IEquatable<Mode>
    {
        public Interval[] Intervals { get; }

        public Mode(Interval[] intervals)
        {
            if (intervals.Zip(intervals.Skip(1), (b, t) => b.Specific >= t.Specific).Any(t => t))
            {
                throw new ArgumentException("Mode intervals must strictly increase");
            }
            this.Intervals = intervals;
        }

        public Mode(params string[] intervals)
            : this(intervals.Select(I).ToArray()) {}

        override public string ToString()
        {
            return $"Mode[Intervals={String.Join(",", Intervals)}]";
        }

        public string Describe()
        {
            return this.GetAttribute<Mode, DescribeAttribute>().Descriptor;
        }

        public bool Equals(Mode other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }

        public Chord Chord(int degree, int width)
        {
            // These intervals are based on the tonic; but the returned chord will be
            // based on the given scale degree as the root. So each one will need to
            // be decremented by root.
            Interval[] intervals = Ascend().Skip(degree).EveryN(2).Take(width).ToArray();
            Interval root = intervals[0];
            
            return new Chord(intervals.Select(i => i - root).ToArray());
        }

        public IEnumerable<Interval> Ascend()
        {
            Interval current = PERFECT_UNISON;
            while(true)
            {
                foreach (Interval interval in Intervals)
                {
                    yield return current + interval;
                }
                current += PERFECT_OCTAVE;
            }
        }

        [Describe("Ionian (Major)")]
        public static readonly Mode IONIAN = new Mode("P1", "M2", "M3", "P4", "P5", "M6", "M7");

        [Describe("Dorian")]
        public static readonly Mode DORIAN = new Mode("P1", "M2", "m3", "P4", "P5", "M6", "m7");

        [Describe("Phrygian")]
        public static readonly Mode PHRYGIAN = new Mode("P1", "m2", "m3", "P4", "P5", "m6", "m7");

        [Describe("Lydian")]
        public static readonly Mode LYDIAN = new Mode("P1", "M2", "M3", "A4", "P5", "M6", "M7");

        [Describe("Mixolydian")]
        public static readonly Mode MIXOLYDIAN = new Mode("P1", "M2", "M3", "P4", "P5", "M6", "m7");

        [Describe("Aeolian (Minor)")]
        public static readonly Mode AEOLIAN = new Mode("P1", "M2", "m3", "P4", "P5", "m6", "m7");

        [Describe("Locrian")]
        public static readonly Mode LOCRIAN = new Mode("P1", "m2", "m3", "P4", "d5", "m6", "m7");
    }
}