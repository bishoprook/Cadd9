using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Model;
using Util;

using static Model.Interval;
using static Model.Name;
using static Model.Accidental;
using static Util.ParseHelpers;

public class IntervalTest
{
    public static IEnumerable<object[]> BetweenNameData =>
        new List<object[]>
        {
            new object[] { PERFECT_UNISON, B, B },
            new object[] { PERFECT_FIFTH, G, D },
            new object[] { MINOR_SECOND, E, F }
        };

    public static IEnumerable<object[]> BetweenNoteData =>
        new List<object[]>
        {
            new object[] { PERFECT_UNISON, N("Eb"), N("Eb") },
            new object[] { DIMINISHED_SECOND, N("E#"), N("F") },
            new object[] { PERFECT_FIFTH, N("B"), N("F#") },
            new object[] { AUGMENTED_FOURTH, N("D#"), N("G##") },
            new object[] { MINOR_SIXTH, N("Ebb"), N("Cbb") },
        };

    public static IEnumerable<object[]> BetweenPitchData =>
        new List<object[]>
        {
            new object[] { PERFECT_UNISON, P("C4"), P("C4") },
            new object[] { PERFECT_OCTAVE, P("D4"), P("D5") },
            new object[] { PERFECT_FIFTEENTH, P("Eb4"), P("Eb6") },
            new object[] { MINOR_SIXTH, P("G#3"), P("E4") },
            new object[] { MAJOR_NINTH, P("C3"), P("D4") }
        };
    
    public static IEnumerable<object[]> DescriptionData =>
        new List<object[]>
        {
            new object[] { PERFECT_UNISON, "Perfect Unison", "P1" },
            new object[] { AUGMENTED_SECOND, "Augmented Second", "A2" },
            new object[] { MINOR_THIRD, "Minor Third", "m3" },
            new object[] { PERFECT_FIFTH, "Perfect Fifth", "P5" },
            new object[] { DIMINISHED_SEVENTH, "Diminished Seventh", "d7" },
            new object[] { MAJOR_THIRTEENTH, "Major Thirteenth", "M13" },
            new object[] { new Interval(106, 181), "Minor 107th", "m107" }
        };

    [Theory] [MemberData(nameof(BetweenNoteData))]
    public void CanApplyToNotes(Interval interval, Note bottom, Note top)
    {
        Assert.Equal(top, bottom.Apply(interval));
    }

    [Theory] [MemberData(nameof(BetweenPitchData))]
    public void CanApplyToPitches(Interval interval, Pitch bottom, Pitch top)
    {
        Assert.Equal(top, bottom.Apply(interval));
    }

    [Theory] [MemberData(nameof(BetweenNameData))]
    public void CanCompareNames(Interval interval, Name bottom, Name top)
    {
        Assert.Equal(interval, Interval.Between(bottom, top));
    }

    [Theory] [MemberData(nameof(BetweenNoteData))]
    public void CanCompareNotes(Interval interval, Note bottom, Note top)
    {
        Assert.Equal(interval, Interval.Between(bottom, top));
    }

    [Theory] [MemberData(nameof(BetweenPitchData))]
    public void CanComparePitches(Interval interval, Pitch bottom, Pitch top)
    {
        Assert.Equal(interval, Interval.Between(bottom, top));
    }

#pragma warning disable xUnit1026

    [Theory]
    [MemberData(nameof(DescriptionData))]
    public void CanDescribeIntervals(Interval interval, string description, string abbreviation)
    {
        Assert.Equal(description, interval.Describe());
    }

    [Theory] [MemberData(nameof(DescriptionData))]
    public void CanAbbreviateIntervals(Interval interval, string description, string abbreviation)
    {
        Assert.Equal(abbreviation, interval.Abbreviate());
    }

    [Theory] [MemberData(nameof(DescriptionData))]
    public void CanParseIntervals(Interval interval, string description, string abbreviation)
    {
        Assert.Equal(interval, Interval.Parse(abbreviation));
    }

#pragma warning restore xUnit1026

    [Theory]
    [InlineData("P2", typeof(ArgumentException), "Second is not a perfect interval")]
    [InlineData("M4", typeof(ArgumentException), "Fourth is a perfect interval")]
    [InlineData("foo", typeof(FormatException), "Unrecognized interval: foo")]
    public void ParseIntervalFailure(string input, Type exceptionType, string expectedMessage)
    {
        var err = Assert.ThrowsAny<Exception>(() => Interval.Parse(input));
        Assert.IsType(exceptionType, err);
        Assert.Equal(expectedMessage, err.Message);
    }

    [Fact]
    public void EnharmonicIntervals()
    {
        Assert.True(AUGMENTED_SECOND.Enharmonic(MINOR_THIRD));
        Assert.False(MAJOR_SECOND.Enharmonic(MAJOR_THIRD));
    }

    [Fact]
    public void CanRunCircleOfFifths()
    {
        Note[] circleOfFifths = "Cb Gb Db Ab Eb Bb F C G D A E B F# C#"
            .Split(" ").Select(N).ToArray();
        Note[] result = new Note[15];
        result[0] = N("Cb");
        for (int i = 1; i < 15; i++) {
            result[i] = result[i - 1].Apply(PERFECT_FIFTH);
        }
        Assert.Equal(circleOfFifths, result);
    }
}