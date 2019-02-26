using System.Linq;
using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    internal class ResultTransformerShould
    {
        [Test]
        public void SetTheConstituency()
        {
            var resultTransformer = new ResultTransformer();
            var rawElectionResult = new RawElectionResult { Constituency = "Bethnal Green" };

            var transformedElectionResult = resultTransformer.TransformResult(rawElectionResult);

            Assert.That(transformedElectionResult.Constituency, Is.EqualTo("Bethnal Green"));
        }

        [Test]
        public void LookUpASinglePartyName()
        {
            var resultTransformer = new ResultTransformer();
            var rawElectionResult = new RawElectionResult { Constituency = "Bethnal Green" };
            rawElectionResult.AddVoteCount(new RawVoteCount("C", 11014));

            var transformedElectionResult = resultTransformer.TransformResult(rawElectionResult);

            var voteCounts = transformedElectionResult.GetVoteCounts();
            Assert.That(voteCounts.Count, Is.EqualTo(1));
            Assert.That(voteCounts.First().PartyName, Is.EqualTo("Conservative Party"));
            Assert.That(voteCounts.First().Count, Is.EqualTo(11014));
        }
    }
}
