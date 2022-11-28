namespace RefereeApp.Models.ApiModels
{
    public class CreatePlayerResponse
    {
        public CreatePlayerResponse(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; }
    }
}
