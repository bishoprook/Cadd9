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
        public static Interval I(string input)
        {
            return Interval.Parse(input);
        }
    }
}