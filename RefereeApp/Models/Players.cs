using System.Text.Json.Serialization;

namespace RefereeApp.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public int JerseyNumber { get; set; }
        [JsonIgnore]
        public virtual Teams Teams { get; set; }
        public int TeamsId { get; set; }
    }
}
