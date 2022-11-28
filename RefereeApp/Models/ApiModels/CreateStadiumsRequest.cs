namespace RefereeApp.Models.ApiModels
{
    public class CreateStadiumsRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
}
