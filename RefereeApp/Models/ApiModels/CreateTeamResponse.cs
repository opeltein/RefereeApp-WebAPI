namespace RefereeApp.Models.ApiModels
{
    
    public class CreateTeamResponse
    {
        public CreateTeamResponse(int teamId)
        {
            TeamId = teamId;
        }

        public int TeamId { get; }
    }
}
