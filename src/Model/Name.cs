using System;
using Util;

using static Model.Name;

namespace Model
{
    public enum Name : int
    {
        [Describe("C")] [Parse("C")] C,
        [Describe("D")] [Parse("D")] D,
        [Describe("E")] [Parse("E")] E,
        [Describe("F")] [Parse("F")] F,
        [Describe("G")] [Parse("G")] G,
        [Describe("A")] [Parse("A")] A,
        [Describe("B")] [Parse("B")] B
    }
}
