namespace RefereeApp.Models
{
    public class UserMatches
    {
        public int Id { get; set; }

        public virtual Matches Match { get; set; }
        public int MatchId { get; set; }


        public virtual ApplicationUser Reffere { get; set; }
        public string ReffereId { get; set; }



    }
}
