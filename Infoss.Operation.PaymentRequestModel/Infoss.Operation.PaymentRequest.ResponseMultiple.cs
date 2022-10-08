namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestMultipleResponse
    {
        public PaymentRequestResponse PaymentRequest { get; set; } = new PaymentRequestResponse();
        public List<PaymentRequestDetailResponse> PaymentRequestDetails { get; set; } = new List<PaymentRequestDetailResponse>();

    }
}