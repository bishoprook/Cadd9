using System;
using System.Collections;
using System.Collections.Generic;

using Cadd9.Model;
using Xunit;

using static Cadd9.Model.Name;
using static Cadd9.Model.Accidental;
using static Cadd9.Model.Mode;
using static Cadd9.Util.ParseHelpers;

#pragma warning disable CS1591

public class PitchTest
{
    [Theory]
    [InlineData("F#3", 2, "F#5")]
    [InlineData("Gb3", -2, "Gb1")]
    public void CanTransposeUp(string root, int octaves, string expected)
    {
        Assert.Equal(P(expected), P(root).Transpose(octaves));
    }

    public static IEnumerable<object[]> Enharmonics =>
        new List<object[]>
        {
            new object[] { P("G#4"), P("Ab4"), true },
            new object[] { P("G#4"), P("A#4"), false },
            new object[] { P("G#4"), P("Ab5"), false }
        };

    [Theory] [MemberData(nameof(Enharmonics))]
    public void CanCompareEnharmonics(Pitch bottom, Pitch top, bool isEnharmonic)
    {
        Assert.Equal(isEnharmonic, bottom.Enharmonic(top));
    }

    public static IEnumerable<object[]> ParseExamples =>
        new List<object[]>
        {
            new object[] { new Pitch(G, SHARP, 7), "G#7" },
            new object[] { new Pitch(B, DOUBLE_FLAT, 3), "Bbb3" },
            new object[] { new Pitch(F, DOUBLE_SHARP, -2), "F##-2" },
            new object[] { new Pitch(E, NATURAL, 17), "e17" },
            new object[] { new Pitch(C, NATURAL, 3), "Cnat+3" }
        };

    [Theory] [MemberData(nameof(ParseExamples))]
    public void CanParse(Pitch expected, string input)
    {
        Assert.Equal(expected, Pitch.Parse(input));
    }

    [Theory]
    [InlineData("C", "C4", "C4")]
    [InlineData("G", "F4", "F♮4")]
    [InlineData("Bb", "Bb4", "B4")]
    public void DescribeInMajorKey(string key, string note, string expected)
    {
        Assert.Equal(expected, P(note).DescribeInKey(N(key), IONIAN));
    }

    [Theory]
    [InlineData("A", "C4", "C4")]
    [InlineData("C", "E4", "E♮4")]
    [InlineData("C", "Eb4", "E4")]
    public void DescribeInMinorKey(string key, string note, string expected)
    {
        Assert.Equal(expected, P(note).DescribeInKey(N(key), AEOLIAN));
    }

    [Theory]
    [InlineData("foobar")]
    [InlineData("GA4")]
    [InlineData("C#b7")]
    [InlineData("4C")]
    public void ParseIntervalFailure(string input)
    {
        Assert.Throws<FormatException>(() => Pitch.Parse(input));
    }
}

#pragma warning restore CS1591
