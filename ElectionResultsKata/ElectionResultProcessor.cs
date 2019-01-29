namespace ElectionResultsKata
{
    public class ElectionResultProcessor
    {
        private FileReader _fileReader;
        private OutputFeed _outputFeed;
        private readonly ResultParser _resultParser;

        public ElectionResultProcessor(FileReader fileReader, OutputFeed outputFeed, ResultParser resultParser)
        {
            _fileReader = fileReader;
            _outputFeed = outputFeed;
            _resultParser = resultParser;
        }

        public void ProcessResults()
        {
            var line = _fileReader.ReadLinesFromFile();
            _resultParser.ParseElectionResult(line);
        }
    }
}