namespace RefereeApp.Models.ApiModels
{
    //TODO
    public class CreateMatchesRequest
    {
        public string  RefereeId { get; set; }
        public int HomeTeamId { get; set; }       
        public int AwayTeamId { get; set; }
        
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

      
    }
}
