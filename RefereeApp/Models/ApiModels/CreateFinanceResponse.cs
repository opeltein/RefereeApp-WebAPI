namespace RefereeApp.Models.ApiModels
{
    public class CreateFinanceResponse
    {
        public CreateFinanceResponse(int financeId)
        {
            FinanceId = financeId;
        }

        public int FinanceId { get; }

    }
}
