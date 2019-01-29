using System.Security.Cryptography.X509Certificates;
using Moq;
using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    internal class ElectionResultProcessorShould
    {
        [Test]
        public void CallsCollaboratorsInTheCorrectOrder()
        {
            var fileReader = new Mock<FileReader>();
            var outputFeed = new Mock<OutputFeed>();
            var resultParser = new Mock<ResultParser>();
            var resultTransformer = new Mock<ResultTransformer>();
            var resultFormatter = new Mock<ResultFormatter>();

            fileReader.Setup(x => x.ReadLinesFromFile()).Returns("a single line");
            var rawElectionResult = new RawElectionResult();
            resultParser.Setup(x => x.ParseElectionResult("a single line")).Returns(rawElectionResult);
            var transformedElectionResult = new TransformedElectionResult();
            resultTransformer.Setup(x => x.TransformResult(rawElectionResult)).Returns(transformedElectionResult);
            resultFormatter.Setup(x => x.FormatResult(transformedElectionResult)).Returns("a single, formatted line");

            var electionResultProcessor = new ElectionResultProcessor(fileReader.Object, outputFeed.Object, resultParser.Object, resultTransformer.Object, resultFormatter.Object);
            electionResultProcessor.ProcessResults();

            outputFeed.Verify(x => x.FeedOutput("a single, formatted line"));
        }
    }
}
