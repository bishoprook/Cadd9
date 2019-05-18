using System;
using Util;

using static Model.Interval;

namespace Model
{
    public struct Mode
    {
        public Interval[] Intervals { get; }

        private Mode(params Interval[] intervals)
        {
            this.Intervals = intervals;
        }

        [Describe("Ionian (Major)")]
        public static readonly Mode IONIAN = new Mode(
            PERFECT_UNISON,
            MAJOR_SECOND,
            MAJOR_THIRD,
            PERFECT_FOURTH,
            PERFECT_FIFTH,
            MAJOR_SIXTH,
            MAJOR_SEVENTH
        );

        [Describe("Dorian")]
        public static readonly Mode DORIAN = new Mode(
            PERFECT_UNISON,
            MAJOR_SECOND,
            MINOR_THIRD,
            DIMINISHED_FOURTH,
            PERFECT_FIFTH,
            MAJOR_SIXTH,
            MINOR_SEVENTH
        );

        [Describe("Phrygian")]
        public static readonly Mode PHRYGIAN = new Mode(
            PERFECT_UNISON,
            MINOR_SECOND,
            MINOR_THIRD,
            PERFECT_FOURTH,
            PERFECT_FIFTH,
            MINOR_SIXTH,
            MINOR_SEVENTH
        );

        [Describe("Lydian")]
        public static readonly Mode LYDIAN = new Mode(
            PERFECT_UNISON,
            MAJOR_SECOND,
            MAJOR_THIRD,
            AUGMENTED_FOURTH,
            PERFECT_FIFTH,
            MAJOR_SIXTH,
            MAJOR_SEVENTH
        );

        [Describe("Mixolydian")]
        public static readonly Mode MIXOLYDIAN = new Mode(
            PERFECT_UNISON,
            MAJOR_SECOND,
            MAJOR_THIRD,
            PERFECT_FOURTH,
            PERFECT_FIFTH,
            MAJOR_SIXTH,
            MINOR_SEVENTH
        );

        [Describe("Aeolian (Minor)")]
        public static readonly Mode AEOLIAN = new Mode(
            PERFECT_UNISON,
            MAJOR_SECOND,
            MINOR_THIRD,
            PERFECT_FOURTH,
            PERFECT_FIFTH,
            MINOR_SIXTH,
            MINOR_SEVENTH
        );

        [Describe("Locrian")]
        public static readonly Mode LOCRIAN = new Mode(
            PERFECT_UNISON,
            MINOR_SECOND,
            MINOR_THIRD,
            PERFECT_FOURTH,
            DIMINISHED_FIFTH,
            MINOR_SIXTH,
            MINOR_SEVENTH
        );
    }

    public static class ModeExtensions
    {
        public static string Describe(this Mode mode)
        {
            return mode.GetAttribute<Mode, DescribeAttribute>().Descriptor;
        }
    }
}