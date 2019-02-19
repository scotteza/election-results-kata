namespace ElectionResultsKata
{
    public class ResultParser
    {
        private const char Separator = ',';

        public virtual RawElectionResult ParseElectionResult(string inputLine)
        {
            var split = inputLine.Split(Separator);

            var rawElectionResult = new RawElectionResult
            {
                Constituency = GetConstituency(split)
            };

            for (var i = 1; i < split.Length; i += 2)
            {
                var count = GetCount(split, i);
                var party = GetParty(split, i);
                var voteCount = new VoteCount(party, count);
                rawElectionResult.AddVoteCount(voteCount);
            }

            return rawElectionResult;
        }

        private static string GetConstituency(string[] split)
        {
            return split[0];
        }

        private static int GetCount(string[] split, int i)
        {
            var count = int.Parse(split[i]);
            return count;
        }

        private static string GetParty(string[] split, int i)
        {
            var party = split[i + 1].Trim();
            return party;
        }
    }
}