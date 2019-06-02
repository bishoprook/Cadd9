using Cadd9.Model;

namespace Cadd9.Util
{
    public static class ParseHelpers
    {
        public static Note N(string input)
        {
            return Note.Parse(input);
        }

        public static Pitch P(string input)
        {
            return Pitch.Parse(input);
        }

        public static Interval I(string input)
        {
            return Interval.Parse(input);
        }
    }
}