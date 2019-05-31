using System;
using System.Collections.Generic;
using System.Linq;
using Util;

using static Model.Interval;
using static Util.ParseHelpers;

namespace Model
{
    public class Mode : IEquatable<Mode>
    {
        public string Title { get; }
        public Interval[] Intervals { get; }

        public Mode(string title, Interval[] intervals)
        {
            if (intervals.Zip(intervals.Skip(1), (b, t) => b.Specific >= t.Specific).Any(t => t))
            {
                throw new ArgumentException("Mode intervals must strictly increase");
            }
            this.Title = title;
            this.Intervals = intervals;
        }

        public Mode(string title, params string[] intervals)
            : this(title, intervals.Select(I).ToArray()) {}

        public bool Equals(Mode other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }

        override public string ToString()
        {
            return $"Mode[Title={Title}, Intervals={String.Join(",", Intervals.ToList())}]";
        }

        public Quality Quality(int degree, int width)
        {
            // These intervals are based on the tonic; but the returned quality will be
            // based on the given scale degree as the root. So each one will need to
            // be decremented by root.
            Interval[] intervals = Ascend().Skip(degree).EveryN(2).Take(width).ToArray();
            Interval root = intervals[0];
            
            return new Quality(intervals.Select(i => i - root).ToArray());
        }

        public IEnumerable<Interval> Ascend()
        {
            Interval current = PERFECT_UNISON;
            while(true)
            {
                foreach (Interval interval in Intervals)
                {
                    yield return current + interval;
                }
                current += PERFECT_OCTAVE;
            }
        }

        public IEnumerable<Note> Scale(Note tonic)
        {
            return Ascend().Select(tonic.Apply);
        }

        public IEnumerable<Pitch> Scale(Pitch tonic)
        {
            return Ascend().Select(tonic.Apply);
        }

        public Accidental AccidentalFor(Note key, Name name)
        {
            return Scale(key).First(n => n.Name == name).Accidental;
        }

        public static readonly Mode IONIAN =
            new Mode("Ionian (Major)", "P1", "M2", "M3", "P4", "P5", "M6", "M7");
        
        public static readonly Mode MAJOR = IONIAN;

        public static readonly Mode DORIAN =
            new Mode("Dorian", "P1", "M2", "m3", "P4", "P5", "M6", "m7");

        public static readonly Mode PHRYGIAN =
            new Mode("Phrygian", "P1", "m2", "m3", "P4", "P5", "m6", "m7");

        public static readonly Mode LYDIAN =
            new Mode("Lydian", "P1", "M2", "M3", "A4", "P5", "M6", "M7");

        public static readonly Mode MIXOLYDIAN =
            new Mode("Mixolydian", "P1", "M2", "M3", "P4", "P5", "M6", "m7");

        public static readonly Mode AEOLIAN =
            new Mode("Aeolian (minor)", "P1", "M2", "m3", "P4", "P5", "m6", "m7");
        
        public static readonly Mode MINOR = AEOLIAN;

        public static readonly Mode LOCRIAN =
            new Mode("Locrian", "P1", "m2", "m3", "P4", "d5", "m6", "m7");
    }
}