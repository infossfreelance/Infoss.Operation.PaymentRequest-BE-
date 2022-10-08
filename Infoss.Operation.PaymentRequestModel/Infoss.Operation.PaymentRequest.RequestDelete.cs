namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestDeleteRequest
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public string user { get; set; } = string.Empty;
    }
}
