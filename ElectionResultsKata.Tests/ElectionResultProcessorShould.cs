using Moq;
using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    class ElectionResultProcessorShould
    {
        [Test]
        public void CallsCollaboratorsInTheCorrectOrder()
        {
            var fileReader = new Mock<FileReader>();
            var outputFeed = new Mock<OutputFeed>();
            var resultParser = new Mock<ResultParser>();

            fileReader.Setup(x => x.ReadLinesFromFile()).Returns("a single line");

            var electionResultProcessor = new ElectionResultProcessor(fileReader.Object, outputFeed.Object, resultParser.Object);
            electionResultProcessor.ProcessResults();

            resultParser.Verify(x => x.ParseElectionResult("a single line"));
        }
    }
}
