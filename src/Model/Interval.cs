using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Util;

using static Model.Constants;
using static Model.Name;

namespace Model
{
    public struct Interval
    {
        private static readonly bool[] IS_PERFECT = new bool[] {true, false, false, true, true, false, false};
        private static readonly int[] MAJOR_SPECIFIC_INTERVAL = new int[] {0, 2, 4, 5, 7, 9, 11};
        private static readonly string[] GENERIC_INTERVAL_NAMES = new string[]
        {
            "Unison", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh",
            "Octave", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth"
        };
        private static readonly Dictionary<int, string> PERFECT_MODIFIERS = new Dictionary<int, string>()
        {
            [-1] = "Diminished", [0] = "Perfect", [1] = "Augmented"
        };
        private static readonly Dictionary<int, string> PERFECT_ABBREVIATIONS = new Dictionary<int, string>()
        {
            [-1] = "d", [0] = "P", [1] = "A"
        };
        private static readonly Dictionary<int, string> IMPERFECT_MODIFIERS = new Dictionary<int, string>()
        {
            [-2] = "Diminished", [-1] = "Minor", [0] = "Major", [1] = "Augmented"
        };
        private static readonly Dictionary<int, string> IMPERFECT_ABBREVIATIONS = new Dictionary<int, string>()
        {
            [-2] = "d", [-1] = "m", [0] = "M", [1] = "A"
        };

        public int Generic { get; }
        public int Specific { get; }

        public Interval(int generic, int specific)
        {
            this.Generic = generic;
            this.Specific = specific;
        }
        
        override public string ToString()
        {
            return $"Interval[Generic={Generic}, Specific={Specific}]";
        }

        public string Describe()
        {
            int intervalDiff = Specific.Modulus(SEMITONES_PER_OCTAVE) -
                MAJOR_SPECIFIC_INTERVAL[Generic.Modulus(NAMES_PER_OCTAVE)];
            
            var lookup = IS_PERFECT[Generic.Modulus(NAMES_PER_OCTAVE)] ?
                PERFECT_MODIFIERS : IMPERFECT_MODIFIERS;
            
            return $"{lookup[intervalDiff]} {GenericIntervalName(Generic)}";
        }

        private static string GenericIntervalName(int generic)
        {
            return generic < GENERIC_INTERVAL_NAMES.Length ?
                GENERIC_INTERVAL_NAMES[generic] : (generic + 1).Ordinal();
        }

        public string Abbreviate()
        {
            int intervalDiff = Specific.Modulus(SEMITONES_PER_OCTAVE) -
                MAJOR_SPECIFIC_INTERVAL[Generic.Modulus(NAMES_PER_OCTAVE)];
            
            var lookup = IS_PERFECT[Generic.Modulus(NAMES_PER_OCTAVE)] ?
                PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
            
            return $"{lookup[intervalDiff]}{Generic + 1}";
        }

        private static Interval ParseFormal(Match match)
        {
            int generic = int.Parse(match.Groups[2].Value) - 1;
            bool isPerfect = IS_PERFECT[generic.Modulus(NAMES_PER_OCTAVE)];
            
            string modifierPart = match.Groups[1].Value;
            if (isPerfect && (modifierPart.Equals("m") || modifierPart.Equals("M")))
            {
                throw new ArgumentException($"{GenericIntervalName(generic)} is a perfect interval");
            }
            if (!isPerfect && (modifierPart.Equals("P")))
            {
                throw new ArgumentException($"{GenericIntervalName(generic)} is not a perfect interval");
            }

            var lookup = isPerfect ? PERFECT_ABBREVIATIONS : IMPERFECT_ABBREVIATIONS;
            int modifier = lookup.Where(kvp => kvp.Value.Equals(modifierPart)).First().Key;

            int specific = SEMITONES_PER_OCTAVE * (generic / NAMES_PER_OCTAVE) +
                MAJOR_SPECIFIC_INTERVAL[generic % NAMES_PER_OCTAVE] +
                modifier;

            return new Interval(generic, specific);
        }

