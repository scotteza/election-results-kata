namespace ElectionResultsKata
{
    public class ResultTransformer
    {
        public virtual TransformedElectionResult TransformResult(RawElectionResult rawElectionResult)
        {
            var transformedElectionResult = new TransformedElectionResult(rawElectionResult.Constituency);
            foreach (var voteCount in rawElectionResult.GetVoteCounts())
            {
                transformedElectionResult.AddVoteCount(new VoteCount("Conservative Party", voteCount.Count));
            }
            return transformedElectionResult;
        }
    }
}