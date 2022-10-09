using Infoss.Operation.PaymentRequestService.Helper;
using Infoss.Operation.PaymentRequestService.Repositories;
using Infoss.Reg.UserAccessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infoss.Operation.PaymentRequestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IPaymentRequestRepository paymentRequestRepository;
        public IConfigurationRoot Configuration { get; }

        public PaymentRequestController()
        {
            IConfiguration Configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").
                Build();

            paymentRequestRepository = new PaymentRequestRepository(Configuration);
        }
        
        //[Route("PostByPage")]
        //[HttpPost]
        //public async Task<ResponsePages<PaymentRequestResponse>> Post(int pageNumber, int pageSize, [FromBody] UserLogin userLogin)
        //{
        //    var route = Request.Path.Value;

        //    var requestPage = new RequestPage();
        //    requestPage.RowStatus = "ACT";
        //    requestPage.UserLogin = userLogin;
        //    requestPage.PageNumber = pageNumber;
        //    requestPage.PageSize = pageSize;

        //    var responsePage = await paymentRequestRepository.Read(requestPage);
        //    return responsePage;

        //}

        [Route("PostByPage")]
        [HttpPost]
        public async Task<ResponsePages<PaymentRequestResponse>> Post([FromBody] PaymentRequestRead prRead)
        {
            var route = Request.Path.Value;

            var responsePage = await paymentRequestRepository.Read(prRead);
            return responsePage;

        }

        [Route("PostById")]
        [HttpPost]
        public async Task<ResponsePage<PaymentRequestMultipleResponse>> Post(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await paymentRequestRepository.Read(requestId);
            return responsePage;

        }

        [Route("Create")]
        [HttpPost]
        public async Task<ResponsePage<PaymentRequestResponse>> Post([FromBody] PaymentRequestMultipleRequest paymentRequest)
        {
            return await paymentRequestRepository.Create(paymentRequest);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ResponsePage<PaymentRequestResponse>> Put([FromBody] PaymentRequestMultipleRequest paymentRequest)
        {
            return await paymentRequestRepository.Update(paymentRequest);
        }

        [Route("Delete")]
        [HttpPut]
        public async Task<ResponsePage<PaymentRequestResponse>> Delete(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await paymentRequestRepository.Delete(requestId);
            return responsePage;
        }

        [Route("Approval")]
        [HttpPut]
        public async Task<ResponsePage<PaymentRequestResponse>> Approve([FromBody] PaymentRequestApproval paymentRequest)
        {
            return await paymentRequestRepository.Approval(paymentRequest);
        }

    }
}
