using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public struct Scale
    {
        public Note Tonic { get; }
        public Mode Mode { get; }

        public Scale(Note tonic, Mode mode)
        {
            this.Tonic = tonic;
            this.Mode = mode;
        }

        override public string ToString()
        {
            return $"Scale[Tonic={Tonic}, Mode={Mode}]";
        }

        public string Describe()
        {
            return $"{Tonic.Describe()} {Mode.Describe()}";
        }

        public IEnumerable<Note> Ascend()
        {
            Note root = Tonic;
            while(true)
            {
                foreach (Interval interval in Mode.Intervals)
                {
                    yield return root.Apply(interval);
                }
            }
        }

        public IEnumerable<Pitch> Ascend(int octave)
        {
            Pitch root = new Pitch(Tonic, octave);
            while(true)
            {
                foreach (Interval interval in Mode.Intervals)
                {
                    yield return root.Apply(interval);
                }
                root = root.Apply(Interval.PERFECT_OCTAVE);
            }
        }
    }
}