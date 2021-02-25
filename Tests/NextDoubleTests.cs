namespace Console.Cin.Tests
{
    using System.Threading;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Nakov.IO;

    [TestClass]
    public class NextDoubleTests : CinTest
    { 
        [TestMethod]
        public void TestNextDoubleDefaultSeparator()
        {
            double expectedToken = 25322.235;
            SetInput(expectedToken.ToString(CultureInfo.InvariantCulture));

            var inputToken = Cin.NextDouble();

            Assert.AreEqual(expectedToken, inputToken);
        }

        [TestMethod]
        public void TestNextDoubleDefaultSeparatorMultipleTimes()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var expectedTokens = new double[] { double.NegativeInfinity, double.PositiveInfinity, 3123.32, 2.3345, 2.5321 };
            SetInput(
                $"\r  \n\t\n\n  \t\n{expectedTokens[0]}  \n\n   \t {expectedTokens[1]}\n" +
                $"  {expectedTokens[2]}\n\t{expectedTokens[3]} {expectedTokens[4]}");

            var inputTokens = new double[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextDouble(false);
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }

        [TestMethod]
        public void TestNextDoubleMixedSeparatorMultipleTimes()
        {
            var expectedTokens = new double[] { 1.32, 25231533.2, 312.235331 };
            SetInput("1,32\n\t\f   25231533.2 \n\n  312,235331");

            var inputTokens = new double[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextDouble(true);
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }
    }
}
