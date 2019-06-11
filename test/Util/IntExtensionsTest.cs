using Cadd9.Util;
using Xunit;

#pragma warning disable CS1591

public class IntExtensionsTest
{
    [Theory]
    [InlineData(11, 3, 2)]
    [InlineData(-8, 3, 1)]
    [InlineData(0, 10, 0)]
    [InlineData(5, 10, 5)]
    [InlineData(10, 10, 0)]
    public void TestModulus(int operand, int modulus, int expected)
    {
        Assert.Equal(expected, operand.Modulus(modulus));
    }

    [Theory]
    [InlineData(2, 10, 2)]
    [InlineData(6, 10, -4)]
    [InlineData(25, 6, 1)]
    [InlineData(29, 6, -1)]
    [InlineData(-19, 6, -1)]
    public void TestDemodulus(int operand, int modulus, int expected)
    {
        Assert.Equal(expected, operand.Demodulus(modulus));
    }
}

#pragma warning restore CS1591
