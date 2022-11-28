using System.Text.Json.Serialization;

namespace RefereeApp.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public virtual Stadiums Stadium { get; set; }

        public int StadiumId { get; set; }

        public virtual List<Players> Players { get; set; }

        public virtual List<Matches> HomeTeamMatches { get; set; }

        public virtual List<Matches> AwayTeamMatches { get; set; }

        
    }
}
