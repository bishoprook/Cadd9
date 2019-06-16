using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Cadd9.Model;

using static Cadd9.Model.Quality;
using static Cadd9.Model.Quality.Alteration;
using static Cadd9.Util.ParseHelpers;

#pragma warning disable CS1591

public class ChordTest
{
    public static IEnumerable<object[]> AlterData =>
        new List<object[]>
        {
            new object[] { MAJOR_TRIAD, SUS4, "1", "4", "5" },
            new object[] { MINOR_TRIAD, SUS2, "1", "2", "5" },
            new object[] { DOMINANT_SEVENTH, FLAT5, "1", "3", "b5", "b7" },
            new object[] { SIX_NINE, SHARP5, "1", "3", "#5", "6", "9" },
            new object[] { MAJOR_TRIAD, DROP3, "1", "5" },
            new object[] { MAJOR_TRIAD, SHARP9, "1", "3", "5", "#9" }
        };
    [Theory]
    [MemberData(nameof(AlterData))]
    public void CanAlter(Quality start, Alteration alt, params string[] intervals)
    {
        Assert.Equal(intervals.Select(W), start.Alter(alt).Intervals);
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

#pragma warning restore CS1591
