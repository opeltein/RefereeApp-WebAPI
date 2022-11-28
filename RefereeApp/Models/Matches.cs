using System.Text.Json.Serialization;

namespace RefereeApp.Models
{
    public class Matches
    {

        
        public int Id { get; set; }
      


        public int HomeTeamId { get; set; }

        [JsonIgnore]
        public virtual Teams HomeTeam { get; set; }


        public int AwayTeamId { get; set; }
        [JsonIgnore]
        public virtual Teams AwayTeam { get; set; }




        public int HomeTeamGools { get; set; }
        public int AwayTeamGools { get; set; }

        

     
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        [JsonIgnore]
        public virtual List<UserMatches> UserMatches { get; set; }

    }
}
