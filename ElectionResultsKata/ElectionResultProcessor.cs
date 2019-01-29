namespace ElectionResultsKata
{
    public class ElectionResultProcessor
    {
        private FileReader _fileReader;
        private OutputFeed _outputFeed;
        private readonly ResultParser _resultParser;
        private readonly ResultTransformer _resultTransformer;

        public ElectionResultProcessor(FileReader fileReader, OutputFeed outputFeed, ResultParser resultParser, ResultTransformer resultTransformer)
        {
            _fileReader = fileReader;
            _outputFeed = outputFeed;
            _resultParser = resultParser;
            _resultTransformer = resultTransformer;
        }

        public void ProcessResults()
        {
            var line = _fileReader.ReadLinesFromFile();
            var rawElectionResult = _resultParser.ParseElectionResult(line);
            _resultTransformer.TransformResult(rawElectionResult);
        }
    }
}