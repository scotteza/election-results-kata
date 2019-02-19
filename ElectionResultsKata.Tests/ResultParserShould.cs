using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void Parse_A_Line_With_A_Single_Result()
        {
            var resultParser = new ResultParser();

            var rawElectionResult = resultParser.ParseElectionResult("Cardiff West, 11014, C");
            var voteCounts = rawElectionResult.GetVoteCounts();

            Assert.That(rawElectionResult.Constituency, Is.EqualTo("Cardiff West"));
            Assert.That(voteCounts.Count, Is.EqualTo(1));
            Assert.That(voteCounts.First().Party, Is.EqualTo("C"));
            Assert.That(voteCounts.First().Count, Is.EqualTo(11014));
        }
    }
}
