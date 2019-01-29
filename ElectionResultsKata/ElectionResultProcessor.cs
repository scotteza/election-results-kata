namespace ElectionResultsKata
{
    public class ElectionResultProcessor
    {
        private FileReader _fileReader;
        private OutputFeed _outputFeed;
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
            _resultFormatter.FormatResult(transformedElectionResult);
        }
    }
}