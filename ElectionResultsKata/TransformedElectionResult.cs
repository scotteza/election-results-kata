using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectionResultsKata
{
    public class TransformedElectionResult
    {
        public string Constituency { get; }
        private readonly List<TransformedVoteCount> _results;

        public TransformedElectionResult(string constituency)
        {
            Constituency = constituency;
            _results = new List<TransformedVoteCount>();
        }

        public void AddVoteCount(TransformedVoteCount voteCount)
        {
            _results.Add(voteCount);
        }

        public IReadOnlyList<TransformedVoteCount> GetVoteCounts()
        {
            return new ReadOnlyCollection<TransformedVoteCount>(_results);
        }
    }
}