namespace RefereeApp.Models.ApiModels
{
    public class CreateMatchesResponse
    {
        public CreateMatchesResponse(int matchId)
        {
            MatchId = matchId;
        }

        public int MatchId { get; }
    }
}
