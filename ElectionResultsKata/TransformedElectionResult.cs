using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectionResultsKata
{
    public class TransformedElectionResult
    {
        public string Constituency { get; }
        private readonly List<VoteCount> _results;

        public TransformedElectionResult(string constituency)
        {
            Constituency = constituency;
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