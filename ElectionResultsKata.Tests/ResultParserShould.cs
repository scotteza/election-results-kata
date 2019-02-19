using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    internal class ResultParserShould
    {
        [Test]
        public void Parse_A_Line_With_No_Results()
        {
            var resultParser = new ResultParser();

            var rawElectionResult = resultParser.ParseElectionResult("Cardiff West");

            Assert.That(rawElectionResult.Constituency, Is.EqualTo("Cardiff West"));
        }
    }
}
