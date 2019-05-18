using System;
using System.Collections;
using System.Collections.Generic;

using Model;
using Xunit;

using static Model.Name;
using static Model.Accidental;
using static Util.ParseHelpers;

public class PitchTest
{
    [Fact]
    public void CanTransposeUp()
    {
        Pitch input = new Pitch(new Note(F, SHARP), 3);
        Pitch output = input.Transpose(2);
        Assert.Equal(new Pitch(F, SHARP, 5), output);
    }

    [Fact]
    public void CanTransposeDown()
    {
        Pitch input = new Pitch(new Note(G, FLAT), 3);
        Pitch output = input.Transpose(-2);
        Assert.Equal(new Pitch(G, FLAT, 1), output);
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
            new object[] { new Pitch(E, NATURAL, 17), "E17" },
            new object[] { new Pitch(C, NATURAL, 3), "Cnat+3" }
        };

    [Theory] [MemberData(nameof(ParseExamples))]
    public void CanParse(Pitch expected, string input)
    {
        Assert.Equal(expected, Pitch.Parse(input));
    }
}