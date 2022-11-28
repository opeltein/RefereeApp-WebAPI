namespace RefereeApp.Models.ApiModels
{
    public class CreateEventRequestAdmin
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }

    }
}
