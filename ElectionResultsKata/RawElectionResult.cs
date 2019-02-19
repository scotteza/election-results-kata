using System.Collections.Generic;

namespace ElectionResultsKata
{
    public class RawElectionResult
    {
        public string Constituency { get; set; }
        public List<VoteCount> Results { get; set; }

        public RawElectionResult()
        {
            Results = new List<VoteCount>();
        }
    }
}