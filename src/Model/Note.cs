using System;
using Cadd9.Util;

using static Cadd9.Model.Constants;
using static Cadd9.Model.Name;
using static Cadd9.Model.Accidental;

namespace Cadd9.Model
{
    ///<summary>
    ///  Represents a note <see cref="Name"/> with an associated modifying <see cref="Accidental"/>.
    ///</summary>
    public class Note : IEquatable<Note>
    {
        ///<summary>
        ///  The <see cref="Name"/> associated with this Note
        ///</summary>
        public Name Name { get; }

        ///<summary>
        ///  The <see cref="Accidental"/> modifying this Note
        ///</summary>
        public Accidental Accidental { get; }

        ///<summary>
        ///  Returns a new Note
        ///</summary>
        ///<param name="name">The <see cref="Name"/> associated with this Note</param>
        ///<param name="accidental">The <see cref="Accidental"/> modifying this Note</param>
        public Note(Name name, Accidental accidental) {
            this.Name = name;
            this.Accidental = accidental;
        }

        ///<summary>
        ///  Returns a string representation of this Note, primarily for debugging purposes.
        ///</summary>
        override public string ToString() => $"Note[Name={Name}, Accidental={Accidental}]";

        ///<summary>
        ///  A formatted representation of this Note as a UTF-8 string.
        ///</summary>
        public string Description
        {
            get => $"{Name}{Accidental.Description}";
        }

        ///<summary>
        ///  The pitch class (0 to 11) of this Note.
        ///</summary>
        ///<remarks>
        ///  The concept of pitch class is often used in post-tonal music to describe pitches without being based in any
        ///  given heptatonic scale. C is equivalent to a pitch class of 0, and each pitch class going up is separated
        ///  by a semitone. All Notes that are enharmonic by definition have the same pitch class.
        ///</remarks>
        public int PitchClass
        {
            get => Interval.Between(new Note(C, NATURAL), this).SpecificWidth;
        }

        ///<summary>
        ///  Produces a new Note by applying the given <see cref="Interval"/>.
        ///</summary>
        ///<param name="interval">The width between the current Note and the new Note to be generated.</param>
        public Note Apply(Interval interval)
        {
            Name nextName = (Name) ((int) Name + (int)interval.GenericWidth).Modulus(NAMES_PER_OCTAVE);

            // A generic interval implicates a certain specific interval based on the distance between those natural
            // names in the C major scale. For example, going from G♮ to C♮ (a "fourth" or generic=3) is 5 semitones.
            //
            // The distance is further modified by the current accidental. Shifting from a G𝄫 to a C♮ is 7 semitones.
            //
            // The desired specific interval therefore determines the accidental of the new note. If we are trying to
            // raise G𝄫 by an augmented third (generic=3, specific=6) then we must lower C♮ (7 semitones away) to C♭.
            //
            // So the next accidental should be:
            //   6 [specific interval] - (5 [interval from G to C] - (-2) [current accidental]) = -1
            // or equivalently
            //   -2 [current accidental] + 6 [specific interval] - 5 [interval from G to C] = -1
            int accidentalSemitones = Accidental.Semitones + interval.SpecificWidth
                - Interval.Between(Name, nextName).SpecificWidth;
            
            // The "demodulus" operator here produces the enharmonic accidental closest to natural; for example 11
            // sharps would be converted to 1 flat.
            Accidental nextAccidental = new Accidental(accidentalSemitones.Demodulus(SEMITONES_PER_OCTAVE));

            return new Note(nextName, nextAccidental);
        }

        ///<summary>
        ///  Parses the given input as a Note
        ///</summary>
        ///<param name="input">The input to parse</param>
        ///<exception cref="FormatException">The given input cannot be parsed</exception>
        ///<remarks>
        ///  The input is treated as case-insensitive. The first character is parsed as a <see cref="Name" /> while the
        ///  rest is parsed according to <see cref="Accidental.Parse(string)" />. Examples of valid Notes would include
        ///  "B", "Ebb", "c#"
        ///</remarks>
        public static Note Parse(string input) =>
            new Note(Enum.Parse<Name>(input.Substring(0, 1).ToUpper()), Accidental.Parse(input.Substring(1).ToLower()));

        ///<summary>
        ///  Determines whether two Notes are enharmonically equivalent
        ///</summary>
        ///<param name="other">The other Note to compare</param>
        ///<remarks>
        ///  Two Notes are enharmonic if they map to the same key on a keyboard: for example, while D♯ and E♭ are
        ///  distinct notes that play different musical roles, they are enharmonic.
        ///</remarks>
        public bool Enharmonic(Note other) => PitchClass == other.PitchClass;

        #region Value equality

        ///<summary>
        ///  Determines whether two Notes are value-equivalent
        ///</summary>
        ///<param name="other">The other Note to compare</param>
        public bool Equals(Note other) => Name.Equals(other.Name) && Accidental.Equals(other.Accidental);

        private static readonly int HASH_CODE_SEED = 59;
        private static readonly int HASH_CODE_STEP = 223;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Notes are guaranteed to produce the same
        ///  result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                hashCode = (HASH_CODE_STEP * hashCode) ^ (int) Name;
                hashCode = (HASH_CODE_STEP * hashCode) ^ Accidental.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}