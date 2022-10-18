namespace Infoss.Operation.PaymentRequestService.Helper
{
    public class PaymentRequestRead
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string RowStatus { get; set; } = string.Empty;
        //public string Column { get; set; } = string.Empty;
        public string UserCode { get; set; } = string.Empty;
        //private string Password { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public fieldFilter[] Filter { get; set; }
    }

    public class fieldFilter
    {
        public string Field { get; set; }
        public string Data { get; set; }
    }
}
