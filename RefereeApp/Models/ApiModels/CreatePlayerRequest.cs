namespace RefereeApp.Models.ApiModels
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public int JerseyNumber { get; set; }
        public int TeamsId { get; set; }

    }
}
