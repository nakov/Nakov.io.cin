namespace Console.Cin.Tests
{
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using Nakov.IO;

    [TestClass]
    public class NextDecimalTests : CinTest
    {
        [TestMethod]
        public void TestNextDecimalDefaultSeparator()
        {
            decimal expectedToken = 25322.235m;
            SetInput(expectedToken.ToString(CultureInfo.InvariantCulture));

            var inputToken = Cin.NextDecimal();

            Assert.AreEqual(expectedToken, inputToken);
        }

        [TestMethod]
        public void TestNextDecimalDefaultSeparatorEnCultureMultipleTimes()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            TestNextDecimalDefaultSeparatorMultipleTimesBase();
        }

        [TestMethod]
        public void TestNextDecimalDefaultSeparatorBgCultureMultipleTimes()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            TestNextDecimalDefaultSeparatorMultipleTimesBase();
        }

        [TestMethod]
        public void TestNextDecimalMixedSeparatorMultipleTimes()
        {
            var expectedTokens = new decimal[] { 1.32m, 25231533.2m, 312.235331m };
            SetInput("1,32\n\t\f   25231533.2 \n\n  312,235331");

            var inputTokens = new decimal[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextDecimal(true);
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }

        private void TestNextDecimalDefaultSeparatorMultipleTimesBase()
        {
            var expectedTokens = new decimal[] { decimal.MinValue, decimal.MaxValue, 3123.32m, 2.3345m, 2.5321m };
            SetInput(
                $"\r  \n\t\n\n  \t\n{expectedTokens[0]}  \n\n   \t {expectedTokens[1]}\n" +
                $"  {expectedTokens[2]}\n\t{expectedTokens[3]} {expectedTokens[4]}");

            var inputTokens = new decimal[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextDecimal(false);
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }
    }
}
