namespace RefereeApp.Models.ApiModels
{
    public class CreateMarkResponse
    {
        public CreateMarkResponse(int markId)
        {
            MarkId = markId;
        }

        public int MarkId { get; }
    }
}
