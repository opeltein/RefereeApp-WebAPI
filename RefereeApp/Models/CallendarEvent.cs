namespace RefereeApp.Models
{
    public class CallendarEvent
    {
        //TODO: Konwencja nazwenicza, Id, Name etc
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool allDay { get; set; } = false;
        public virtual ApplicationUser User { get; set; }

    }
}
