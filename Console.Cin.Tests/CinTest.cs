namespace Console.Cin.Tests
{
    using System.IO;

    public class CinTest
    {
        protected static void SetInput(string input)
        {
            System.Console.SetIn(new StringReader(input));
        }
    }
}
