namespace Cadd9.Model
{
    ///<summary>
    ///  Defines several frequently-used music theory constants.
    ///</summary>
    public static class Constants
    {
        ///<summary>
        ///  The number of semitones per octave
        ///</summary>
        ///<remarks>
        ///  In Western tonal music using equal temperament, an octave is a doubling of frequency, and it is further
        ///  subdivided into 12 semitones where each is in a 2^(1/12):1 ratio with the one before it.
        ///</remarks>
        public const int SEMITONES_PER_OCTAVE = 12;

        ///<summary>
        ///  The number of note names per octave
        ///</summary>
        ///<remarks>
        ///  Western tonal music is built around the diatonic scale, which is a heptatonic scale (containing seven
        ///  tones) arranged so there are 2 half-steps (single semitone) and 5 whole-steps (two semitones) separating
        ///  each. The arrangement of steps and half-steps determines the <see cref="Mode"/> of the scale.
        ///</remarks>
        public const int NAMES_PER_OCTAVE = 7;

        ///<summary>
        ///  The octave number of middle C
        ///</summary>
        ///<remarks>
        ///  There is no universal definition: middle C is also sometimes labeled as C3.
        ///</remarks>
        public const int MIDDLE_C_OCTAVE = 4;

        ///<summary>
        ///  The MIDI note number corresponding to middle C
        ///</summary>
        ///<remarks>
        ///  This is not a universal definition. In fact as far as the MIDI standard is concerned, the note numbers are
        ///  not strictly related to any musical pitches. They are simply a set of 127 sequential numbers that can be
        ///  turned on and off with control messages. But 60 is used by most device manufacturers.
        ///</remarks>
        public const int MIDDLE_C_MIDI_NUMBER = 60;
    }
}