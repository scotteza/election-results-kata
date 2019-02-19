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

        [Test]
        public void Parse_A_Line_With_A_Multiple_Results()
        {
            var resultParser = new ResultParser();

            var rawElectionResult = resultParser.ParseElectionResult("Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD");
            var voteCounts = rawElectionResult.GetVoteCounts();

            Assert.That(rawElectionResult.Constituency, Is.EqualTo("Cardiff West"));

            Assert.That(voteCounts.Count, Is.EqualTo(4));

            Assert.That(voteCounts[0].Party, Is.EqualTo("C"));
            Assert.That(voteCounts[0].Count, Is.EqualTo(11014));

            Assert.That(voteCounts[1].Party, Is.EqualTo("L"));
            Assert.That(voteCounts[1].Count, Is.EqualTo(17803));

            Assert.That(voteCounts[2].Party, Is.EqualTo("UKIP"));
            Assert.That(voteCounts[2].Count, Is.EqualTo(4923));

            Assert.That(voteCounts[3].Party, Is.EqualTo("LD"));
            Assert.That(voteCounts[3].Count, Is.EqualTo(2069));
        }
    }
}
