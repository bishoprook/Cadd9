using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Cadd9.Model;
using Cadd9.Util;

using static Cadd9.Model.Interval;
using static Cadd9.Model.Name;
using static Cadd9.Model.Accidental;
using static Cadd9.Util.ParseHelpers;

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
            new object[] { PERFECT_UNISON, "Perfect Unison", "P1", "1" },
            new object[] { AUGMENTED_SECOND, "Augmented Second", "A2", "#2" },
            new object[] { MINOR_THIRD, "Minor Third", "m3", "b3" },
            new object[] { PERFECT_FIFTH, "Perfect Fifth", "P5", "5" },
            new object[] { DIMINISHED_SEVENTH, "Diminished Seventh", "d7", "bb7" },
            new object[] { MAJOR_THIRTEENTH, "Major Thirteenth", "M13", "13" },
            new object[] { new Interval(106, 181), "Minor 107th", "m107", "b107" }
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
    public void CanDescribeIntervals(Interval interval, string description, string formal, string simple)
    {
        Assert.Equal(description, interval.Description);
    }

    [Theory] [MemberData(nameof(DescriptionData))]
    public void CanAbbreviateIntervals(Interval interval, string description, string formal, string simple)
    {
        Assert.Equal(formal, interval.Abbreviation);
    }

    [Theory] [MemberData(nameof(DescriptionData))]
    public void CanParseIntervals(Interval interval, string description, string formal, string simple)
    {
        Assert.Equal(interval, Interval.Parse(formal));
    }

    [Theory] [MemberData(nameof(DescriptionData))]
    public void CanParseSimple(Interval interval, string description, string formal, string simple)
    {
        Assert.Equal(interval, Interval.Parse(simple));
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

    [Theory]
    [InlineData("M2", "M2", "M3")]
    [InlineData("P4", "M3", "M6")]
    [InlineData("P8", "m2", "m9")]
    public void IntervalArithmetic(string first, string second, string compound)
    {
        Assert.Equal(I(compound), I(first) + I(second));
        Assert.Equal(I(first), I(compound) - I(second));
        Assert.Equal(I(second), I(compound) - I(first));
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