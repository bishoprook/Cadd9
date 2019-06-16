<a name='assembly'></a>
# Cadd9

## Contents

- [Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental')
  - [#ctor(semitones)](#M-Cadd9-Model-Accidental-#ctor-System-Int32- 'Cadd9.Model.Accidental.#ctor(System.Int32)')
  - [Description](#P-Cadd9-Model-Accidental-Description 'Cadd9.Model.Accidental.Description')
  - [Semitones](#P-Cadd9-Model-Accidental-Semitones 'Cadd9.Model.Accidental.Semitones')
  - [Enharmonic(other)](#M-Cadd9-Model-Accidental-Enharmonic-Cadd9-Model-Accidental- 'Cadd9.Model.Accidental.Enharmonic(Cadd9.Model.Accidental)')
  - [Equals(other)](#M-Cadd9-Model-Accidental-Equals-Cadd9-Model-Accidental- 'Cadd9.Model.Accidental.Equals(Cadd9.Model.Accidental)')
  - [GetHashCode()](#M-Cadd9-Model-Accidental-GetHashCode 'Cadd9.Model.Accidental.GetHashCode')
  - [Parse(input)](#M-Cadd9-Model-Accidental-Parse-System-String- 'Cadd9.Model.Accidental.Parse(System.String)')
  - [ToString()](#M-Cadd9-Model-Accidental-ToString 'Cadd9.Model.Accidental.ToString')
- [Alteration](#T-Cadd9-Model-Quality-Alteration 'Cadd9.Model.Quality.Alteration')
  - [#ctor()](#M-Cadd9-Model-Quality-Alteration-#ctor-System-Nullable{Cadd9-Model-Interval-Generic},Cadd9-Model-Interval- 'Cadd9.Model.Quality.Alteration.#ctor(System.Nullable{Cadd9.Model.Interval.Generic},Cadd9.Model.Interval)')
  - [Add](#P-Cadd9-Model-Quality-Alteration-Add 'Cadd9.Model.Quality.Alteration.Add')
  - [Drop](#P-Cadd9-Model-Quality-Alteration-Drop 'Cadd9.Model.Quality.Alteration.Drop')
- [Constants](#T-Cadd9-Model-Constants 'Cadd9.Model.Constants')
  - [MIDDLE_C_MIDI_NUMBER](#F-Cadd9-Model-Constants-MIDDLE_C_MIDI_NUMBER 'Cadd9.Model.Constants.MIDDLE_C_MIDI_NUMBER')
  - [MIDDLE_C_OCTAVE](#F-Cadd9-Model-Constants-MIDDLE_C_OCTAVE 'Cadd9.Model.Constants.MIDDLE_C_OCTAVE')
  - [NAMES_PER_OCTAVE](#F-Cadd9-Model-Constants-NAMES_PER_OCTAVE 'Cadd9.Model.Constants.NAMES_PER_OCTAVE')
  - [SEMITONES_PER_OCTAVE](#F-Cadd9-Model-Constants-SEMITONES_PER_OCTAVE 'Cadd9.Model.Constants.SEMITONES_PER_OCTAVE')
- [EnumerableExtensions](#T-Cadd9-Util-EnumerableExtensions 'Cadd9.Util.EnumerableExtensions')
  - [EveryN\`\`1()](#M-Cadd9-Util-EnumerableExtensions-EveryN``1-System-Collections-Generic-IEnumerable{``0},System-Int32- 'Cadd9.Util.EnumerableExtensions.EveryN``1(System.Collections.Generic.IEnumerable{``0},System.Int32)')
- [Generic](#T-Cadd9-Model-Interval-Generic 'Cadd9.Model.Interval.Generic')
- [IntExtensions](#T-Cadd9-Util-IntExtensions 'Cadd9.Util.IntExtensions')
  - [Demodulus()](#M-Cadd9-Util-IntExtensions-Demodulus-System-Int32,System-Int32- 'Cadd9.Util.IntExtensions.Demodulus(System.Int32,System.Int32)')
  - [Modulus()](#M-Cadd9-Util-IntExtensions-Modulus-System-Int32,System-Int32- 'Cadd9.Util.IntExtensions.Modulus(System.Int32,System.Int32)')
  - [Ordinal()](#M-Cadd9-Util-IntExtensions-Ordinal-System-Int32- 'Cadd9.Util.IntExtensions.Ordinal(System.Int32)')
- [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval')
  - [#ctor(genericWidth,specificWidth)](#M-Cadd9-Model-Interval-#ctor-Cadd9-Model-Interval-Generic,System-Int32- 'Cadd9.Model.Interval.#ctor(Cadd9.Model.Interval.Generic,System.Int32)')
  - [Abbreviation](#P-Cadd9-Model-Interval-Abbreviation 'Cadd9.Model.Interval.Abbreviation')
  - [Description](#P-Cadd9-Model-Interval-Description 'Cadd9.Model.Interval.Description')
  - [GenericWidth](#P-Cadd9-Model-Interval-GenericWidth 'Cadd9.Model.Interval.GenericWidth')
  - [SpecificWidth](#P-Cadd9-Model-Interval-SpecificWidth 'Cadd9.Model.Interval.SpecificWidth')
  - [Between(bottom,top)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Name,Cadd9-Model-Name- 'Cadd9.Model.Interval.Between(Cadd9.Model.Name,Cadd9.Model.Name)')
  - [Between(bottom,top)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Note,Cadd9-Model-Note- 'Cadd9.Model.Interval.Between(Cadd9.Model.Note,Cadd9.Model.Note)')
  - [Between(bottom,top)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Pitch,Cadd9-Model-Pitch- 'Cadd9.Model.Interval.Between(Cadd9.Model.Pitch,Cadd9.Model.Pitch)')
  - [Enharmonic(other)](#M-Cadd9-Model-Interval-Enharmonic-Cadd9-Model-Interval- 'Cadd9.Model.Interval.Enharmonic(Cadd9.Model.Interval)')
  - [Equals(other)](#M-Cadd9-Model-Interval-Equals-Cadd9-Model-Interval- 'Cadd9.Model.Interval.Equals(Cadd9.Model.Interval)')
  - [GenericName()](#M-Cadd9-Model-Interval-GenericName-Cadd9-Model-Interval-Generic- 'Cadd9.Model.Interval.GenericName(Cadd9.Model.Interval.Generic)')
  - [GetHashCode()](#M-Cadd9-Model-Interval-GetHashCode 'Cadd9.Model.Interval.GetHashCode')
  - [Parse(input)](#M-Cadd9-Model-Interval-Parse-System-String- 'Cadd9.Model.Interval.Parse(System.String)')
  - [ParseFormal()](#M-Cadd9-Model-Interval-ParseFormal-System-String- 'Cadd9.Model.Interval.ParseFormal(System.String)')
  - [ParseSimple()](#M-Cadd9-Model-Interval-ParseSimple-System-String- 'Cadd9.Model.Interval.ParseSimple(System.String)')
  - [ReducedGenericWidth()](#M-Cadd9-Model-Interval-ReducedGenericWidth-Cadd9-Model-Interval-Generic- 'Cadd9.Model.Interval.ReducedGenericWidth(Cadd9.Model.Interval.Generic)')
  - [ToString()](#M-Cadd9-Model-Interval-ToString 'Cadd9.Model.Interval.ToString')
  - [op_Addition()](#M-Cadd9-Model-Interval-op_Addition-Cadd9-Model-Interval,Cadd9-Model-Interval- 'Cadd9.Model.Interval.op_Addition(Cadd9.Model.Interval,Cadd9.Model.Interval)')
  - [op_Subtraction()](#M-Cadd9-Model-Interval-op_Subtraction-Cadd9-Model-Interval,Cadd9-Model-Interval- 'Cadd9.Model.Interval.op_Subtraction(Cadd9.Model.Interval,Cadd9.Model.Interval)')
- [Mode](#T-Cadd9-Model-Mode 'Cadd9.Model.Mode')
  - [#ctor(title,intervals)](#M-Cadd9-Model-Mode-#ctor-System-String,Cadd9-Model-Interval[]- 'Cadd9.Model.Mode.#ctor(System.String,Cadd9.Model.Interval[])')
  - [#ctor(title,intervals)](#M-Cadd9-Model-Mode-#ctor-System-String,System-String[]- 'Cadd9.Model.Mode.#ctor(System.String,System.String[])')
  - [Intervals](#P-Cadd9-Model-Mode-Intervals 'Cadd9.Model.Mode.Intervals')
  - [Title](#P-Cadd9-Model-Mode-Title 'Cadd9.Model.Mode.Title')
  - [AccidentalFor()](#M-Cadd9-Model-Mode-AccidentalFor-Cadd9-Model-Note,Cadd9-Model-Name- 'Cadd9.Model.Mode.AccidentalFor(Cadd9.Model.Note,Cadd9.Model.Name)')
  - [Ascend()](#M-Cadd9-Model-Mode-Ascend 'Cadd9.Model.Mode.Ascend')
  - [DiatonicChord(degree,count)](#M-Cadd9-Model-Mode-DiatonicChord-Cadd9-Model-Degree,System-Int32- 'Cadd9.Model.Mode.DiatonicChord(Cadd9.Model.Degree,System.Int32)')
  - [Equals(other)](#M-Cadd9-Model-Mode-Equals-Cadd9-Model-Mode- 'Cadd9.Model.Mode.Equals(Cadd9.Model.Mode)')
  - [GetHashCode()](#M-Cadd9-Model-Mode-GetHashCode 'Cadd9.Model.Mode.GetHashCode')
  - [Scale()](#M-Cadd9-Model-Mode-Scale-Cadd9-Model-Note- 'Cadd9.Model.Mode.Scale(Cadd9.Model.Note)')
  - [Scale()](#M-Cadd9-Model-Mode-Scale-Cadd9-Model-Pitch- 'Cadd9.Model.Mode.Scale(Cadd9.Model.Pitch)')
  - [ToString()](#M-Cadd9-Model-Mode-ToString 'Cadd9.Model.Mode.ToString')
- [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name')
- [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note')
  - [#ctor(name,accidental)](#M-Cadd9-Model-Note-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental- 'Cadd9.Model.Note.#ctor(Cadd9.Model.Name,Cadd9.Model.Accidental)')
  - [Accidental](#P-Cadd9-Model-Note-Accidental 'Cadd9.Model.Note.Accidental')
  - [Description](#P-Cadd9-Model-Note-Description 'Cadd9.Model.Note.Description')
  - [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name')
  - [PitchClass](#P-Cadd9-Model-Note-PitchClass 'Cadd9.Model.Note.PitchClass')
  - [Apply(interval)](#M-Cadd9-Model-Note-Apply-Cadd9-Model-Interval- 'Cadd9.Model.Note.Apply(Cadd9.Model.Interval)')
  - [Enharmonic(other)](#M-Cadd9-Model-Note-Enharmonic-Cadd9-Model-Note- 'Cadd9.Model.Note.Enharmonic(Cadd9.Model.Note)')
  - [Equals(other)](#M-Cadd9-Model-Note-Equals-Cadd9-Model-Note- 'Cadd9.Model.Note.Equals(Cadd9.Model.Note)')
  - [GetHashCode()](#M-Cadd9-Model-Note-GetHashCode 'Cadd9.Model.Note.GetHashCode')
  - [Parse(input)](#M-Cadd9-Model-Note-Parse-System-String- 'Cadd9.Model.Note.Parse(System.String)')
  - [ToString()](#M-Cadd9-Model-Note-ToString 'Cadd9.Model.Note.ToString')
- [ParseHelpers](#T-Cadd9-Util-ParseHelpers 'Cadd9.Util.ParseHelpers')
  - [N()](#M-Cadd9-Util-ParseHelpers-N-System-String- 'Cadd9.Util.ParseHelpers.N(System.String)')
  - [P()](#M-Cadd9-Util-ParseHelpers-P-System-String- 'Cadd9.Util.ParseHelpers.P(System.String)')
  - [W()](#M-Cadd9-Util-ParseHelpers-W-System-String- 'Cadd9.Util.ParseHelpers.W(System.String)')
- [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch')
  - [#ctor(note,octave)](#M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Note,System-Int32- 'Cadd9.Model.Pitch.#ctor(Cadd9.Model.Note,System.Int32)')
  - [#ctor(name,accidental,octave)](#M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental,System-Int32- 'Cadd9.Model.Pitch.#ctor(Cadd9.Model.Name,Cadd9.Model.Accidental,System.Int32)')
  - [Description](#P-Cadd9-Model-Pitch-Description 'Cadd9.Model.Pitch.Description')
  - [Midi](#P-Cadd9-Model-Pitch-Midi 'Cadd9.Model.Pitch.Midi')
  - [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note')
  - [Octave](#P-Cadd9-Model-Pitch-Octave 'Cadd9.Model.Pitch.Octave')
  - [Apply(interval)](#M-Cadd9-Model-Pitch-Apply-Cadd9-Model-Interval- 'Cadd9.Model.Pitch.Apply(Cadd9.Model.Interval)')
  - [DescribeInKey(key,signature)](#M-Cadd9-Model-Pitch-DescribeInKey-Cadd9-Model-Note,Cadd9-Model-Mode- 'Cadd9.Model.Pitch.DescribeInKey(Cadd9.Model.Note,Cadd9.Model.Mode)')
  - [Enharmonic(other)](#M-Cadd9-Model-Pitch-Enharmonic-Cadd9-Model-Pitch- 'Cadd9.Model.Pitch.Enharmonic(Cadd9.Model.Pitch)')
  - [Equals(other)](#M-Cadd9-Model-Pitch-Equals-Cadd9-Model-Pitch- 'Cadd9.Model.Pitch.Equals(Cadd9.Model.Pitch)')
  - [GetHashCode()](#M-Cadd9-Model-Pitch-GetHashCode 'Cadd9.Model.Pitch.GetHashCode')
  - [InOctave(octave)](#M-Cadd9-Model-Pitch-InOctave-System-Int32- 'Cadd9.Model.Pitch.InOctave(System.Int32)')
  - [Parse(input)](#M-Cadd9-Model-Pitch-Parse-System-String- 'Cadd9.Model.Pitch.Parse(System.String)')
  - [ToString()](#M-Cadd9-Model-Pitch-ToString 'Cadd9.Model.Pitch.ToString')
  - [Transpose(octaves)](#M-Cadd9-Model-Pitch-Transpose-System-Int32- 'Cadd9.Model.Pitch.Transpose(System.Int32)')
- [Program](#T-Program 'Program')
  - [Main()](#M-Program-Main-System-String[]- 'Program.Main(System.String[])')
- [Quality](#T-Cadd9-Model-Quality 'Cadd9.Model.Quality')
  - [#ctor(intervals)](#M-Cadd9-Model-Quality-#ctor-Cadd9-Model-Interval[]- 'Cadd9.Model.Quality.#ctor(Cadd9.Model.Interval[])')
  - [#ctor(intervals)](#M-Cadd9-Model-Quality-#ctor-System-String[]- 'Cadd9.Model.Quality.#ctor(System.String[])')
  - [Intervals](#P-Cadd9-Model-Quality-Intervals 'Cadd9.Model.Quality.Intervals')
  - [Add(add)](#M-Cadd9-Model-Quality-Add-Cadd9-Model-Interval- 'Cadd9.Model.Quality.Add(Cadd9.Model.Interval)')
  - [Alter(alt)](#M-Cadd9-Model-Quality-Alter-Cadd9-Model-Quality-Alteration- 'Cadd9.Model.Quality.Alter(Cadd9.Model.Quality.Alteration)')
  - [Apply()](#M-Cadd9-Model-Quality-Apply-Cadd9-Model-Note- 'Cadd9.Model.Quality.Apply(Cadd9.Model.Note)')
  - [Apply()](#M-Cadd9-Model-Quality-Apply-Cadd9-Model-Pitch- 'Cadd9.Model.Quality.Apply(Cadd9.Model.Pitch)')
  - [Equals(other)](#M-Cadd9-Model-Quality-Equals-Cadd9-Model-Quality- 'Cadd9.Model.Quality.Equals(Cadd9.Model.Quality)')
  - [GetHashCode()](#M-Cadd9-Model-Quality-GetHashCode 'Cadd9.Model.Quality.GetHashCode')
  - [ToString()](#M-Cadd9-Model-Quality-ToString 'Cadd9.Model.Quality.ToString')
- [Voicing](#T-Cadd9-Model-Voicing 'Cadd9.Model.Voicing')
  - [Equals(other)](#M-Cadd9-Model-Voicing-Equals-Cadd9-Model-Voicing- 'Cadd9.Model.Voicing.Equals(Cadd9.Model.Voicing)')
  - [GetHashCode()](#M-Cadd9-Model-Voicing-GetHashCode 'Cadd9.Model.Voicing.GetHashCode')

<a name='T-Cadd9-Model-Accidental'></a>
## Accidental `type`

##### Namespace

Cadd9.Model

##### Summary

Represents an accidental that shifts some note or pitch by a certain number of semitones away from natural.

<a name='M-Cadd9-Model-Accidental-#ctor-System-Int32-'></a>
### #ctor(semitones) `constructor`

##### Summary

Returns a new Accidental

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| semitones | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of semitones this accidental shifts a pitch or note |

<a name='P-Cadd9-Model-Accidental-Description'></a>
### Description `property`

##### Summary

A formatted representation of this Accidental as a UTF-8 string.

<a name='P-Cadd9-Model-Accidental-Semitones'></a>
### Semitones `property`

##### Summary

The number of semitones this accidental shifts a pitch or note. Positive values indicate sharps, negative
  values indicate flats.

<a name='M-Cadd9-Model-Accidental-Enharmonic-Cadd9-Model-Accidental-'></a>
### Enharmonic(other) `method`

##### Summary

Returns true if `other` is enharmonic with this Accidental.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The Accidental to compare with |

##### Remarks

Two accidentals are enharmonic if they are equal or if their `Semitones` differ by an even multiple of
  12. For example 5 sharps is enharmonic with 7 flats: C♯♯♯♯♯ and C♭♭♭♭♭♭♭ are both enharmonic with each
  other and with F natural.

<a name='M-Cadd9-Model-Accidental-Equals-Cadd9-Model-Accidental-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Accidentals are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The Accidental to compare |

<a name='M-Cadd9-Model-Accidental-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Accidentals are guaranteed to produce the
  same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Accidental-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Returns a new Accidental based on the given input string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The plain ASCII input string to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |

##### Remarks

Assumes the input will be in plain ASCII: "b" for flats and "#" for sharps. An empty string or the string
  `"nat"` may be used for natural.

<a name='M-Cadd9-Model-Accidental-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Accidental, primarily for debugging purposes.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Quality-Alteration'></a>
## Alteration `type`

##### Namespace

Cadd9.Model.Quality

##### Summary

Encapsulates an alteration of a chord quality, by dropping, adding, or replacing some intervals.

<a name='M-Cadd9-Model-Quality-Alteration-#ctor-System-Nullable{Cadd9-Model-Interval-Generic},Cadd9-Model-Interval-'></a>
### #ctor() `constructor`

##### Summary

Returns a new Alteration

##### Parameters

This constructor has no parameters.

<a name='P-Cadd9-Model-Quality-Alteration-Add'></a>
### Add `property`

##### Summary

The interval that is added as part of this modification, or null if nothing is added.

<a name='P-Cadd9-Model-Quality-Alteration-Drop'></a>
### Drop `property`

##### Summary

The generic interval to be removed by this modification, or null if nothing is removed.

<a name='T-Cadd9-Model-Constants'></a>
## Constants `type`

##### Namespace

Cadd9.Model

##### Summary

Defines several frequently-used music theory constants.

<a name='F-Cadd9-Model-Constants-MIDDLE_C_MIDI_NUMBER'></a>
### MIDDLE_C_MIDI_NUMBER `constants`

##### Summary

The MIDI note number corresponding to middle C

##### Remarks

This is not a universal definition. In fact as far as the MIDI standard is concerned, the note numbers are
  not strictly related to any musical pitches. They are simply a set of 127 sequential numbers that can be
  turned on and off with control messages. But 60 is used by most device manufacturers.

<a name='F-Cadd9-Model-Constants-MIDDLE_C_OCTAVE'></a>
### MIDDLE_C_OCTAVE `constants`

##### Summary

The octave number of middle C

##### Remarks

There is no universal definition: middle C is also sometimes labeled as C3.

<a name='F-Cadd9-Model-Constants-NAMES_PER_OCTAVE'></a>
### NAMES_PER_OCTAVE `constants`

##### Summary

The number of note names per octave

##### Remarks

Western tonal music is built around the diatonic scale, which is a heptatonic scale (containing seven
  tones) arranged so there are 2 half-steps (single semitone) and 5 whole-steps (two semitones) separating
  each. The arrangement of steps and half-steps determines the [Mode](#T-Cadd9-Model-Mode 'Cadd9.Model.Mode') of the scale.

<a name='F-Cadd9-Model-Constants-SEMITONES_PER_OCTAVE'></a>
### SEMITONES_PER_OCTAVE `constants`

##### Summary

The number of semitones per octave

##### Remarks

In Western tonal music using equal temperament, an octave is a doubling of frequency, and it is further
  subdivided into 12 semitones where each is in a 2^(1/12):1 ratio with the one before it.

<a name='T-Cadd9-Util-EnumerableExtensions'></a>
## EnumerableExtensions `type`

##### Namespace

Cadd9.Util

##### Summary

Adds useful extension methods to [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')

<a name='M-Cadd9-Util-EnumerableExtensions-EveryN``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
### EveryN\`\`1() `method`

##### Summary

Returns the first element in the input and every Nth afterward.

##### Parameters

This method has no parameters.

##### Example

This example demonstrates how to use [EveryN\`\`1](#M-Cadd9-Util-EnumerableExtensions-EveryN``1-System-Collections-Generic-IEnumerable{``0},System-Int32- 'Cadd9.Util.EnumerableExtensions.EveryN``1(System.Collections.Generic.IEnumerable{``0},System.Int32)') to take every
  Nth element of a range.

```
  var result = Enumerable.Range(1, 10).EveryN(3);
  foreach (var num in result)
  {
      Console.WriteLine(num);
  }
  // This produces: 1, 4, 7, 10
```

<a name='T-Cadd9-Model-Interval-Generic'></a>
## Generic `type`

##### Namespace

Cadd9.Model.Interval

##### Summary

Represents a generic interval between two notes or pitches independent of semitone width

##### Remarks

For instance, the generic interval between any F and any A is always a third. From F to A♯ is an augmented
  third (5 semitones), and from F to A♭ is a minor third (3 semitones) but the generic interval is always a
  third. In other words, this is the number of note names shifted from the bottom to top of the interval.

<a name='T-Cadd9-Util-IntExtensions'></a>
## IntExtensions `type`

##### Namespace

Cadd9.Util

##### Summary

Adds extension methods for some useful integer math

<a name='M-Cadd9-Util-IntExtensions-Demodulus-System-Int32,System-Int32-'></a>
### Demodulus() `method`

##### Summary

Returns the integer congruent to operand (mod modulus) with smallest absolute value.

##### Parameters

This method has no parameters.

##### Remarks

The range of this method is `[-modulus/2, modulus/2)` -- basically the goal is
  to return an integer that is modulo-congruent with operand but is as close as
  possible to zero. Primarily this is used to simplify accidentals as much as
  possible: if we have 11 sharps, a more ideal (and enharmonic) accidental would be
  one flat, represented as -1 and congruent to 11 (mod 12).

<a name='M-Cadd9-Util-IntExtensions-Modulus-System-Int32,System-Int32-'></a>
### Modulus() `method`

##### Summary

Returns the value of `operand` mod `modulus`

##### Parameters

This method has no parameters.

##### Remarks

Formally this method returns the least non-negative integer `N` such that
  `operand ≡ N (mod modulus)`. It differs from C#'s `%` operator in its
  treatment of negative values: `-1 % 7 == -1` while `-1.Modulus(7) == 6`.

<a name='M-Cadd9-Util-IntExtensions-Ordinal-System-Int32-'></a>
### Ordinal() `method`

##### Summary

Returns a string representation of an integer in ordinal form

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Interval'></a>
## Interval `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a musical width between notes or pitches.

<a name='M-Cadd9-Model-Interval-#ctor-Cadd9-Model-Interval-Generic,System-Int32-'></a>
### #ctor(genericWidth,specificWidth) `constructor`

##### Summary

Creates an Interval with the given generic and specific widths.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| genericWidth | [Cadd9.Model.Interval.Generic](#T-Cadd9-Model-Interval-Generic 'Cadd9.Model.Interval.Generic') | The number of note names spanned by the interval |
| specificWidth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of semitones spanned by the interval |

<a name='P-Cadd9-Model-Interval-Abbreviation'></a>
### Abbreviation `property`

##### Summary

A short formatted description of the interval, like "P4"

<a name='P-Cadd9-Model-Interval-Description'></a>
### Description `property`

##### Summary

A long-form formatted description of the interval, like "Perfect Fourth"

<a name='P-Cadd9-Model-Interval-GenericWidth'></a>
### GenericWidth `property`

##### Summary

The generic width of this Interval, in other words, the difference in note names from bottom to top.

<a name='P-Cadd9-Model-Interval-SpecificWidth'></a>
### SpecificWidth `property`

##### Summary

The specific width of this Interval, in other words, the semitones shifted between the bottom and top.

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Name,Cadd9-Model-Name-'></a>
### Between(bottom,top) `method`

##### Summary

Returns a new Interval representing the width between two [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name')s.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bottom | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The lower [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') to compare |
| top | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The higher [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') to compare |

##### Remarks

It is always assumed that the interval is going up from first to second: C to B would give an interval of a
  major seventh (despite being much closer to go down a minor second). Also for this reason, this method will
  always produce an interval between unison (inclusive) and an octave (exclusive).

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Note,Cadd9-Model-Note-'></a>
### Between(bottom,top) `method`

##### Summary

Returns a new Interval representing the width between two [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note')s.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bottom | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The lower [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') to compare |
| top | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The higher [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') to compare |

##### Remarks

It is always assumed that the interval is going up from first to second: C♯ to B would give an interval of
  a minor seventh (despite being much closer to go down a major second). Also for this reason, this method
  will always produce an interval between unison (inclusive) and an octave (exclusive).

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Pitch,Cadd9-Model-Pitch-'></a>
### Between(bottom,top) `method`

##### Summary

Returns a new Interval representing the width between two [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch')es.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bottom | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The lower [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') to compare |
| top | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The higher [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') to compare |

##### Remarks

It is always assumed that the interval is going up from first to second: C♯3 to B4 would give an interval
  of a minor fifteenth.

<a name='M-Cadd9-Model-Interval-Enharmonic-Cadd9-Model-Interval-'></a>
### Enharmonic(other) `method`

##### Summary

Returns true if `other` is enharmonically equivalent to this interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The other Interval to compare |

##### Remarks

Two intervals are enharmonic if they have the same specific width. Perfect unison and diminished second,
  for example, are enharmonic despite having different generic widths.

<a name='M-Cadd9-Model-Interval-Equals-Cadd9-Model-Interval-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Intervals are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The Intervals to compare |

<a name='M-Cadd9-Model-Interval-GenericName-Cadd9-Model-Interval-Generic-'></a>
### GenericName() `method`

##### Summary

Returns the name of the given generic width

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Intervals are guaranteed to produce the
  same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Returns a new Interval by parsing the given string input.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If an illegal modifier is supplied for the interval |

##### Remarks

Two formats are accepted: Formal, like `P4` and `d3`, or simple, like `b5` and `#9`. If
  the simple form is used, then the major/perfect matching interval is sharped the given number of times. The
  formal form understands (P)erfect, (d)iminished, (m)inor, (M)ajor, and (A)ugmented descriptors for each
  interval as appropriate.

<a name='M-Cadd9-Model-Interval-ParseFormal-System-String-'></a>
### ParseFormal() `method`

##### Summary

Parses the given input using "formal" notation, or null if it cannot be parsed accordingly

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If an illegal modifier is supplied for the interval |

##### Remarks

"Formal" notation indicates "P4" for a perfect fourth, "m3" for a minor third, etc.

<a name='M-Cadd9-Model-Interval-ParseSimple-System-String-'></a>
### ParseSimple() `method`

##### Summary

Parses the given input using "simple" notation, or returns null if it cannot be parsed accordingly

##### Parameters

This method has no parameters.

##### Remarks

This notation uses "3" for a major third, "b5" for a flat fifth, etc. Commonly used to describe the
  component intervals of chords.

<a name='M-Cadd9-Model-Interval-ReducedGenericWidth-Cadd9-Model-Interval-Generic-'></a>
### ReducedGenericWidth() `method`

##### Summary

Returns the generic width from unison to seventh that is enharmonic with the given generic width

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-ToString'></a>
### ToString() `method`

##### Summary

A string representation of this Interval, useful for debugging.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-op_Addition-Cadd9-Model-Interval,Cadd9-Model-Interval-'></a>
### op_Addition() `method`

##### Summary

Creates a new compound Interval by combining two others.

##### Parameters

This method has no parameters.

##### Remarks

For example, adding together a perfect octave and a perfect fifth produces a perfect thirteenth.

<a name='M-Cadd9-Model-Interval-op_Subtraction-Cadd9-Model-Interval,Cadd9-Model-Interval-'></a>
### op_Subtraction() `method`

##### Summary

Creates a new compound Interval by subtracting one from the other.

##### Parameters

This method has no parameters.

##### Remarks

For example, subtracting a minor second from a perfect octave produces a major seventh.

<a name='T-Cadd9-Model-Mode'></a>
## Mode `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a musical mode based on its component intervals.

<a name='M-Cadd9-Model-Mode-#ctor-System-String,Cadd9-Model-Interval[]-'></a>
### #ctor(title,intervals) `constructor`

##### Summary

Returns a new Mode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title of this Mode |
| intervals | [Cadd9.Model.Interval[]](#T-Cadd9-Model-Interval[] 'Cadd9.Model.Interval[]') | The intervals that make up this Mode |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if a generic interval appears multiple times |

<a name='M-Cadd9-Model-Mode-#ctor-System-String,System-String[]-'></a>
### #ctor(title,intervals) `constructor`

##### Summary

Returns a new Mode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title of this Mode |
| intervals | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | String representations of the intervals that make up this Mode |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the given intervals do not feature every generic interval 0-6 exactly once |

##### Remarks

The intervals given in this constructor will be parsed according to the behavior in
  [Parse](#M-Cadd9-Model-Interval-Parse-System-String- 'Cadd9.Model.Interval.Parse(System.String)') which allows short-hand construction.

<a name='P-Cadd9-Model-Mode-Intervals'></a>
### Intervals `property`

##### Summary

A set of all the Intervals that make up this Mode

##### Remarks



<a name='P-Cadd9-Model-Mode-Title'></a>
### Title `property`

##### Summary

A descriptive title of this Mode

<a name='M-Cadd9-Model-Mode-AccidentalFor-Cadd9-Model-Note,Cadd9-Model-Name-'></a>
### AccidentalFor() `method`

##### Summary

Yields the [Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') associated with a given name for a given key.

##### Parameters

This method has no parameters.

##### Remarks

This may be used, for example, to place sharps and flats on a staff given a particular key. In the D major
  (Ionian) key, F and C have a sharp accidental while all other names are natural. This may also be used to
  determine how to render a note: if its accidental is the same as the accidental for its name in the key, no
  symbol need be added.

<a name='M-Cadd9-Model-Mode-Ascend'></a>
### Ascend() `method`

##### Summary

Yields every Interval in this mode starting from unison.

##### Parameters

This method has no parameters.

##### Remarks

Will progress infinitely, so take only what is needed.

<a name='M-Cadd9-Model-Mode-DiatonicChord-Cadd9-Model-Degree,System-Int32-'></a>
### DiatonicChord(degree,count) `method`

##### Summary

Returns a chord based on stacked thirds from the given scale degree of this mode.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| degree | [Cadd9.Model.Degree](#T-Cadd9-Model-Degree 'Cadd9.Model.Degree') | The scale degree to use as the root |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of notes to return (3 = triad, 4 = 7th, 5 = 9th, etc) (min 3) |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If degree or width are out of bounds |

##### Remarks

Each mode has 7 scale degrees that produce 7 signature chord qualities. For example, the major (Ionian)
  mode's fourth scale degree (iv) is a minor triad, while the Phrygian mode's fifth scale degree (v°) is a
  diminished triad.

Important note: the value of `degree` is treated starting at zero.

<a name='M-Cadd9-Model-Mode-Equals-Cadd9-Model-Mode-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Modes are value-equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Mode](#T-Cadd9-Model-Mode 'Cadd9.Model.Mode') | The other Mode to compare |

<a name='M-Cadd9-Model-Mode-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Modes are guaranteed to produce the same
  result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Mode-Scale-Cadd9-Model-Note-'></a>
### Scale() `method`

##### Summary

Yields every [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') in this mode starting from the given tonic.

##### Parameters

This method has no parameters.

##### Remarks

Will progress infinitely, so take only what is needed.

<a name='M-Cadd9-Model-Mode-Scale-Cadd9-Model-Pitch-'></a>
### Scale() `method`

##### Summary

Yields every [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') in this mode starting from the given tonic.

##### Parameters

This method has no parameters.

##### Remarks

Will progress infinitely, so take only what is needed.

<a name='M-Cadd9-Model-Mode-ToString'></a>
### ToString() `method`

##### Summary

A string representation of this Mode, useful for debugging.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Name'></a>
## Name `type`

##### Namespace

Cadd9.Model

##### Summary

An enumeration of the seven note Names used in Western tonal music.

<a name='T-Cadd9-Model-Note'></a>
## Note `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a note [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name') with an associated modifying [Accidental](#P-Cadd9-Model-Note-Accidental 'Cadd9.Model.Note.Accidental').

<a name='M-Cadd9-Model-Note-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental-'></a>
### #ctor(name,accidental) `constructor`

##### Summary

Returns a new Note

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name') associated with this Note |
| accidental | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The [Accidental](#P-Cadd9-Model-Note-Accidental 'Cadd9.Model.Note.Accidental') modifying this Note |

<a name='P-Cadd9-Model-Note-Accidental'></a>
### Accidental `property`

##### Summary

The [Accidental](#P-Cadd9-Model-Note-Accidental 'Cadd9.Model.Note.Accidental') modifying this Note

<a name='P-Cadd9-Model-Note-Description'></a>
### Description `property`

##### Summary

A formatted representation of this Note as a UTF-8 string.

<a name='P-Cadd9-Model-Note-Name'></a>
### Name `property`

##### Summary

The [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name') associated with this Note

<a name='P-Cadd9-Model-Note-PitchClass'></a>
### PitchClass `property`

##### Summary

The pitch class (0 to 11) of this Note.

##### Remarks

The concept of pitch class is often used in post-tonal music to describe pitches without being based in any
  given heptatonic scale. C is equivalent to a pitch class of 0, and each pitch class going up is separated
  by a semitone. All Notes that are enharmonic by definition have the same pitch class.

<a name='M-Cadd9-Model-Note-Apply-Cadd9-Model-Interval-'></a>
### Apply(interval) `method`

##### Summary

Produces a new Note by applying the given [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The width between the current Note and the new Note to be generated. |

<a name='M-Cadd9-Model-Note-Enharmonic-Cadd9-Model-Note-'></a>
### Enharmonic(other) `method`

##### Summary

Determines whether two Notes are enharmonically equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The other Note to compare |

##### Remarks

Two Notes are enharmonic if they map to the same key on a keyboard: for example, while D♯ and E♭ are
  distinct notes that play different musical roles, they are enharmonic.

<a name='M-Cadd9-Model-Note-Equals-Cadd9-Model-Note-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Notes are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The other Note to compare |

<a name='M-Cadd9-Model-Note-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Notes are guaranteed to produce the same
  result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Note-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Parses the given input as a Note

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |

##### Remarks

The input is treated as case-insensitive. The first character is parsed as a [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name') while the
  rest is parsed according to [Parse](#M-Cadd9-Model-Accidental-Parse-System-String- 'Cadd9.Model.Accidental.Parse(System.String)'). Examples of valid Notes would include
  "B", "Ebb", "c#"

<a name='M-Cadd9-Model-Note-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Note, primarily for debugging purposes.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Util-ParseHelpers'></a>
## ParseHelpers `type`

##### Namespace

Cadd9.Util

##### Summary

Contains helper methods to parse notes, pitches, and intervals

<a name='M-Cadd9-Util-ParseHelpers-N-System-String-'></a>
### N() `method`

##### Summary

Parses the given input as a [Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note')

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Util-ParseHelpers-P-System-String-'></a>
### P() `method`

##### Summary

Parses the given input as a [Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch')

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Util-ParseHelpers-W-System-String-'></a>
### W() `method`

##### Summary

Parses the given input as an [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval')

##### Parameters

This method has no parameters.

##### Remarks

The letter W (for Width) is used instead of I to prevent collision with [I](#F-Cadd9-Model-Degree-I 'Cadd9.Model.Degree.I') when both
  are statically included in the same file.

<a name='T-Cadd9-Model-Pitch'></a>
## Pitch `type`

##### Namespace

Cadd9.Model

##### Summary

A particular musical pitch achieved by playing a [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note') in a particular octave

<a name='M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Note,System-Int32-'></a>
### #ctor(note,octave) `constructor`

##### Summary

Returns a new Pitch

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| note | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note') to represent this Pitch |
| octave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The octave corresponding to this Pitch |

<a name='M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental,System-Int32-'></a>
### #ctor(name,accidental,octave) `constructor`

##### Summary

Returns a new Pitch

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') of this Pitch's [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note') |
| accidental | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The [Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') of this Pitch's [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note') |
| octave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The octave corresponding to this Pitch |

<a name='P-Cadd9-Model-Pitch-Description'></a>
### Description `property`

##### Summary

A formatted representation of this Pitch as a UTF-8 string.

<a name='P-Cadd9-Model-Pitch-Midi'></a>
### Midi `property`

##### Summary

The MIDI note number associated with this Pitch

##### Remarks

Though there is no universal standard for what octave represents middle-C, we treat C-4 as middle C, with
  the MIDI note number 60.

<a name='P-Cadd9-Model-Pitch-Note'></a>
### Note `property`

##### Summary

The [Note](#P-Cadd9-Model-Pitch-Note 'Cadd9.Model.Pitch.Note') represented by this Pitch

<a name='P-Cadd9-Model-Pitch-Octave'></a>
### Octave `property`

##### Summary

The octave corresponding to this Pitch, where middle C = C4

<a name='M-Cadd9-Model-Pitch-Apply-Cadd9-Model-Interval-'></a>
### Apply(interval) `method`

##### Summary

Produces a new (higher) Pitch by applying the given [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') between this and the new Pitch |

##### Remarks

The Note [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') will be incremented by `interval.Generic`, while the pitch will be
  incremented by `interval.Specific` (in semitones). The new [Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') will be set as
  appropriate to achieve this pitch.

<a name='M-Cadd9-Model-Pitch-DescribeInKey-Cadd9-Model-Note,Cadd9-Model-Mode-'></a>
### DescribeInKey(key,signature) `method`

##### Summary

A formatted representation of this Pitch as a UTF-8 string in the given key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The tonic of the key |
| signature | [Cadd9.Model.Mode](#T-Cadd9-Model-Mode 'Cadd9.Model.Mode') | The mode of the key |

##### Remarks

This method will include a symbol for the accidental only if it is different than the associated
  [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') in the given key. For example, C♮4 would be rendered "C4" in the key of C Ionian, but
  would be "C♮4" in the key of D Ionian, because in that key a C would normally be sharp. Likewise, in D
  Ionian the pitch F♯3 would be rendered as "F3" because F is normally sharp in that key.

<a name='M-Cadd9-Model-Pitch-Enharmonic-Cadd9-Model-Pitch-'></a>
### Enharmonic(other) `method`

##### Summary

Determines whether two Pitches are enharmonically equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The other Pitch to compare |

##### Remarks

Two Pitches are enharmonic if they map to the same key on a keyboard: for example, while D♯4 and E♭4 are
  distinct notes that play different musical roles, they are enharmonic.

<a name='M-Cadd9-Model-Pitch-Equals-Cadd9-Model-Pitch-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Pitches are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The other Pitch to compare |

<a name='M-Cadd9-Model-Pitch-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Pitches are guaranteed to produce the same
  result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Pitch-InOctave-System-Int32-'></a>
### InOctave(octave) `method`

##### Summary

Returns a new Note transposed into the given octave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| octave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The octave of the desired note. |

<a name='M-Cadd9-Model-Pitch-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Parses the given input as a Pitch

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |

##### Remarks

The input is treated as case-insensitive. The first character is parsed as a [Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') and the
  rest is broken into an accidental part and an octave. The accidental is parsed according to
  [Parse](#M-Cadd9-Model-Accidental-Parse-System-String- 'Cadd9.Model.Accidental.Parse(System.String)'). Examples of valid Pitches would include "B2", "Ebb17", "c#-1"

<a name='M-Cadd9-Model-Pitch-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Pitch, primarily for debugging purposes.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Pitch-Transpose-System-Int32-'></a>
### Transpose(octaves) `method`

##### Summary

Returns a new Note transposed by the given number of octaves.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| octaves | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of octaves to transpose. |

##### Remarks

If `octaves` is positive, the pitch will increase. If negative, it will decrease.

<a name='T-Program'></a>
## Program `type`

##### Namespace



##### Summary

Empty program class

##### Remarks

Exists only to allow the library to compile successfully. For some reason, netcoreapp2.2 class libraries still
  require a class with a Main method.

<a name='M-Program-Main-System-String[]-'></a>
### Main() `method`

##### Summary

Empty main method

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Quality'></a>
## Quality `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a particular chord quality that may be applied with any given root

<a name='M-Cadd9-Model-Quality-#ctor-Cadd9-Model-Interval[]-'></a>
### #ctor(intervals) `constructor`

##### Summary

Returns a new Quality

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| intervals | [Cadd9.Model.Interval[]](#T-Cadd9-Model-Interval[] 'Cadd9.Model.Interval[]') | The set of Intervals that define this chord quality |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if a generic interval appears multiple times |

<a name='M-Cadd9-Model-Quality-#ctor-System-String[]-'></a>
### #ctor(intervals) `constructor`

##### Summary

Returns a new Quality

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| intervals | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | String representations of the Intervals for this chord quality |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if a generic interval appears multiple times |

##### Remarks

The intervals given in this constructor will be parsed according to the behavior in
  [Parse](#M-Cadd9-Model-Interval-Parse-System-String- 'Cadd9.Model.Interval.Parse(System.String)') which allows short-hand construction.

<a name='P-Cadd9-Model-Quality-Intervals'></a>
### Intervals `property`

##### Summary

The set of Intervals that define this chord quality

<a name='M-Cadd9-Model-Quality-Add-Cadd9-Model-Interval-'></a>
### Add(add) `method`

##### Summary

Returns a new Quality by adding the given Interval

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| add | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The Interval to add |

##### Remarks

This can be used to create a chord with arbitrary extensions, like 9th, 13th, etc.

<a name='M-Cadd9-Model-Quality-Alter-Cadd9-Model-Quality-Alteration-'></a>
### Alter(alt) `method`

##### Summary

Returns a new Quality by applying the given Alteration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| alt | [Cadd9.Model.Quality.Alteration](#T-Cadd9-Model-Quality-Alteration 'Cadd9.Model.Quality.Alteration') | The Alteration to apply |

##### Remarks

This is generally used to modify the 3rd or 5th of the quality, like creating a sus2 or a flat-5 chord.

<a name='M-Cadd9-Model-Quality-Apply-Cadd9-Model-Note-'></a>
### Apply() `method`

##### Summary

Returns a sequence of Notes by applying all of this Quality's Intervals to the given root.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Quality-Apply-Cadd9-Model-Pitch-'></a>
### Apply() `method`

##### Summary

Returns a sequence of Pitches by applying all of this Quality's Intervals to the given root.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Quality-Equals-Cadd9-Model-Quality-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Qualities are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Quality](#T-Cadd9-Model-Quality 'Cadd9.Model.Quality') | The other Quality to compare |

<a name='M-Cadd9-Model-Quality-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Qualities are guaranteed to produce the
  same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Quality-ToString'></a>
### ToString() `method`

##### Summary

A string representation of this Mode, useful for debugging.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Voicing'></a>
## Voicing `type`

##### Namespace

Cadd9.Model

<a name='M-Cadd9-Model-Voicing-Equals-Cadd9-Model-Voicing-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Voicings are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Voicing](#T-Cadd9-Model-Voicing 'Cadd9.Model.Voicing') | The other Voicings to compare |

<a name='M-Cadd9-Model-Voicing-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent Qualities are guaranteed to produce the
  same result.

##### Parameters

This method has no parameters.
