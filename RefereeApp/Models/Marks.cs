namespace RefereeApp.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
