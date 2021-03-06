namespace ElectionResultsKata
{
    public class ElectionResultProcessor
    {
        private readonly FileReader _fileReader;
        private readonly OutputFeed _outputFeed;
        private readonly ResultParser _resultParser;
        private readonly ResultTransformer _resultTransformer;
        private readonly ResultFormatter _resultFormatter;

        public ElectionResultProcessor(FileReader fileReader, OutputFeed outputFeed, ResultParser resultParser, ResultTransformer resultTransformer, ResultFormatter resultFormatter)
        {
            _fileReader = fileReader;
            _outputFeed = outputFeed;
            _resultParser = resultParser;
            _resultTransformer = resultTransformer;
            _resultFormatter = resultFormatter;
        }

        public void ProcessResults()
        {
            var line = _fileReader.ReadLinesFromFile();
            var rawElectionResult = _resultParser.ParseElectionResult(line);
            var transformedElectionResult = _resultTransformer.TransformResult(rawElectionResult);
            var formattedResult = _resultFormatter.FormatResult(transformedElectionResult);
            _outputFeed.FeedOutput(formattedResult);
        }
    }
}