using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Model;

using static Model.Quality;
using static Util.ParseHelpers;

public class ChordTest
{
    public static IEnumerable<object[]> AddModifierData =>
        new List<object[]>
        {
            new object[] { MAJOR_TRIAD, MAJOR_SEVENTH, "7" },
            new object[] { MAJOR_TRIAD, SEVENTH_SHARP_NINE, "b7", "#9" }
        };
    [Theory]
    [MemberData(nameof(AddModifierData))]
    public void CanAddModifiers(Quality input, Quality expected, params string[] adds)
    {
        Assert.Equal(expected, input.Add(adds.Select(I).ToArray()));
    }

    public static IEnumerable<object[]> ApplyPitchData =>
        new List<object[]>
        {
            new object[] { MAJOR_TRIAD, P("Ab3"), P("Ab3"), P("C4"), P("Eb4") },
            new object[] { DOMINANT_SEVENTH, P("D#4"), P("D#4"), P("F##4"), P("A#4"), P("C#5") },
        };
    [Theory]
    [MemberData(nameof(ApplyPitchData))]
    public void CanApply(Quality chord, Pitch root, params Pitch[] expected)
    {
        Assert.Equal(expected.ToList(), chord.Apply(root).ToList());
        Assert.Equal(expected.Select(p => p.Note).ToList(), chord.Apply(root.Note).ToList());
    }
}