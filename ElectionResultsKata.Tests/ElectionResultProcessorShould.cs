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
            var resultTransformer = new Mock<ResultTransformer>();

            fileReader.Setup(x => x.ReadLinesFromFile()).Returns("a single line");
            var rawElectionResult = new RawElectionResult();
            resultParser.Setup(x => x.ParseElectionResult("a single line")).Returns(rawElectionResult);

            var electionResultProcessor = new ElectionResultProcessor(fileReader.Object, outputFeed.Object, resultParser.Object, resultTransformer.Object);
            electionResultProcessor.ProcessResults();

            resultTransformer.Verify(x => x.TransformResult(rawElectionResult));
        }
    }
}
