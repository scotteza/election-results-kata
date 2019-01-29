namespace ElectionResultsKata
{
    public class ElectionResultProcessor
    {
        private FileReader _fileReader;
        private OutputFeed _outputFeed;

        public ElectionResultProcessor(FileReader fileReader, OutputFeed outputFeed)
        {
            _fileReader = fileReader;
            _outputFeed = outputFeed;
        }

        public void ProcessResults()
        {

        }
    }
}