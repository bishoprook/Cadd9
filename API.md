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
- [Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval')
  - [#ctor(generic,specific)](#M-Cadd9-Model-Interval-#ctor-System-Int32,System-Int32- 'Cadd9.Model.Interval.#ctor(System.Int32,System.Int32)')
  - [Abbreviation](#P-Cadd9-Model-Interval-Abbreviation 'Cadd9.Model.Interval.Abbreviation')
  - [Description](#P-Cadd9-Model-Interval-Description 'Cadd9.Model.Interval.Description')
  - [Generic](#P-Cadd9-Model-Interval-Generic 'Cadd9.Model.Interval.Generic')
  - [Specific](#P-Cadd9-Model-Interval-Specific 'Cadd9.Model.Interval.Specific')
  - [Between(first,second)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Name,Cadd9-Model-Name- 'Cadd9.Model.Interval.Between(Cadd9.Model.Name,Cadd9.Model.Name)')
  - [Between(first,second)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Note,Cadd9-Model-Note- 'Cadd9.Model.Interval.Between(Cadd9.Model.Note,Cadd9.Model.Note)')
  - [Between(first,second)](#M-Cadd9-Model-Interval-Between-Cadd9-Model-Pitch,Cadd9-Model-Pitch- 'Cadd9.Model.Interval.Between(Cadd9.Model.Pitch,Cadd9.Model.Pitch)')
  - [Enharmonic(other)](#M-Cadd9-Model-Interval-Enharmonic-Cadd9-Model-Interval- 'Cadd9.Model.Interval.Enharmonic(Cadd9.Model.Interval)')
  - [Equals(other)](#M-Cadd9-Model-Interval-Equals-Cadd9-Model-Interval- 'Cadd9.Model.Interval.Equals(Cadd9.Model.Interval)')
  - [GenericIntervalName()](#M-Cadd9-Model-Interval-GenericIntervalName-System-Int32- 'Cadd9.Model.Interval.GenericIntervalName(System.Int32)')
  - [GetHashCode()](#M-Cadd9-Model-Interval-GetHashCode 'Cadd9.Model.Interval.GetHashCode')
  - [Parse(input)](#M-Cadd9-Model-Interval-Parse-System-String- 'Cadd9.Model.Interval.Parse(System.String)')
  - [ParseFormal()](#M-Cadd9-Model-Interval-ParseFormal-System-String- 'Cadd9.Model.Interval.ParseFormal(System.String)')
  - [ParseSimple()](#M-Cadd9-Model-Interval-ParseSimple-System-String- 'Cadd9.Model.Interval.ParseSimple(System.String)')
  - [ToString()](#M-Cadd9-Model-Interval-ToString 'Cadd9.Model.Interval.ToString')
  - [op_Addition()](#M-Cadd9-Model-Interval-op_Addition-Cadd9-Model-Interval,Cadd9-Model-Interval- 'Cadd9.Model.Interval.op_Addition(Cadd9.Model.Interval,Cadd9.Model.Interval)')
  - [op_Subtraction()](#M-Cadd9-Model-Interval-op_Subtraction-Cadd9-Model-Interval,Cadd9-Model-Interval- 'Cadd9.Model.Interval.op_Subtraction(Cadd9.Model.Interval,Cadd9.Model.Interval)')
- [Mode](#T-Cadd9-Model-Mode 'Cadd9.Model.Mode')
  - [#ctor(title,intervals)](#M-Cadd9-Model-Mode-#ctor-System-String,System-Collections-Generic-ISet{Cadd9-Model-Interval}- 'Cadd9.Model.Mode.#ctor(System.String,System.Collections.Generic.ISet{Cadd9.Model.Interval})')
  - [#ctor(title,intervals)](#M-Cadd9-Model-Mode-#ctor-System-String,System-String[]- 'Cadd9.Model.Mode.#ctor(System.String,System.String[])')
  - [Intervals](#P-Cadd9-Model-Mode-Intervals 'Cadd9.Model.Mode.Intervals')
  - [Title](#P-Cadd9-Model-Mode-Title 'Cadd9.Model.Mode.Title')
  - [AccidentalFor()](#M-Cadd9-Model-Mode-AccidentalFor-Cadd9-Model-Note,Cadd9-Model-Name- 'Cadd9.Model.Mode.AccidentalFor(Cadd9.Model.Note,Cadd9.Model.Name)')
  - [Ascend()](#M-Cadd9-Model-Mode-Ascend 'Cadd9.Model.Mode.Ascend')
  - [Equals(other)](#M-Cadd9-Model-Mode-Equals-Cadd9-Model-Mode- 'Cadd9.Model.Mode.Equals(Cadd9.Model.Mode)')
  - [GetHashCode()](#M-Cadd9-Model-Mode-GetHashCode 'Cadd9.Model.Mode.GetHashCode')
  - [Quality(degree,width)](#M-Cadd9-Model-Mode-Quality-System-Int32,System-Int32- 'Cadd9.Model.Mode.Quality(System.Int32,System.Int32)')
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
  - [ToString()](#M-Cadd9-Model-Pitch-ToString 'Cadd9.Model.Pitch.ToString')
  - [Transpose(octaves)](#M-Cadd9-Model-Pitch-Transpose-System-Int32- 'Cadd9.Model.Pitch.Transpose(System.Int32)')
- [Quality](#T-Cadd9-Model-Quality 'Cadd9.Model.Quality')
  - [#ctor(intervals)](#M-Cadd9-Model-Quality-#ctor-System-Collections-Generic-ISet{Cadd9-Model-Interval}- 'Cadd9.Model.Quality.#ctor(System.Collections.Generic.ISet{Cadd9.Model.Interval})')
  - [#ctor(intervals)](#M-Cadd9-Model-Quality-#ctor-System-String[]- 'Cadd9.Model.Quality.#ctor(System.String[])')
  - [Intervals](#P-Cadd9-Model-Quality-Intervals 'Cadd9.Model.Quality.Intervals')
  - [Add(adds)](#M-Cadd9-Model-Quality-Add-Cadd9-Model-Interval[]- 'Cadd9.Model.Quality.Add(Cadd9.Model.Interval[])')
  - [Apply()](#M-Cadd9-Model-Quality-Apply-Cadd9-Model-Note- 'Cadd9.Model.Quality.Apply(Cadd9.Model.Note)')
  - [Apply()](#M-Cadd9-Model-Quality-Apply-Cadd9-Model-Pitch- 'Cadd9.Model.Quality.Apply(Cadd9.Model.Pitch)')
  - [Equals(other)](#M-Cadd9-Model-Quality-Equals-Cadd9-Model-Quality- 'Cadd9.Model.Quality.Equals(Cadd9.Model.Quality)')
  - [GetHashCode()](#M-Cadd9-Model-Quality-GetHashCode 'Cadd9.Model.Quality.GetHashCode')
  - [ToString()](#M-Cadd9-Model-Quality-ToString 'Cadd9.Model.Quality.ToString')

<a name='T-Cadd9-Model-Accidental'></a>
## Accidental `type`

##### Namespace

Cadd9.Model

##### Summary

Represents an accidental that shifts some note or pitch by a certain number
of semitones away from natural.

<a name='M-Cadd9-Model-Accidental-#ctor-System-Int32-'></a>
### #ctor(semitones) `constructor`

##### Summary

Returns a new Accidental

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| semitones | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of semitones this accidental shifts a pitch or note. Positive
values indicate sharps, negative values indicate flats. |

<a name='P-Cadd9-Model-Accidental-Description'></a>
### Description `property`

##### Summary

A formatted representation of this Accidental as a UTF-8 string.

<a name='P-Cadd9-Model-Accidental-Semitones'></a>
### Semitones `property`

##### Summary

The number of semitones this accidental shifts a pitch or note. Positive
values indicate sharps, negative values indicate flats.

<a name='M-Cadd9-Model-Accidental-Enharmonic-Cadd9-Model-Accidental-'></a>
### Enharmonic(other) `method`

##### Summary

Returns true if `other` is enharmonic with this Accidental.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The Accidental to compare with |

##### Remarks

Two accidentals are enharmonic if they are equal or if their `Semitones`
differ by an even multiple of 12. For example 5 flats is enharmonic with 7
sharps: C♯♯♯♯♯ and C♭♭♭♭♭♭♭ are both enharmonic with each other and with
F natural.

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

Produces a high-entropy hash code such that two value-equivalent
Accidentals are guaranteed to produce the same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Accidental-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Returns a new Accidental based on the given input string. Assumes the input
will be in plain ASCII format: "b" for flats, "#" for sharps.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The plain ASCII input string to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |

<a name='M-Cadd9-Model-Accidental-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Accidental, primarily for
debugging purposes.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Interval'></a>
## Interval `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a musical width between notes or pitches.

<a name='M-Cadd9-Model-Interval-#ctor-System-Int32,System-Int32-'></a>
### #ctor(generic,specific) `constructor`

##### Summary

Creates an Interval with the given generic and specific widths.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| generic | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of note names spanned by the interval |
| specific | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of semitones spanned by the interval |

<a name='P-Cadd9-Model-Interval-Abbreviation'></a>
### Abbreviation `property`

##### Summary

A short formatted description of the interval, like "P4"

<a name='P-Cadd9-Model-Interval-Description'></a>
### Description `property`

##### Summary

A long-form formatted description of the interval, like "Perfect Fourth"

<a name='P-Cadd9-Model-Interval-Generic'></a>
### Generic `property`

##### Summary

The number of note names shifted between the bottom and top of this Interval:
for example a minor third, major third, and augmented third would all have
a Generic value of 2, and when applied to a C with any accidentals will produce
an E with accidentals determined by this Interval's `Specific` value.

<a name='P-Cadd9-Model-Interval-Specific'></a>
### Specific `property`

##### Summary

The number of semitones shifted between the bottom and top of this Interval.
For example, a minor third and augmented second both have a Specific value of 3,
because both move up 3 semitones, like from C to E♭/D♯ respectively.

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Name,Cadd9-Model-Name-'></a>
### Between(first,second) `method`

##### Summary

Returns a new Interval representing the width between two `Name`s. It is
always assumed that the interval is going up from first to second: C to B would
give an interval of a major seventh (despite being much closer to go down a
minor second). Also for this reason, this method will always produce an interval
between unison (inclusive) and an octave (exclusive).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The lower Name to compare |
| second | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The higher Name to compare |

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Note,Cadd9-Model-Note-'></a>
### Between(first,second) `method`

##### Summary

Returns a new Interval representing the width between two `Note`s. It is
always assumed that the interval is going up from first to second: C♯ to B would
give an interval of a minor seventh (despite being much closer to go down a
major second). Also for this reason, this method will always produce an interval
between unison (inclusive) and an octave (exclusive).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The lower Note to compare |
| second | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The higher Note to compare |

<a name='M-Cadd9-Model-Interval-Between-Cadd9-Model-Pitch,Cadd9-Model-Pitch-'></a>
### Between(first,second) `method`

##### Summary

Returns a new Interval representing the width between two `Pitch`es. It is
always assumed that the interval is going up from first to second: C♯3 to B4 would
give an interval of a minor fifteenth.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The lower Pitch to compare |
| second | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The higher Pitch to compare |

<a name='M-Cadd9-Model-Interval-Enharmonic-Cadd9-Model-Interval-'></a>
### Enharmonic(other) `method`

##### Summary

Returns true if `other` is enharmonically equivalent to this interval, or in
other words, the two intervals have the same specific width. Perfect unison and
diminished second, for example, are enharmonic despite having different generic
widths.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The other Interval to compare |

<a name='M-Cadd9-Model-Interval-Equals-Cadd9-Model-Interval-'></a>
### Equals(other) `method`

##### Summary

Determines whether two Intervals are value-equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The Intervals to compare |

<a name='M-Cadd9-Model-Interval-GenericIntervalName-System-Int32-'></a>
### GenericIntervalName() `method`

##### Summary

Returns the name of an interval with the given generic width, for example
0 -> "Unison", 4 -> "Fifth", 22 -> "23rd"

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Produces a high-entropy hash code such that two value-equivalent
Intervals are guaranteed to produce the same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-Parse-System-String-'></a>
### Parse(input) `method`

##### Summary

Returns a new Interval by parsing the given string input. Two formats are accepted:
Formal, like `P4` and `d3`, or simple, like `b5` and `#9`. If
the simple form is used, then the major/perfect matching interval is sharped the
given number of times. The formal form understands (P)erfect, (d)iminished,
(m)inor, (M)ajor, and (A)ugmented descriptors for each interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input to parse |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The given input cannot be parsed |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If an illegal modifier is supplied for the interval |

<a name='M-Cadd9-Model-Interval-ParseFormal-System-String-'></a>
### ParseFormal() `method`

##### Summary

Parses the given input using "formal" notation: "P4" for a perfect fourth, "m3" for a
minor third, etc. Returns null if the input cannot be parsed accordingly.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If an illegal modifier is supplied for the interval |

<a name='M-Cadd9-Model-Interval-ParseSimple-System-String-'></a>
### ParseSimple() `method`

##### Summary

Parses the given input using "simple" notation: "3" for a major third, "b5" for a flat fifth,
etc. This format is commonly used to describe the component intervals of chords.

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

Creates a new compound Interval by combining two others. For example, adding together
a perfect octave and a perfect fifth produces a perfect thirteenth.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Interval-op_Subtraction-Cadd9-Model-Interval,Cadd9-Model-Interval-'></a>
### op_Subtraction() `method`

##### Summary

Creates a new compound Interval by subtracting one from the other. For example,
subtracting a minor second from a perfect octave produces a major seventh.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Mode'></a>
## Mode `type`

##### Namespace

Cadd9.Model

<a name='M-Cadd9-Model-Mode-#ctor-System-String,System-Collections-Generic-ISet{Cadd9-Model-Interval}-'></a>
### #ctor(title,intervals) `constructor`

##### Summary

Returns a new Mode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title of this Mode |
| intervals | [System.Collections.Generic.ISet{Cadd9.Model.Interval}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ISet 'System.Collections.Generic.ISet{Cadd9.Model.Interval}') | The intervals that make up this Mode |

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
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if a generic interval appears multiple times |

##### Remarks

The intervals given in this constructor will be parsed according to the behavior in
[Parse](#M-Cadd9-Model-Interval-Parse-System-String- 'Cadd9.Model.Interval.Parse(System.String)') which allows short-hand construction.

<a name='P-Cadd9-Model-Mode-Intervals'></a>
### Intervals `property`

##### Summary

A set of all the Intervals that make up this Mode

<a name='P-Cadd9-Model-Mode-Title'></a>
### Title `property`

##### Summary

A descriptive title of this Mode

<a name='M-Cadd9-Model-Mode-AccidentalFor-Cadd9-Model-Note,Cadd9-Model-Name-'></a>
### AccidentalFor() `method`

##### Summary

Yields the Accidental associated with a given name for a given key.

##### Parameters

This method has no parameters.

##### Remarks

This may be used, for example, to place sharps and flats on a staff given a
particular key. In the D major (Ionian) key, F and C have a sharp accidental
while all other names are natural. This may also be used to determine how to
render a note: if its accidental is the same as the accidental for its name
in the key, no symbol need be added.

<a name='M-Cadd9-Model-Mode-Ascend'></a>
### Ascend() `method`

##### Summary

Yields every Interval in this mode starting from unison. Will progress infinitely,
so take only what is needed.

##### Parameters

This method has no parameters.

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

Produces a high-entropy hash code such that two value-equivalent
Modes are guaranteed to produce the same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Mode-Quality-System-Int32,System-Int32-'></a>
### Quality(degree,width) `method`

##### Summary

Returns a chord based on the given scale degree of this mode.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| degree | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The scale degree to use as the root |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of notes to return (3 = major, 4 = dom 7, etc) |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | if degree or width are out of bounds |

##### Remarks

Each mode has 7 scale degrees that produce 7 signature chord qualities. For example, the
major (Ionian) mode's fourth scale degree (iv) is a minor triad, while the Phrygian mode's
fifth scale degree (v°) is a diminished triad.

<a name='M-Cadd9-Model-Mode-Scale-Cadd9-Model-Note-'></a>
### Scale() `method`

##### Summary

Yields every Note in this mode starting from the given tonic. Will progress
infinitely, so take only what is needed.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Mode-Scale-Cadd9-Model-Pitch-'></a>
### Scale() `method`

##### Summary

Yields every Pitch in this mode starting from the given tonic. Will progress
infinitely, so take only what is needed.

##### Parameters

This method has no parameters.

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

Represents a note Name with an associated modifying Accidental.

<a name='M-Cadd9-Model-Note-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental-'></a>
### #ctor(name,accidental) `constructor`

##### Summary

Returns a new Note

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The Name associated with this Note |
| accidental | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The Accidental modifying this Note |

<a name='P-Cadd9-Model-Note-Accidental'></a>
### Accidental `property`

##### Summary

The Accidental modifying this Note

<a name='P-Cadd9-Model-Note-Description'></a>
### Description `property`

##### Summary

A formatted representation of this Note as a UTF-8 string.

<a name='P-Cadd9-Model-Note-Name'></a>
### Name `property`

##### Summary

The Name associated with this Note

<a name='P-Cadd9-Model-Note-PitchClass'></a>
### PitchClass `property`

##### Summary

The pitch class (0 to 11) of this Note.

##### Remarks

The concept of pitch class is often used in post-tonal music to describe
pitches without being based in any given heptatonic scale. C is equivalent
to a pitch class of 0, and each pitch class going up is separated by a
semitone. All Notes that are enharmonic by definition have the same pitch
class.

<a name='M-Cadd9-Model-Note-Apply-Cadd9-Model-Interval-'></a>
### Apply(interval) `method`

##### Summary

Produces a new Note by applying the given Interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | Describes how to generate the new note. The new note's Name will be incremented
by interval.Generic, while the new note's pitch will be incremented by
interval.Specific. The new note's Accidental will be set appropriately to this
new pitch. |

<a name='M-Cadd9-Model-Note-Enharmonic-Cadd9-Model-Note-'></a>
### Enharmonic(other) `method`

##### Summary

Determines whether two Notes are enharmonically equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The other Note to compare |

##### Remarks

Two Notes are enharmonic if they map to the same key on a keyboard: for example, while
D♯ and E♭ are distinct notes that play different musical roles, they are enharmonic.

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

Produces a high-entropy hash code such that two value-equivalent
Notes are guaranteed to produce the same result.

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

The input is treated as case-insensitive. The first character is parsed as a [Name](#P-Cadd9-Model-Note-Name 'Cadd9.Model.Note.Name')
while the rest is parsed according to [Parse](#M-Cadd9-Model-Accidental-Parse-System-String- 'Cadd9.Model.Accidental.Parse(System.String)'). Examples of valid
Notes would include "B", "Ebb", "c#"

<a name='M-Cadd9-Model-Note-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Note, primarily for
debugging purposes.

##### Parameters

This method has no parameters.

<a name='T-Cadd9-Model-Pitch'></a>
## Pitch `type`

##### Namespace

Cadd9.Model

##### Summary

A particular musical pitch achieved by playing a Note in a particular octave

<a name='M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Note,System-Int32-'></a>
### #ctor(note,octave) `constructor`

##### Summary

Returns a new Pitch

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| note | [Cadd9.Model.Note](#T-Cadd9-Model-Note 'Cadd9.Model.Note') | The Note to represent this Pitch |
| octave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The octave corresponding to this Pitch |

<a name='M-Cadd9-Model-Pitch-#ctor-Cadd9-Model-Name,Cadd9-Model-Accidental,System-Int32-'></a>
### #ctor(name,accidental,octave) `constructor`

##### Summary

Returns a new Pitch

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [Cadd9.Model.Name](#T-Cadd9-Model-Name 'Cadd9.Model.Name') | The Name of this Pitch's Note |
| accidental | [Cadd9.Model.Accidental](#T-Cadd9-Model-Accidental 'Cadd9.Model.Accidental') | The Accidental of this Pitch's Note |
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

Though there is no universal standard for what octave represents middle-C,
this treats C-4 as middle C, with the MIDI note number 60.

<a name='P-Cadd9-Model-Pitch-Note'></a>
### Note `property`

##### Summary

The Note represented by this Pitch

<a name='P-Cadd9-Model-Pitch-Octave'></a>
### Octave `property`

##### Summary

The octave corresponding to this Pitch, where middle C = C4

<a name='M-Cadd9-Model-Pitch-Apply-Cadd9-Model-Interval-'></a>
### Apply(interval) `method`

##### Summary

Produces a new (higher) Pitch by applying the given Interval.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [Cadd9.Model.Interval](#T-Cadd9-Model-Interval 'Cadd9.Model.Interval') | The Interval between this and the new Pitch |

##### Remarks

The Note Name will be incremented by interval.Generic, while the pitch will be
incremented by interval.Specific (in semitones). The new Accidental will be set
as appropriate to this pitch.

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

This method will include a symbol for the accidental only if it is different
than the associated Name in the given key. For example, C♮4 would be rendered
"C4" in the key of C Ionian, but would be "C♮4" in the key of D Ionian, because
in that key a C would normally be sharp. Likewise, in D Ionian the pitch F♯3
would be rendered as "F3" because F is normally sharp in that key.

<a name='M-Cadd9-Model-Pitch-Enharmonic-Cadd9-Model-Pitch-'></a>
### Enharmonic(other) `method`

##### Summary

Determines whether two Pitches are enharmonically equivalent

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [Cadd9.Model.Pitch](#T-Cadd9-Model-Pitch 'Cadd9.Model.Pitch') | The other Pitch to compare |

##### Remarks

Two Pitches are enharmonic if they map to the same key on a keyboard: for example, while
D♯4 and E♭4 are distinct notes that play different musical roles, they are enharmonic.

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

Produces a high-entropy hash code such that two value-equivalent
Notes are guaranteed to produce the same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Pitch-InOctave-System-Int32-'></a>
### InOctave(octave) `method`

##### Summary

Returns a new Note transposed to the given octave.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| octave | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The octave of the desired note. |

<a name='M-Cadd9-Model-Pitch-ToString'></a>
### ToString() `method`

##### Summary

Returns a string representation of this Pitch, primarily for
debugging purposes.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Pitch-Transpose-System-Int32-'></a>
### Transpose(octaves) `method`

##### Summary

Returns a new Note transposed by the given number of octaves.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| octaves | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of octaves to transpose. If positive, the pitch will increase. If
negative, it will decrease. |

<a name='T-Cadd9-Model-Quality'></a>
## Quality `type`

##### Namespace

Cadd9.Model

##### Summary

Represents a particular chord quality that may be applied with any given root

<a name='M-Cadd9-Model-Quality-#ctor-System-Collections-Generic-ISet{Cadd9-Model-Interval}-'></a>
### #ctor(intervals) `constructor`

##### Summary

Returns a new Quality

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| intervals | [System.Collections.Generic.ISet{Cadd9.Model.Interval}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ISet 'System.Collections.Generic.ISet{Cadd9.Model.Interval}') | The set of Intervals that define this chord quality |

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

<a name='M-Cadd9-Model-Quality-Add-Cadd9-Model-Interval[]-'></a>
### Add(adds) `method`

##### Summary

Returns a new Quality by adding the given Intervals

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| adds | [Cadd9.Model.Interval[]](#T-Cadd9-Model-Interval[] 'Cadd9.Model.Interval[]') | The Intervals to add |

##### Remarks

This can be used to create a chord with arbitrary extensions. Common extensions include the
7th, 9th, and 11th.

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

Produces a high-entropy hash code such that two value-equivalent
Qualities are guaranteed to produce the same result.

##### Parameters

This method has no parameters.

<a name='M-Cadd9-Model-Quality-ToString'></a>
### ToString() `method`

##### Summary

A string representation of this Mode, useful for debugging.

##### Parameters

This method has no parameters.
