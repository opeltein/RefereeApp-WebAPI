namespace RefereeApp.Models.ApiModels
{
    public class CreateStadiumsResponse
    {
        public CreateStadiumsResponse(int stadiumId)
        {
            StadiumId = stadiumId;
        }
        public int StadiumId { get; }
    }
}
