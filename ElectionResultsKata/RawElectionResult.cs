using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectionResultsKata
{
    public class RawElectionResult
    {
        public string Constituency { get; set; }
        private readonly List<VoteCount> _results;

        public RawElectionResult()
        {
            _results = new List<VoteCount>();
        }

        public void AddVoteCount(VoteCount voteCount)
        {
            _results.Add(voteCount);
        }

        public IReadOnlyList<VoteCount> GetVoteCounts()
        {
            return new ReadOnlyCollection<VoteCount>(_results);
        }
    }
}