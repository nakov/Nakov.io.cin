namespace Console.Cin.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Globalization;
    using System.Threading;
    using Nakov.IO;

    [TestClass]
    public class ComplexTests : CinTest
    {
        [TestMethod]
        public void TestMultipleOperations()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            // If you want to add new tokens to a certain group (each group tests different methods)
            // just add it with a space between " ", except for [0], there use "\n"
            var expectedTokens = new string[] {"let's test this out. \n test 1 2 3", "1  2", "3.14 5.251", "999999999999999999999999999.00", "complex test" };
            SetInput($"{expectedTokens[0]}\n{expectedTokens[1]}\n{expectedTokens[2]}\n{expectedTokens[3]}\n{expectedTokens[4]}");

            var splittedFirstToken = expectedTokens[0].Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string expectedToken in splittedFirstToken)
            {
                var token = Console.ReadLine();
                Assert.AreEqual(expectedToken, token);
            }

            var splittedSecondToken = expectedTokens[1].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string expectedToken in splittedSecondToken)
            {
                var token = Cin.NextInt();
                Assert.AreEqual(int.Parse(expectedToken), token);
            }

            var splittedThirdToken = expectedTokens[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string expectedToken in splittedThirdToken)
            {
                var token = Cin.NextDouble();
                Assert.AreEqual(double.Parse(expectedToken), token);
            }

            var splittedFourthToken = expectedTokens[3].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string expectedToken in splittedFourthToken)
            {
                var token = Cin.NextDecimal();
                Assert.AreEqual(decimal.Parse(expectedToken), token);
            }

            var splittedFifthToken = expectedTokens[4].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string expectedToken in splittedFifthToken)
            {
                var token = Cin.NextToken();
                Assert.AreEqual(expectedToken, token);
            }
        }
    }
}
