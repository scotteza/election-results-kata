namespace ElectionResultsKata
{
    public class ResultParser
    {
        public virtual RawElectionResult ParseElectionResult(string inputLine)
        {
            var rawElectionResult = new RawElectionResult();
            rawElectionResult.Constituency = inputLine;
            return rawElectionResult;
        }
    }
}