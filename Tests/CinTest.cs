namespace Console.Cin.Tests
{
    using System;
    using System.IO;

    public class CinTest
    {
        protected static void SetInput(string input)
        {
            Console.SetIn(new StringReader(input));
        }
    }
}
