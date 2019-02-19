namespace ElectionResultsKata
{
    public class VoteCount
    {
        public string Party { get; }
        public int Count { get; }

        public VoteCount(string party, int count)
        {
            Party = party;
            Count = count;
        }
    }
}