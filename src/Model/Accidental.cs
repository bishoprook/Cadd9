using System;
using Util;
using static Model.Accidental;

namespace Model
{
    public enum Accidental
    {
        [Parse("bb")] [Describe("𝄫")] DOUBLE_FLAT = -2,
        [Parse("b")] [Describe("♭")] FLAT = -1,
        [Parse("")] [Parse("nat")] [Describe("♮")] NATURAL = 0,
        [Parse("#")] [Describe("♯")] SHARP = 1,
        [Parse("##")] [Describe("𝄪")] DOUBLE_SHARP = 2
    }
}
