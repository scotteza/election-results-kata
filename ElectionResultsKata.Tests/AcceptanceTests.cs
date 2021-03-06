using System;
using Moq;
using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    internal class AcceptanceTests
    {
        [Test]
        public void CoordinatorTransformsElectionResults()
        {
            var fileReader = new Mock<FileReader>();
            var input = @"Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD" + Environment.NewLine
                        + "Islington South & Finsbury, 22547, L, 9389, C, 4829, LD, 3375, UKIP, 3371, G, 309, Ind";
            fileReader.Setup(x => x.ReadLinesFromFile()).Returns(input);

            var outputFeed = new Mock<OutputFeed>();
            var expectedOutput = @"Cardiff West || Conservative Party | 30.76% || Labour Party | 49.72% || UKIP | 13.75% || Liberal Democrats | 5.78%" + Environment.NewLine
                                   + "Islington South & Finsbury || Labour Party | 51.45% || Conservative Party | 21.43% || Liberal Democrats | 11.02% || UKIP | 7.70% || Green Party | 7.69% || Independent | 0.70%";

            var electionResultProcessor = new ElectionResultProcessor(fileReader.Object, outputFeed.Object, new ResultParser(), new ResultTransformer(), new ResultFormatter());
            electionResultProcessor.ProcessResults();

            outputFeed.Verify(of => of.FeedOutput(expectedOutput));
        }
    }
}
