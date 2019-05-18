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