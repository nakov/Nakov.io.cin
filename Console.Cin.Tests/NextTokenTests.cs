namespace Console.Cin.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Nakov.IO;

    [TestClass]
    public class NextTokenTests : CinTest
    {      
        [TestMethod]
        public void TestNextToken()
        {
            var expectedToken = "test";
            SetInput(expectedToken);

            var inputToken = Cin.NextToken();

            Assert.AreEqual(expectedToken, inputToken);
        }

        [TestMethod]
        public void TestNextTokenUnicode()
        {
            var expectedToken = "ｲ乇丂ｲṪëṡẗⓉⓔⓢⓣՇєรՇ";
            SetInput(expectedToken);

            var inputToken = Cin.NextToken();

            Assert.AreEqual(expectedToken, inputToken);
        }

        [TestMethod]
        public void TestNextTokenMultipleTimes()
        {
            var expectedTokens = new string[] {"test", "test2", "test3", "test4"};
            SetInput($"{expectedTokens[0]}\n{expectedTokens[1]}  {expectedTokens[2]}\r\t\n {expectedTokens[3]}");

            var inputTokens = new string[expectedTokens.Length];
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                inputTokens[i] = Cin.NextToken();
            }

            CollectionAssert.AreEqual(expectedTokens, inputTokens);
        }
    }
}
