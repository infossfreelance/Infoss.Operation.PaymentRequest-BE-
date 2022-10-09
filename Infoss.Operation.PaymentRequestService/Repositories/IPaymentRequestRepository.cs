using Infoss.Operation.PaymentRequestService.Helper;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public interface IPaymentRequestRepository
    {
        public Task<ResponsePages<PaymentRequestResponse>> Read(PaymentRequestRead paymentRequestRead);
        public Task<ResponsePage<PaymentRequestMultipleResponse>> Read(RequestId requestId);
        public Task<ResponsePage<PaymentRequestResponse>> Create(PaymentRequestMultipleRequest paymentRequest);
        public Task<ResponsePage<PaymentRequestResponse>> Update(PaymentRequestMultipleRequest paymentRequest);
        public Task<ResponsePage<PaymentRequestResponse>> Delete(RequestId requestId);
        public Task<ResponsePage<PaymentRequestResponse>> Approval(PaymentRequestApproval paymentRequest);
    }
}
