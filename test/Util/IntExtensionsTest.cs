using Util;
using Xunit;

public class IntExtensionsTest
{
    [Fact]
    public void NegModWorks()
    {
        Assert.Equal(1, (-8).Modulus(3));
    }

    [Fact]
    public void ModWorks()
    {
        Assert.Equal(2, 11.Modulus(3));
    }
}