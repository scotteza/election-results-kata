using Moq;
using NUnit.Framework;

namespace ElectionResultsKata.Tests
{
    public class AcceptanceTests
    {
        [Test]
        public void CoordinatorTransformsElectionResults()
        {
            var input = @"Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD
Islington South & Finsbury, 22547, L, 9389, C, 4829, LD, 3375, UKIP, 3371, G, 309, Ind";
            var fileReader = new Mock<FileReader>();
            fileReader.Setup(x => x.ReadLinesFromFile()).Returns(input);

            var expectedOutput = @"Cardiff West || Conservative Party | 30.76% || Labour Party | 49.72% || UKIP | 13.75% || Liberal Democrats | 5.78%
Islington South & Finsbury || Labour Party | 51.45% || Conservative Party | 21.43% || Liberal Democrats | 11.02% || UKIP | 7.70% || Green Party | 7.69% || Independent | 0.70%";
            var outputFeed = new Mock<OutputFeed>();

            var electionResultProcessor = new ElectionResultProcessor(fileReader, outputFeed);
            electionResultProcessor.ProcessResults();

            outputFeed.Verify(of => of.FeedOutput(expectedOutput));
        }
    }

    public interface FileReader
    {
        string ReadLinesFromFile();
    }

    public class ElectionResultProcessor
    {
        private readonly Mock<FileReader> _fileReader;
        private Mock<OutputFeed> _outputFeed;

        public ElectionResultProcessor(Mock<FileReader> fileReader, Mock<OutputFeed> outputFeed)
        {
            _fileReader = fileReader;
            _outputFeed = outputFeed;
        }

        public void ProcessResults()
        {

        }
    }

    public interface OutputFeed
    {
        void FeedOutput(string expectedOutput);
    }
}
