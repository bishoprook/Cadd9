// So apparently you can either build a class library for netstandard-2.0 or an executable library for netcore-2.2
// But you can't build a class library for netcore-2.2
// So you need a class with a Main entry point
// Even if you don't plan on running as a console app or whatever
// Fuck you Microsoft
public class Program
{
    public static void Main(string[] args)
    {}
}