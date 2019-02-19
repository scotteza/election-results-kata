namespace ElectionResultsKata
{
    public class ResultParser
    {
        public virtual RawElectionResult ParseElectionResult(string inputLine)
        {
            var split = inputLine.Split(',');

            var rawElectionResult = new RawElectionResult();
            rawElectionResult.Constituency = split[0];
            for (int i = 1; i < split.Length; i += 2)
            {
                var count = int.Parse(split[i]);
                var party = split[i + 1].Trim();
                rawElectionResult.Results.Add(new VoteCount(party, count));
            }

            return rawElectionResult;
        }
    }
}