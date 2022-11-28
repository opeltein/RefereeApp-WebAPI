namespace RefereeApp.Models.ApiModels
{
    public class CreateEventResponse
    {
        public CreateEventResponse(int eventId)
        {
            EventId = eventId;
        }
        public int EventId { get; }
    }
}
