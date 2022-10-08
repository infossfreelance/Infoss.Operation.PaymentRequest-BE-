namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestMultipleRequest 
    {
        public PaymentRequestRequest PaymentRequest { get; set; } = new PaymentRequestRequest();
        public List<PaymentRequestDetailRequest> PaymentRequestDetails { get; set; } = new List<PaymentRequestDetailRequest>();

    }
}