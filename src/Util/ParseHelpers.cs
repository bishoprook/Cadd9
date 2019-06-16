using Cadd9.Model;

namespace Cadd9.Util
{
    ///<summary>
    ///  Contains helper methods to parse notes, pitches, and intervals
    ///</summary>
    public static class ParseHelpers
    {
        ///<summary>
        ///  Parses the given input as a <see cref="Note" />
        ///</summary>
        public static Note N(string input)
        {
            return Note.Parse(input);
        }

        ///<summary>
        ///  Parses the given input as a <see cref="Pitch" />
        ///</summary>
        public static Pitch P(string input)
        {
            return Pitch.Parse(input);
        }

        ///<summary>
        ///  Parses the given input as an <see cref="Interval" />
        ///</summary>
        ///<remarks>
        ///  The letter W (for Width) is used instead of I to prevent collision with <see cref="Degree.I" /> when both
        ///  are statically included in the same file.
        ///</remarks>
        public static Interval W(string input)
        {
            return Interval.Parse(input);
        }
    }
}