        private static Interval ParseSimple(Match match)
        {
            int generic = int.Parse(match.Groups[2].Value) - 1;
            
            string modifierPart = match.Groups[1].Value;
            Accidental accidental = modifierPart.ParseEnum<Accidental>();

            int specific = SEMITONES_PER_OCTAVE * (generic / NAMES_PER_OCTAVE) +
                MAJOR_SPECIFIC_INTERVAL[generic % NAMES_PER_OCTAVE] +
                (int) accidental;

            return new Interval(generic, specific);
        }

        public static Interval Parse(string input)
        {
            var matchFormal = Regex.Match(input, @"^([PdmMA])(\d+)$");
            var matchSimple = Regex.Match(input, @"^([b#]*)(\d+)$");
            if (matchFormal.Success)
            {
                return ParseFormal(matchFormal);
            }
            if (matchSimple.Success)
            {
                return ParseSimple(matchSimple);
            }
            
            throw new FormatException("Unrecognized interval: " + input);
        }

        public bool Enharmonic(Interval other)
        {
            return Specific == other.Specific;
        }

        public static Interval Between(Name first, Name second)
        {
            int generic = (second - first).Modulus(NAMES_PER_OCTAVE);
            int specific = (MAJOR_SPECIFIC_INTERVAL[(int) second] - MAJOR_SPECIFIC_INTERVAL[(int) first])
                .Modulus(SEMITONES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        public static Interval Between(Note first, Note second)
        {
            int generic = (second.Name - first.Name).Modulus(NAMES_PER_OCTAVE);
            int firstPC = MAJOR_SPECIFIC_INTERVAL[(int) first.Name] + (int) first.Accidental;
            int secondPC = MAJOR_SPECIFIC_INTERVAL[(int) second.Name] + (int) second.Accidental;
            int specific = (secondPC - firstPC).Modulus(SEMITONES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        public static Interval Between(Pitch first, Pitch second)
        {
            int specific = second.Midi() - first.Midi();
            int generic = (second.Note.Name - first.Note.Name).Modulus(NAMES_PER_OCTAVE) +
                ((specific / SEMITONES_PER_OCTAVE) * NAMES_PER_OCTAVE);
            return new Interval(generic, specific);
        }

        public static Interval operator+(Interval a, Interval b)
        {
            return new Interval(a.Generic + b.Generic, a.Specific + b.Specific);
        }

        public static Interval operator-(Interval a, Interval b)
        {
            return new Interval(a.Generic - b.Generic, a.Specific - b.Specific);
        }

        public static readonly Interval PERFECT_UNISON = new Interval(0, 0);
        public static readonly Interval DIMINISHED_SECOND = new Interval(1, 0);
        public static readonly Interval MINOR_SECOND = new Interval(1, 1);
        public static readonly Interval MAJOR_SECOND = new Interval(1, 2);
        public static readonly Interval AUGMENTED_SECOND = new Interval(1, 3);
        public static readonly Interval MINOR_THIRD = new Interval(2, 3);
        public static readonly Interval MAJOR_THIRD = new Interval(2, 4);
        public static readonly Interval DIMINISHED_FOURTH = new Interval(3, 4);
        public static readonly Interval PERFECT_FOURTH = new Interval(3, 5);
        public static readonly Interval AUGMENTED_FOURTH = new Interval(3, 6);
        public static readonly Interval DIMINISHED_FIFTH = new Interval(4, 6);
        public static readonly Interval PERFECT_FIFTH = new Interval(4, 7);
        public static readonly Interval MINOR_SIXTH = new Interval(5, 8);
        public static readonly Interval MAJOR_SIXTH = new Interval(5, 9);
        public static readonly Interval DIMINISHED_SEVENTH = new Interval(6, 9);
        public static readonly Interval MINOR_SEVENTH = new Interval(6, 10);
        public static readonly Interval MAJOR_SEVENTH = new Interval(6, 11);
        public static readonly Interval PERFECT_OCTAVE = new Interval(7, 12);
        public static readonly Interval MAJOR_NINTH = new Interval(8, 14);
        public static readonly Interval PERFECT_ELEVENTH = new Interval(10, 17);
        public static readonly Interval MAJOR_THIRTEENTH = new Interval(12, 21);
        public static readonly Interval PERFECT_FIFTEENTH = new Interval(14, 24);
    }
}