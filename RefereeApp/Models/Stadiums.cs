using System.Text.Json.Serialization;

namespace RefereeApp.Models
{
    public class Stadiums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        [JsonIgnore]

        public virtual List<Teams> Teams { get; set; }

    }
}
