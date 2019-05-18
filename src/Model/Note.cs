using System;
using Util;

using static Model.Constants;
using static Model.Name;
using static Model.Accidental;

namespace Model
{
    public struct Note
    {
        private static readonly Note C_NATURAL = new Note(C, NATURAL);
    
        public Name Name { get; }
        public Accidental Accidental { get; }

        public Note(Name name, Accidental accidental) {
            this.Name = name;
            this.Accidental = accidental;
        }

        public string Describe()
        {
            return Name.Describe() + Accidental.Describe();
        }

        override public string ToString()
        {
            return $"Note[Name={Name}, Accidental={Accidental}]";
        }

        public int PitchClass()
        {
            return Interval.Between(C_NATURAL, this).Specific;
        }

        ///<summary>
        ///Produces a new Note by applying the given Interval.
        ///</summary>
        ///<param name="interval">
        ///Describes how to generate the new note. The new note's Name will be incremented
        ///by interval.Generic, while the new note's pitch will be incremented by
        ///interval.Specific. The new note's Accidental will be set appropriately to this
        ///new pitch.
        ///</param>
        public Note Apply(Interval interval)
        {
            // Names are enumerated starting at C, and by convention, so are octave numbers.
            // Thus, the number of octaves shifted by this interval is entirely dependent on
            // the number of times the name "wraps around" back to C=0.
            Name nextName = (Name) ((int) Name + interval.Generic).Modulus(NAMES_PER_OCTAVE);

            // A generic interval implicates a certain specific interval based on the distance
            // between those natural names in the C major scale. For example, going from G♮ to
            // C♮ (a "fourth" or generic=3) is 5 semitones.
            //
            // The distance is further modified by the current accidental. Shifting from a
            // G𝄫 to a C♮ is 7 semitones.
            //
            // The desired specific interval therefore determines the accidental of the new note.
            // If we are trying to raise G𝄫 by an augmented third (generic=3, specific=6) then
            // we must lower C♮ (7 semitones away) to C♭.
            //
            // So the next accidental should be:
            // 6 [spec interval] - (5 [G to C distance] - (-2) [current accidental]) = -1
            // or equivalently
            // -2 [current accidental] + 6 [spec interval] - 5 [generic interval] = -1
            int accidentalSemitones = (int)Accidental + interval.Specific
                - Interval.Between(Name, nextName).Specific;
            
            // The "demodulus" operator here produces the enharmonic accidental closest to natural;
            // for example 11 sharps would be converted to 1 flat.
            Accidental nextAccidental = (Accidental) accidentalSemitones.Demodulus(SEMITONES_PER_OCTAVE);

            return new Note(nextName, nextAccidental);
        }

        public static Note Parse(string input)
        {
            return new Note(
                input.Substring(0, 1).ToUpper().ParseEnum<Name>(),
                input.Substring(1).ToLower().ParseEnum<Accidental>()
            );
        }

        public bool Enharmonic(Note other)
        {
            return PitchClass() == other.PitchClass();
        }
    }
}