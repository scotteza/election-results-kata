using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectionResultsKata
{
    public class RawElectionResult
    {
        public string Constituency { get; set; }
        private readonly List<RawVoteCount> _results;

        public RawElectionResult()
        {
            _results = new List<RawVoteCount>();
        }

        public void AddVoteCount(RawVoteCount voteCount)
        {
            _results.Add(voteCount);
        }

        public IReadOnlyList<RawVoteCount> GetVoteCounts()
        {
            return new ReadOnlyCollection<RawVoteCount>(_results);
        }
    }
}