using System;
using System.Text.RegularExpressions;
using Cadd9.Util;

using static Cadd9.Model.Constants;

namespace Cadd9.Model
{
    ///<summary>
    ///  A particular musical pitch achieved by playing a <see cref="Note"/> in a particular octave
    ///</summary>
    public class Pitch : IEquatable<Pitch>
    {
        ///<summary>
        ///  The <see cref="Note"/> represented by this Pitch
        ///</summary>
        public Note Note { get; }

        ///<summary>
        ///  The octave corresponding to this Pitch, where middle C = C4
        ///</summary>
        public int Octave { get; }

        ///<summary>
        ///  Returns a new Pitch
        ///</summary>
        ///<param name="note">The <see cref="Note"/> to represent this Pitch</param>
        ///<param name="octave">The octave corresponding to this Pitch</param>
        public Pitch(Note note, int octave) {
            this.Note = note;
            this.Octave = octave;
        }

        ///<summary>
        ///  Returns a new Pitch
        ///</summary>
        ///<param name="name">The <see cref="Name"/> of this Pitch's <see cref="Note"/></param>
        ///<param name="accidental">The <see cref="Accidental"/> of this Pitch's <see cref="Note"/></param>
        ///<param name="octave">The octave corresponding to this Pitch</param>
        public Pitch(Name name, Accidental accidental, int octave) {
            this.Note = new Note(name, accidental);
            this.Octave = octave;
        }

        ///<summary>
        ///  Returns a string representation of this Pitch, primarily for debugging purposes.
        ///</summary>
        override public string ToString() => $"Pitch[Note={Note}, Octave={Octave}]";

        ///<summary>
        ///  A formatted representation of this Pitch as a UTF-8 string.
        ///</summary>
        public string Description
        {
            get => $"{Note.Description}{Octave}";
        }

        ///<summary>
        ///  The MIDI note number associated with this Pitch
        ///</summary>
        ///<remarks>
        ///  Though there is no universal standard for what octave represents middle-C, we treat C-4 as middle C, with
        ///  the MIDI note number 60.
        ///</remarks>
        public int Midi
        {
            get => MIDDLE_C_MIDI_NUMBER + SEMITONES_PER_OCTAVE * (Octave - MIDDLE_C_OCTAVE) + Note.PitchClass;
        }

        ///<summary>
        ///  A formatted representation of this Pitch as a UTF-8 string in the given key.
        ///</summary>
        ///<param name="key">The tonic of the key</param>
        ///<param name="signature">The mode of the key</param>
        ///<remarks>
        ///  This method will include a symbol for the accidental only if it is different than the associated
        ///  <see cref="Name"/> in the given key. For example, C♮4 would be rendered "C4" in the key of C Ionian, but
        ///  would be "C♮4" in the key of D Ionian, because in that key a C would normally be sharp. Likewise, in D
        ///  Ionian the pitch F♯3 would be rendered as "F3" because F is normally sharp in that key.
        ///</remarks>
        public string DescribeInKey(Note key, Mode signature)
        {
            var forKey = signature.AccidentalFor(key, Note.Name);
            return forKey.Equals(Note.Accidental) ? $"{Note.Name}{Octave}" : Description;
        }

        ///<summary>
        ///  Returns a new Note transposed by the given number of octaves.
        ///</summary>
        ///<param name="octaves">The number of octaves to transpose.</param>
        ///<remarks>
        ///  If <c>octaves</c> is positive, the pitch will increase. If negative, it will decrease.
        ///</remarks>
        public Pitch Transpose(int octaves) => new Pitch(Note, Octave + octaves);

        ///<summary>
        ///  Returns a new Note transposed into the given octave.
        ///</summary>
        ///<param name="octave">The octave of the desired note.</param>
        public Pitch InOctave(int octave) => new Pitch(Note, octave);

        ///<summary>
        ///  Produces a new (higher) Pitch by applying the given <see cref="Interval"/>.
        ///</summary>
        ///<param name="interval">The <see cref="Interval"/> between this and the new Pitch</param>
        ///<remarks>
        ///  The Note <see cref="Name"/> will be incremented by <c>interval.Generic</c>, while the pitch will be
        ///  incremented by <c>interval.Specific</c> (in semitones). The new <see cref="Accidental"/> will be set as
        ///  appropriate to achieve this pitch.
        ///</remarks>
        public Pitch Apply(Interval interval)
        {
            // Names are enumerated starting at C, and by convention, so are octave numbers. Thus, the number of octaves
            // shifted by this interval is entirely dependent on the number of times the name "wraps around" back to
            // C=0.
            int octaveShift = ((int) Note.Name + (int) interval.GenericWidth) / NAMES_PER_OCTAVE;

            return new Pitch(Note.Apply(interval), Octave + octaveShift);
        }

        ///<summary>
        ///  Parses the given input as a Pitch
        ///</summary>
        ///<param name="input">The input to parse</param>
        ///<exception cref="FormatException">The given input cannot be parsed</exception>
        ///<remarks>
        ///  The input is treated as case-insensitive. The first character is parsed as a <see cref="Name" /> and the
        ///  rest is broken into an accidental part and an octave. The accidental is parsed according to
        ///  <see cref="Accidental.Parse(string)" />. Examples of valid Pitches would include "B2", "Ebb17", "c#-1"
        ///</remarks>
        public static Pitch Parse(string input)
        {
            var match = Regex.Match(input, @"^([^\d\+-]+)([\+-]?\d+)$");
            if (!match.Success)
            {
                throw new FormatException("Unrecognized pitch: " + input);
            }
            return new Pitch(Note.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
        }

        ///<summary>
        ///  Determines whether two Pitches are enharmonically equivalent
        ///</summary>
        ///<param name="other">The other Pitch to compare</param>
        ///<remarks>
        ///  Two Pitches are enharmonic if they map to the same key on a keyboard: for example, while D♯4 and E♭4 are
        ///  distinct notes that play different musical roles, they are enharmonic.
        ///</remarks>
        public bool Enharmonic(Pitch other) => Midi == other.Midi;

        #region Value equality

        ///<summary>
        ///  Determines whether two Pitches are value-equivalent
        ///</summary>
        ///<param name="other">The other Pitch to compare</param>
        public bool Equals(Pitch other) => Note.Equals(other.Note) && Octave == other.Octave;

        private static readonly int HASH_CODE_SEED = 59;
        private static readonly int HASH_CODE_STEP = 223;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Pitches are guaranteed to produce the same
        ///  result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                hashCode = (HASH_CODE_STEP * hashCode) ^ Note.GetHashCode();
                hashCode = (HASH_CODE_STEP * hashCode) ^ Octave;
                return hashCode;
            }
        }

        #endregion
    }
}