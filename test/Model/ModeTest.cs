using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Model;

using static Model.Mode;
using static Util.ParseHelpers;

public class ModeTest
{
    public static IEnumerable<object[]> ModeShifts =>
        new List<object[]>
        {
            new object[] { 0, IONIAN },
            new object[] { 1, DORIAN },
            new object[] { 2, PHRYGIAN },
            new object[] { 3, LYDIAN },
            new object[] { 4, MIXOLYDIAN },
            new object[] { 5, AEOLIAN },
            new object[] { 6, LOCRIAN }
        };
    
    [Theory] [MemberData(nameof(ModeShifts))]
    public void CanConstructModes(int shift, Mode expected)
    {
        Note[] cMajor = "C D E F G A B".Split(" ").Select(N).ToArray();
        Note[] shifted = cMajor.Skip(shift).Concat(cMajor.Take(shift)).ToArray();
        Interval[] intervals = shifted.Select(n => Interval.Between(shifted[0], n)).ToArray();
        Assert.Equal(expected, new Mode(intervals));
    }
}