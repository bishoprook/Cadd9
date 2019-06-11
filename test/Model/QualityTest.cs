using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Cadd9.Model;

using static Cadd9.Model.Quality;
using static Cadd9.Model.Quality.Modification;
using static Cadd9.Util.ParseHelpers;

#pragma warning disable CS1591

public class ChordTest
{
    public static IEnumerable<object[]> AddExtensionData =>
        new List<object[]>
        {
            new object[] { MAJOR_TRIAD, MAJOR_SEVENTH, "7" },
            new object[] { MAJOR_TRIAD, SEVENTH_SHARP_NINE, "b7", "#9" },
        };
    [Theory]
    [MemberData(nameof(AddExtensionData))]
    public void CanAddExtensions(Quality input, Quality expected, params string[] adds)
    {
        Assert.Equal(expected, adds.Select(I).Aggregate(input, (q, i) => q.Add(i)));
    }

    public static IEnumerable<object[]> ModifyData =>
        new List<object[]>
        {
            new object[] { MAJOR_TRIAD, SUS4, "1", "4", "5" },
            new object[] { MINOR_TRIAD, SUS2, "1", "2", "5" },
            new object[] { DOMINANT_SEVENTH, FLAT5, "1", "3", "b5", "b7" },
            new object[] { MAJOR_NINTH, SHARP5, "1", "3", "#5", "7", "9" }
        };
    [Theory]
    [MemberData(nameof(ModifyData))]
    public void CanModify(Quality start, Modification mod, params string[] intervals)
    {
        Assert.Equal(intervals.Select(I), start.Modify(mod).Intervals);
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
