using System;
using System.Text;
using System.Text.RegularExpressions;
using Util;

using static Model.Constants;

namespace Model
{
    public class Accidental : IEquatable<Accidental>
    {
        public int Semitones { get; }

        public Accidental(int semitones)
        {
            Semitones = semitones;
        }

        public bool Equals(Accidental other)
        {
            return Semitones == other.Semitones;
        }

        override public string ToString()
        {
            return $"Accidental[Semitones={Semitones}]";
        }

        public string Description
        {
            get {
                switch(Semitones)
                {
                    case -2: return "𝄫";
                    case 0: return "♮";
                    case 2: return "𝄪";
                }

                var result = new StringBuilder();
                var symbol = Semitones < 0 ? '♭' : '♯';
                var length = Math.Abs(Semitones);
                for (var i = 0; i < length; i++)
                {
                    result.Append(symbol);
                }
                return result.ToString();
            }
        }

        public bool Enharmonic(Accidental other)
        {
            return Semitones.Modulus(SEMITONES_PER_OCTAVE) ==
                other.Semitones.Modulus(SEMITONES_PER_OCTAVE);
        }

        public static Accidental Parse(String input)
        {
            if (input.Equals("") || input.Equals("nat"))
            {
                return NATURAL;
            }

            if (Regex.IsMatch(input, "^b+$"))
            {
                return new Accidental(-input.Length);
            }

            if (Regex.IsMatch(input, "^#+$"))
            {
                return new Accidental(input.Length);
            }

            throw new FormatException($"{input} is not a valid accidental");
        }

        public static readonly Accidental NATURAL = new Accidental(0);
        public static readonly Accidental SHARP = new Accidental(1);
        public static readonly Accidental DOUBLE_SHARP = new Accidental(2);
        public static readonly Accidental FLAT = new Accidental(-1);
        public static readonly Accidental DOUBLE_FLAT = new Accidental(-2);
    }
}
