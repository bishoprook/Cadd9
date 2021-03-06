using System.Collections.Generic;
using System.Linq;
using Xunit;
using Cadd9.Model;

using static Cadd9.Model.Accidental;
using static Cadd9.Model.Degree;
using static Cadd9.Model.Mode;
using static Cadd9.Model.Quality;
using static Cadd9.Model.Name;
using static Cadd9.Util.ParseHelpers;

#pragma warning disable CS1591

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
        Assert.Equal(expected.Intervals, intervals);
    }

    public static IEnumerable<object[]> ModeChords =>
        new List<object[]>
        {
            new object[] { IONIAN, I, 3, MAJOR_TRIAD },
            new object[] { PHRYGIAN, III, 4, DOMINANT_SEVENTH },
            new object[] { DORIAN, VI, 4, new Quality("P1", "m3", "d5", "m7") },
            new object[] { MIXOLYDIAN, III, 4, new Quality("P1", "m3", "d5", "m7") }
        };

    [Theory] [MemberData(nameof(ModeChords))]
    public void ChordsFromModes(Mode mode, Degree degree, int width, Quality expected)
    {
        Assert.Equal(expected, mode.DiatonicChord(degree, width));
    }

    public static IEnumerable<object[]> ModeScales =>
        new List<object[]>
        {
            new object[] { AEOLIAN, P("Ab2"), "Ab2 Bb2 Cb3 Db3 Eb3 Fb3 Gb3 Ab3" },
            new object[] { LYDIAN, P("F3"), "F3 G3 A3 B3 C4 D4 E4 F4" },
            new object[] { DORIAN, P("G5"), "G5 A5 Bb5 C6 D6 E6 F6 G6" }
        };
    
    [Theory] [MemberData(nameof(ModeScales))]
    public void ScalesFromModes(Mode mode, Pitch tonic, string scale)
    {
        IEnumerable<Pitch> expected = scale.Split(" ").Select(P);
        Assert.Equal(expected, mode.Scale(tonic).Take(8));
    }

    public static IEnumerable<object[]> AccidentalForKeyData =>
        new List<object[]>
        {
            new object[] { IONIAN, N("C"), D, NATURAL },
            new object[] { IONIAN, N("G"), F, SHARP },
            new object[] { IONIAN, N("Ab"), D, FLAT },
            new object[] { AEOLIAN, N("G"), B, FLAT },
            new object[] { AEOLIAN, N("B"), C, SHARP }
        };
    [Theory] [MemberData(nameof(AccidentalForKeyData))]
    public void AccidentalForKey(Mode mode, Note key, Name name, Accidental expected)
    {
        Assert.Equal(expected, mode.AccidentalFor(key, name));
    }
}

#pragma warning restore CS1591
