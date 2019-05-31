using Util;
using System;
using System.Text.RegularExpressions;

using static Model.Constants;

namespace Model
{
    public class Pitch : IEquatable<Pitch>
    {
        public Note Note { get; }
        public int Octave { get; }

        public Pitch(Note note, int octave) {
            this.Note = note;
            this.Octave = octave;
        }

        public Pitch(Name name, Accidental accidental, int octave) {
            this.Note = new Note(name, accidental);
            this.Octave = octave;
        }

        public bool Equals(Pitch other)
        {
            return Note.Equals(other.Note) && Octave == other.Octave;
        }

        override public string ToString()
        {
            return $"Pitch[Note={Note}, Octave={Octave}]";
        }

        public string Description
        {
            get
            {
                return $"{Note.Description}{Octave}";
            }
        }

        public int Midi
        {
            get
            {
                return MIDDLE_C_MIDI_NUMBER + Note.PitchClass +
                    SEMITONES_PER_OCTAVE * (Octave - MIDDLE_C_OCTAVE);
            }
        }

        public string DescribeInKey(Note key, Mode signature)
        {
            Accidental forKey = signature.AccidentalFor(key, Note.Name);
            return forKey.Equals(Note.Accidental) ? $"{Note.Name}{Octave}" : Description;
        }

        ///<summary>
        ///Returns a new Note transposed by the given number of octaves.
        ///</summary>
        ///<param name="octaves">
        ///The number of octaves to transpose. If positive, the pitch will increase. If
        ///negative, it will decrease.
        ///</param>
        public Pitch Transpose(int octaves)
        {
            return new Pitch(Note, Octave + octaves);
        }

        ///<summary>
        ///Returns a new Note transposed to the given octave.
        ///</summary>
        ///<param name="octave">
        ///The octave of the desired note.
        ///</param>
        public Pitch InOctave(int octave)
        {
            return new Pitch(Note, octave);
        }

        ///<summary>
        ///Produces a new (higher) Pitch by applying the given Interval.
        ///</summary>
        ///<param name="interval">
        ///Describes how to generate the new pitch. The Note Name will be incremented
        ///by interval.Generic, while the pitch will be incremented by interval.Specific
        ///(in semitones). The new Accidental will be set as appropriate to this pitch.
        ///</param>
        public Pitch Apply(Interval interval)
        {
            // Names are enumerated starting at C, and by convention, so are octave numbers.
            // Thus, the number of octaves shifted by this interval is entirely dependent on
            // the number of times the name "wraps around" back to C=0.
            int octaveShift = ((int) Note.Name + interval.Generic) / NAMES_PER_OCTAVE;

            return new Pitch(Note.Apply(interval), Octave + octaveShift);
        }

        public static Pitch Parse(string input)
        {
            var match = Regex.Match(input, @"^([^\d\+-]+)([\+-]?\d+)$");
            if (!match.Success)
            {
                throw new FormatException("Unrecognized pitch: " + input);
            }
            return new Pitch(
                Note.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value)
            );
        }

        public bool Enharmonic(Pitch other)
        {
            return Midi == other.Midi;
        }
    }
}