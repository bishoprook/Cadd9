using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Model;

using static Model.Mode;
using static Model.Chord;
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

    public static IEnumerable<object[]> ModeChords =>
        new List<object[]>
        {
            new object[] { IONIAN, 0, 3, MAJOR_TRIAD },
            new object[] { PHRYGIAN, 2, 4, DOMINANT_SEVENTH },
            new object[] { DORIAN, 5, 4, new Chord("P1", "m3", "d5", "m7") },
            new object[] { MIXOLYDIAN, 2, 4, new Chord("P1", "m3", "d5", "m7") }
        };

    [Theory] [MemberData(nameof(ModeChords))]
    public void ChordsFromModes(Mode mode, int degree, int width, Chord expected)
    {
        Assert.Equal(expected, mode.Chord(degree, width));
    }
}