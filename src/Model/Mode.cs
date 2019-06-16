using System;
using System.Collections.Generic;
using System.Linq;
using Cadd9.Util;

using static Cadd9.Model.Interval;
using static Cadd9.Util.ParseHelpers;

namespace Cadd9.Model
{
    ///<summary>
    ///  Represents a musical mode based on its component intervals.
    ///</summary>
    public class Mode : IEquatable<Mode>
    {
        ///<summary>
        ///  A descriptive title of this Mode
        ///</summary>
        public string Title { get; }

        ///<summary>
        ///  A set of all the Intervals that make up this Mode
        ///</summary>
        ///<remarks>
        ///  <seealso cref="Ascend()"/>
        ///</remarks>
        public Interval[] Intervals { get; }

        ///<summary>
        ///  Returns a new Mode
        ///</summary>
        ///<param name="title">The title of this Mode</param>
        ///<param name="intervals">The intervals that make up this Mode</param>
        ///<exception cref="ArgumentException">Thrown if a generic interval appears multiple times</exception>
        public Mode(string title, Interval[] intervals)
        {
            if (intervals.Select(i => i.GenericWidth).Distinct().Count() != intervals.Count())
            {
                throw new ArgumentException("All generic intervals must appear at most once");
            }
            this.Title = title;
            this.Intervals = intervals.OrderBy(i => i.GenericWidth).ToArray();
        }

        ///<summary>
        ///  Returns a new Mode
        ///</summary>
        ///<param name="title">The title of this Mode</param>
        ///<param name="intervals">String representations of the intervals that make up this Mode</param>
        ///<exception cref="ArgumentException">
        ///  Thrown if the given intervals do not feature every generic interval 0-6 exactly once
        ///</exception>
        ///<remarks>
        ///  The intervals given in this constructor will be parsed according to the behavior in
        ///  <see cref="Interval.Parse(string)" /> which allows short-hand construction.
        ///</remarks>
        public Mode(string title, params string[] intervals) : this(title, intervals.Select(W).ToArray()) {}

        ///<summary>
        ///  A string representation of this Mode, useful for debugging.
        ///</summary>
        override public string ToString() => $"Mode[Title={Title}, Intervals={String.Join(",", Intervals.ToList())}]";

        ///<summary>
        ///  Returns a chord based on stacked thirds from the given scale degree of this mode.
        ///</summary>
        ///<param name="degree">The scale degree to use as the root</param>
        ///<param name="count">The number of notes to return (3 = triad, 4 = 7th, 5 = 9th, etc) (min 3)</param>
        ///<exception cref="ArgumentException">If degree or width are out of bounds</exception>
        ///<remarks>
        ///  Each mode has 7 scale degrees that produce 7 signature chord qualities. For example, the major (Ionian)
        ///  mode's fourth scale degree (iv) is a minor triad, while the Phrygian mode's fifth scale degree (v°) is a
        ///  diminished triad.
        ///  <para>Important note: the value of <c>degree</c> is treated starting at zero.</para>
        ///</remarks>
        public Quality DiatonicChord(Degree degree, int count = 3)
        {
            if (count < 3)
            {
                throw new ArgumentException("Count must be 3 or greater");
            }

            // The intervals in the mode are all from the tonic. However, the returned quality should have a perfect
            // unison as root. Each interval in the result must be adjusted accordingly.
            var intervals = Ascend().Skip((int) degree).EveryN(2).Take(count);
            var root = intervals.First();
            
            return new Quality(intervals.Select(i => i - root).ToArray());
        }

        ///<summary>
        ///  Yields every Interval in this mode starting from unison.
        ///</summary>
        ///<remarks>
        ///  Will progress infinitely, so take only what is needed.
        ///</remarks>
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

        ///<summary>
        ///  Yields every <see cref="Note"/> in this mode starting from the given tonic.
        ///</summary>
        ///<remarks>
        ///  Will progress infinitely, so take only what is needed.
        ///</remarks>
        public IEnumerable<Note> Scale(Note tonic) => Ascend().Select(tonic.Apply);

        ///<summary>
        ///  Yields every <see cref="Pitch"/> in this mode starting from the given tonic.
        ///</summary>
        ///<remarks>
        ///  Will progress infinitely, so take only what is needed.
        ///</remarks>
        public IEnumerable<Pitch> Scale(Pitch tonic) => Ascend().Select(tonic.Apply);

        ///<summary>
        ///  Yields the <see cref="Accidental"/> associated with a given name for a given key.
        ///</summary>
        ///<remarks>
        ///  This may be used, for example, to place sharps and flats on a staff given a particular key. In the D major
        ///  (Ionian) key, F and C have a sharp accidental while all other names are natural. This may also be used to
        ///  determine how to render a note: if its accidental is the same as the accidental for its name in the key, no
        ///  symbol need be added.
        ///</remarks>
        public Accidental AccidentalFor(Note key, Name name) => Scale(key).First(n => n.Name == name).Accidental;

        #region Value equality
        
        ///<summary>
        ///  Determines whether two Modes are value-equivalent.
        ///</summary>
        ///<param name="other">The other Mode to compare</param>
        public bool Equals(Mode other) => Intervals.SequenceEqual(other.Intervals);

        private static readonly int HASH_CODE_SEED = 59;
        private static readonly int HASH_CODE_STEP = 223;

        ///<summary>
        ///  Produces a high-entropy hash code such that two value-equivalent Modes are guaranteed to produce the same
        ///  result.
        ///</summary>
        override public int GetHashCode()
        {
            unchecked
            {
                int hashCode = HASH_CODE_SEED;
                foreach (Interval interval in Intervals)
                {
                    hashCode = (HASH_CODE_STEP * hashCode) ^ interval.GetHashCode();
                }
                return hashCode;
            }
        }

        #endregion

        #region Typical values
        #pragma warning disable CS1591

        public static readonly Mode IONIAN = new Mode("Ionian (Major)", "P1", "M2", "M3", "P4", "P5", "M6", "M7");
        public static readonly Mode DORIAN = new Mode("Dorian", "P1", "M2", "m3", "P4", "P5", "M6", "m7");
        public static readonly Mode PHRYGIAN = new Mode("Phrygian", "P1", "m2", "m3", "P4", "P5", "m6", "m7");
        public static readonly Mode LYDIAN = new Mode("Lydian", "P1", "M2", "M3", "A4", "P5", "M6", "M7");
        public static readonly Mode MIXOLYDIAN = new Mode("Mixolydian", "P1", "M2", "M3", "P4", "P5", "M6", "m7");
        public static readonly Mode AEOLIAN = new Mode("Aeolian (minor)", "P1", "M2", "m3", "P4", "P5", "m6", "m7");
        public static readonly Mode LOCRIAN = new Mode("Locrian", "P1", "m2", "m3", "P4", "d5", "m6", "m7");
        public static readonly Mode MAJOR = IONIAN;
        public static readonly Mode MINOR = AEOLIAN;

        #pragma warning restore CS1591
        #endregion
    }
}