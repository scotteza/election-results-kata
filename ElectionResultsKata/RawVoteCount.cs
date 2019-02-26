namespace ElectionResultsKata
{
    public class RawVoteCount
    {
        public string PartyCode { get; }
        public int Count { get; }

        public RawVoteCount(string partyCode, int count)
        {
            PartyCode = partyCode;
            Count = count;
        }
    }
}