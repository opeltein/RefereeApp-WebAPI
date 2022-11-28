namespace RefereeApp.Models.ApiModels
{
    public class CreateEventRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Name { get; set; }
    }
}
