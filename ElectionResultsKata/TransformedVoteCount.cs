namespace ElectionResultsKata
{
    public class TransformedVoteCount
    {
        public string PartyName { get; }
        public int Count { get; }

        public TransformedVoteCount(string partyName, int count)
        {
            PartyName = partyName;
            Count = count;
        }
    }
}