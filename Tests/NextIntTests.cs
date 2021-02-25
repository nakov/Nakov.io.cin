namespace Console.Cin.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Nakov.IO;

    [TestClass]
    public class NextIntTests : CinTest
    {
        [TestMethod]
        public void TestNextInt()
        {
            var expectedToken = 553;
            SetInput(expectedToken.ToString());

            var inputToken = Cin.NextInt();

            Assert.AreEqual(expectedToken, inputToken);
        }

        [TestMethod]
        public void TestNextIntMultipleTimesWithIntMinAndMax()
        {
            var expectedTokens = new int[] { int.MinValue, int.MaxValue, 5, 952332, 0 };
            SetInput($"\r\n\t\t\n{expectedTokens[0]}\n\n   \t {expectedTokens[1]} \t\n{expectedTokens[2]}" +
                     $"   {expectedTokens[3]}\n\n\n\n\f\f\f {expectedTokens[4]}");

            var inputTokens = new int[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextInt();
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }
    }
}
