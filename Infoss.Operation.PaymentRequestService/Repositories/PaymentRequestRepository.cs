
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.PaymentRequestService.Helper;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private string connectionString = string.Empty;

        public PaymentRequestRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlConnection");
        }

        //public async Task<ResponsePages<PaymentRequestResponse>> Read(RequestPage requestPage)
        //{
        //    var responsePage = new ResponsePages<PaymentRequestResponse>();

        //    try
        //    {
        //        var parameters = new DynamicParameters();

        //        parameters.Add("@RowStatus", requestPage.RowStatus);
        //        parameters.Add("@CountryId", requestPage.UserLogin.CountryId);
        //        parameters.Add("@CompanyId", requestPage.UserLogin.CompanyId);
        //        parameters.Add("@BranchId", requestPage.UserLogin.BranchId);
        //        parameters.Add("@User", requestPage.UserLogin.UserCode);
        //        parameters.Add("@Id", 0);
        //        parameters.Add("@PageNo", requestPage.PageNumber);
        //        parameters.Add("@PageSize", requestPage.PageSize);
        //        parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        parameters.Add("@Text", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
        //        parameters.Add("@Column", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
        //        parameters.Add("@Format", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);

        //        using (var connection = new SqlConnection(connectionString))
        //        {
        //            using (var multi = (await connection.QueryMultipleAsync("operation.SP_PaymentRequest_Read_Test", parameters, commandType: CommandType.StoredProcedure)))
        //            {
        //                responsePage.Data = (await multi.ReadAsync<PaymentRequestResponse>()).ToList();

        //                responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
        //                responsePage.TotalPage = parameters.Get<int>("@PageCount");
        //                responsePage.Text = parameters.Get<string>("@Text");
        //                responsePage.Column = parameters.Get<string>("@Column");
        //                responsePage.Format = parameters.Get<string>("@Format");

        //                if (responsePage.Data != null)
        //                {
        //                    responsePage.Code = 200;
        //                    responsePage.Message = "Successfully read";
        //                }
        //                else
        //                {
        //                    responsePage.Code = 204;
        //                    responsePage.Message = "No content";
        //                }

        //                return responsePage;
        //            }
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        responsePage.Code = 500;
        //        responsePage.Error = ex.Message;
        //        responsePage.Message = "Failed to read";

        //        return responsePage;
        //    }
        //}

        public async Task<ResponsePages<PaymentRequestResponse>> Read(PaymentRequestRead paymentRequestRead)
        {
            var responsePage = new ResponsePages<PaymentRequestResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", paymentRequestRead.RowStatus);
                parameters.Add("@CountryId", paymentRequestRead.CountryId);
                parameters.Add("@CompanyId", paymentRequestRead.CompanyId);
                parameters.Add("@BranchId", paymentRequestRead.BranchId);
                parameters.Add("@User", paymentRequestRead.UserCode);
                parameters.Add("@Id", 0);
                parameters.Add("@PageNo", paymentRequestRead.PageNumber);
                parameters.Add("@PageSize", paymentRequestRead.PageSize);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Text", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
                parameters.Add("@Column", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
                parameters.Add("@Format", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_PaymentRequest_Read_Test", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        responsePage.Data = (await multi.ReadAsync<PaymentRequestResponse>()).ToList();

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");
                        responsePage.Text = parameters.Get<string>("@Text");
                        responsePage.Column = parameters.Get<string>("@Column");
                        responsePage.Format = parameters.Get<string>("@Format");

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }

            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestMultipleResponse>> Read(RequestId requestId)
        {
            var responsePage = new ResponsePage<PaymentRequestMultipleResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@User", requestId.UserLogin.UserCode);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@PageNo", 0);
                parameters.Add("@PageSize", 0);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Text", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
                parameters.Add("@Column", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);
                parameters.Add("@Format", dbType: DbType.AnsiStringFixedLength, direction: ParameterDirection.Output, size: int.MaxValue);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_PaymentRequest_Read", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        PaymentRequestMultipleResponse paymentRequestMultipleResponse = new PaymentRequestMultipleResponse();

                        paymentRequestMultipleResponse.PaymentRequest = (await multi.ReadAsync<PaymentRequestResponse>()).First();
                        paymentRequestMultipleResponse.PaymentRequestDetails = (await multi.ReadAsync<PaymentRequestDetailResponse>()).ToList();

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");
                        responsePage.Text = parameters.Get<string>("@Text");
                        responsePage.Column = parameters.Get<string>("@Column");
                        responsePage.Format = parameters.Get<string>("@Format");

                        responsePage.Data = paymentRequestMultipleResponse;

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestResponse>> Create(PaymentRequestMultipleRequest paymentRequest)
        {
            var responsePage = new ResponsePage<PaymentRequestResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", paymentRequest.PaymentRequest.RowStatus == "" ? "ACT" : paymentRequest.PaymentRequest.RowStatus);
                parameters.Add("@CountryId", paymentRequest.PaymentRequest.CountryId);
                parameters.Add("@CompanyId", paymentRequest.PaymentRequest.CompanyId);
                parameters.Add("@BranchId", paymentRequest.PaymentRequest.BranchId);
                parameters.Add("@Id", paymentRequest.PaymentRequest.Id);
                parameters.Add("@TicketId", paymentRequest.PaymentRequest.TicketId);
                parameters.Add("@PRNo", paymentRequest.PaymentRequest.PRNo);
                parameters.Add("@DebetCredit", paymentRequest.PaymentRequest.DebetCredit);
                parameters.Add("@ShipmentId", paymentRequest.PaymentRequest.ShipmentId);
                parameters.Add("@Reference", paymentRequest.PaymentRequest.Reference);
                parameters.Add("@PRStatus", paymentRequest.PaymentRequest.PRStatus);
                parameters.Add("@IsGeneralPR", paymentRequest.PaymentRequest.IsGeneralPR);
                parameters.Add("@CustomerId", paymentRequest.PaymentRequest.CustomerId);
                parameters.Add("@CustomerTypeId", paymentRequest.PaymentRequest.CustomerTypeId);
                parameters.Add("@PersonalId", paymentRequest.PaymentRequest.PersonalId);
                parameters.Add("@PaymentUSD", paymentRequest.PaymentRequest.PaymentUSD);
                parameters.Add("@PaymentIDR", paymentRequest.PaymentRequest.PaymentIDR);
                parameters.Add("@PRContraStatus", paymentRequest.PaymentRequest.PRContraStatus);
                parameters.Add("@PRContraNo", paymentRequest.PaymentRequest.PRContraNo);
                parameters.Add("@PaidUSD", paymentRequest.PaymentRequest.PaidUSD);
                parameters.Add("@DatePaidUSD", paymentRequest.PaymentRequest.DatePaidUSD);
                parameters.Add("@PaidIDR", paymentRequest.PaymentRequest.PaidIDR);
                parameters.Add("@DatePaidIDR", paymentRequest.PaymentRequest.DatePaidIDR);
                parameters.Add("@Deleted", paymentRequest.PaymentRequest.Deleted);
                parameters.Add("@DeletedOn", paymentRequest.PaymentRequest.DeletedOn);
                parameters.Add("@ApproveOpr", paymentRequest.PaymentRequest.ApproveOpr);
                parameters.Add("@ApproveOprOn", paymentRequest.PaymentRequest.ApproveOprOn);
                parameters.Add("@ApproveAcc", paymentRequest.PaymentRequest.ApproveAcc);
                parameters.Add("@ApproveAccOn", paymentRequest.PaymentRequest.ApproveAccOn);
                parameters.Add("@Rate", paymentRequest.PaymentRequest.Rate);
                parameters.Add("@ExRateDate", paymentRequest.PaymentRequest.ExRateDate);
                parameters.Add("@Printing", paymentRequest.PaymentRequest.Printing);
                parameters.Add("@PrintedOn", paymentRequest.PaymentRequest.PrintedOn);
                parameters.Add("@PRNo2", paymentRequest.PaymentRequest.PRNo2);
                parameters.Add("@ExRateId", paymentRequest.PaymentRequest.ExRateId);
                parameters.Add("@DeletedRemarks", paymentRequest.PaymentRequest.DeletedRemarks);
                parameters.Add("@IdLama", paymentRequest.PaymentRequest.IdLama);
                parameters.Add("@IsCostToCost", paymentRequest.PaymentRequest.IsCostToCost);
                parameters.Add("@TotalPpnUSD", paymentRequest.PaymentRequest.TotalPpnUSD);
                parameters.Add("@TotalPpnIDR", paymentRequest.PaymentRequest.TotalPpnIDR);
                parameters.Add("@UniqueKeyPR", paymentRequest.PaymentRequest.UniqueKeyPR);
                parameters.Add("@PackingListNo", paymentRequest.PaymentRequest.PackingListNo);
                parameters.Add("@SICustomerNo", paymentRequest.PaymentRequest.SICustomerNo);
                parameters.Add("@VendorDN", paymentRequest.PaymentRequest.VendorDN);
                parameters.Add("@Approved", paymentRequest.PaymentRequest.Approved);
                parameters.Add("@ApprovedOn", paymentRequest.PaymentRequest.ApprovedOn);
                parameters.Add("@ApprovedBy", paymentRequest.PaymentRequest.ApprovedBy);
                parameters.Add("@ApprovedRemarks", paymentRequest.PaymentRequest.ApprovedRemarks);
                parameters.Add("@ApprovedMarketing", paymentRequest.PaymentRequest.ApprovedMarketing);
                parameters.Add("@ApprovedMarketingOn", paymentRequest.PaymentRequest.ApprovedMarketingOn);
                parameters.Add("@ApprovedMarketingBy", paymentRequest.PaymentRequest.ApprovedMarketingBy);
                parameters.Add("@CreatedBy", paymentRequest.PaymentRequest.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                using (var connection = new SqlConnection(connectionString))
                {
                    //using (var transaction = connection.BeginTransaction())
                    //{
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Create", parameters, commandType: CommandType.StoredProcedure);

                    int id = parameters.Get<int>("@RETURNVALUE");

                    //
                    // PaymentRequestDetail
                    //
                    for (int i = 0; i < paymentRequest.PaymentRequestDetails.Count; i++)
                    {
                        var parameterDetails = new DynamicParameters();

                        parameterDetails.Add("@RowStatus", paymentRequest.PaymentRequestDetails[i].RowStatus == "" ? "ACT" : paymentRequest.PaymentRequestDetails[i].RowStatus);
                        parameterDetails.Add("@CountryId", paymentRequest.PaymentRequest.CountryId);
                        parameterDetails.Add("@CompanyId", paymentRequest.PaymentRequest.CompanyId);
                        parameterDetails.Add("@BranchId", paymentRequest.PaymentRequest.BranchId);
                        parameterDetails.Add("@PaymentRequestId", id);
                        parameterDetails.Add("@Sequence", i+1);
                        parameterDetails.Add("@DebetCredit", paymentRequest.PaymentRequestDetails[i].DebetCredit);
                        parameterDetails.Add("@AccountId", paymentRequest.PaymentRequestDetails[i].AccountId);
                        parameterDetails.Add("@Description", paymentRequest.PaymentRequestDetails[i].Description);
                        parameterDetails.Add("@Type", paymentRequest.PaymentRequestDetails[i].Type);
                        parameterDetails.Add("@CodingQuantity", paymentRequest.PaymentRequestDetails[i].CodingQuantity);
                        parameterDetails.Add("@Quantity", paymentRequest.PaymentRequestDetails[i].Quantity);
                        parameterDetails.Add("@PerQty", paymentRequest.PaymentRequestDetails[i].PerQty);
                        parameterDetails.Add("@Amount", paymentRequest.PaymentRequestDetails[i].Amount);
                        parameterDetails.Add("@AmountCrr", paymentRequest.PaymentRequestDetails[i].AmountCrr);
                        parameterDetails.Add("@Paid", paymentRequest.PaymentRequestDetails[i].Paid);
                        parameterDetails.Add("@PaidOn", paymentRequest.PaymentRequestDetails[i].PaidOn);
                        parameterDetails.Add("@PaidPV", paymentRequest.PaymentRequestDetails[i].PaidPV);
                        parameterDetails.Add("@EPLDetailId", paymentRequest.PaymentRequestDetails[i].EPLDetailId);
                        parameterDetails.Add("@StatusMemo", paymentRequest.PaymentRequestDetails[i].StatusMemo);
                        parameterDetails.Add("@MemoNo", paymentRequest.PaymentRequestDetails[i].MemoNo);
                        parameterDetails.Add("@IdLama", paymentRequest.PaymentRequestDetails[i].IdLama);
                        parameterDetails.Add("@IsCostToCost", paymentRequest.PaymentRequestDetails[i].IsCostToCost);
                        parameterDetails.Add("@IsPpn", paymentRequest.PaymentRequestDetails[i].IsPpn);
                        parameterDetails.Add("@PersenPpn", paymentRequest.PaymentRequestDetails[i].PersenPpn);
                        parameterDetails.Add("@FakturNo", paymentRequest.PaymentRequestDetails[i].FakturNo);
                        parameterDetails.Add("@FakturDate", paymentRequest.PaymentRequestDetails[i].FakturDate);
                        parameterDetails.Add("@IsCostTrucking", paymentRequest.PaymentRequestDetails[i].IsCostTrucking);
                        parameterDetails.Add("@KendaraanId", paymentRequest.PaymentRequestDetails[i].KendaraanId);
                        parameterDetails.Add("@KendaraanNopol", paymentRequest.PaymentRequestDetails[i].KendaraanNopol);
                        parameterDetails.Add("@EmployeeId", paymentRequest.PaymentRequestDetails[i].EmployeeId);
                        parameterDetails.Add("@EmployeeName", paymentRequest.PaymentRequestDetails[i].EmployeeName);
                        parameterDetails.Add("@MrgId", paymentRequest.PaymentRequestDetails[i].MrgId);
                        parameterDetails.Add("@DeliveryDate", paymentRequest.PaymentRequestDetails[i].DeliveryDate);
                        parameterDetails.Add("@OriginalUsd", paymentRequest.PaymentRequestDetails[i].OriginalUsd);
                        parameterDetails.Add("@OriginalRate", paymentRequest.PaymentRequestDetails[i].OriginalRate);
                        parameterDetails.Add("@CreatedBy", paymentRequest.PaymentRequestDetails[i].User);

                        var affectedDetailRows = await connection.ExecuteAsync("operation.SP_PaymentRequestDetail_Create", parameterDetails, commandType: CommandType.StoredProcedure);
                    }

                    //transaction.Commit();
                    //}

                    responsePage.Code = 200;
                    responsePage.Message = "Data created";

                    return responsePage;

                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to create";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestResponse>> Update(PaymentRequestMultipleRequest paymentRequest)
        {
            var responsePage = new ResponsePage<PaymentRequestResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", paymentRequest.PaymentRequest.RowStatus == "" ? "ACT" : paymentRequest.PaymentRequest.RowStatus);
                parameters.Add("@CountryId", paymentRequest.PaymentRequest.CountryId);
                parameters.Add("@CompanyId", paymentRequest.PaymentRequest.CompanyId);
                parameters.Add("@BranchId", paymentRequest.PaymentRequest.BranchId);
                parameters.Add("@Id", paymentRequest.PaymentRequest.Id);
                parameters.Add("@TicketId", paymentRequest.PaymentRequest.TicketId);
                parameters.Add("@PRNo", paymentRequest.PaymentRequest.PRNo);
                parameters.Add("@DebetCredit", paymentRequest.PaymentRequest.DebetCredit);
                parameters.Add("@ShipmentId", paymentRequest.PaymentRequest.ShipmentId);
                parameters.Add("@Reference", paymentRequest.PaymentRequest.Reference);
                parameters.Add("@PRStatus", paymentRequest.PaymentRequest.PRStatus);
                parameters.Add("@IsGeneralPR", paymentRequest.PaymentRequest.IsGeneralPR);
                parameters.Add("@CustomerId", paymentRequest.PaymentRequest.CustomerId);
                parameters.Add("@CustomerTypeId", paymentRequest.PaymentRequest.CustomerTypeId);
                parameters.Add("@PersonalId", paymentRequest.PaymentRequest.PersonalId);
                parameters.Add("@PaymentUSD", paymentRequest.PaymentRequest.PaymentUSD);
                parameters.Add("@PaymentIDR", paymentRequest.PaymentRequest.PaymentIDR);
                parameters.Add("@PRContraStatus", paymentRequest.PaymentRequest.PRContraStatus);
                parameters.Add("@PRContraNo", paymentRequest.PaymentRequest.PRContraNo);
                parameters.Add("@PaidUSD", paymentRequest.PaymentRequest.PaidUSD);
                parameters.Add("@DatePaidUSD", paymentRequest.PaymentRequest.DatePaidUSD);
                parameters.Add("@PaidIDR", paymentRequest.PaymentRequest.PaidIDR);
                parameters.Add("@DatePaidIDR", paymentRequest.PaymentRequest.DatePaidIDR);
                parameters.Add("@Deleted", paymentRequest.PaymentRequest.Deleted);
                parameters.Add("@DeletedOn", paymentRequest.PaymentRequest.DeletedOn);
                parameters.Add("@ApproveOpr", paymentRequest.PaymentRequest.ApproveOpr);
                parameters.Add("@ApproveOprOn", paymentRequest.PaymentRequest.ApproveOprOn);
                parameters.Add("@ApproveAcc", paymentRequest.PaymentRequest.ApproveAcc);
                parameters.Add("@ApproveAccOn", paymentRequest.PaymentRequest.ApproveAccOn);
                parameters.Add("@Rate", paymentRequest.PaymentRequest.Rate);
                parameters.Add("@ExRateDate", paymentRequest.PaymentRequest.ExRateDate);
                parameters.Add("@Printing", paymentRequest.PaymentRequest.Printing);
                parameters.Add("@PrintedOn", paymentRequest.PaymentRequest.PrintedOn);
                parameters.Add("@PRNo2", paymentRequest.PaymentRequest.PRNo2);
                parameters.Add("@ExRateId", paymentRequest.PaymentRequest.ExRateId);
                parameters.Add("@DeletedRemarks", paymentRequest.PaymentRequest.DeletedRemarks);
                parameters.Add("@IdLama", paymentRequest.PaymentRequest.IdLama);
                parameters.Add("@IsCostToCost", paymentRequest.PaymentRequest.IsCostToCost);
                parameters.Add("@TotalPpnUSD", paymentRequest.PaymentRequest.TotalPpnUSD);
                parameters.Add("@TotalPpnIDR", paymentRequest.PaymentRequest.TotalPpnIDR);
                parameters.Add("@UniqueKeyPR", paymentRequest.PaymentRequest.UniqueKeyPR);
                parameters.Add("@PackingListNo", paymentRequest.PaymentRequest.PackingListNo);
                parameters.Add("@SICustomerNo", paymentRequest.PaymentRequest.SICustomerNo);
                parameters.Add("@VendorDN", paymentRequest.PaymentRequest.VendorDN);
                parameters.Add("@Approved", paymentRequest.PaymentRequest.Approved);
                parameters.Add("@ApprovedOn", paymentRequest.PaymentRequest.ApprovedOn);
                parameters.Add("@ApprovedBy", paymentRequest.PaymentRequest.ApprovedBy);
                parameters.Add("@ApprovedRemarks", paymentRequest.PaymentRequest.ApprovedRemarks);
                parameters.Add("@ApprovedMarketing", paymentRequest.PaymentRequest.ApprovedMarketing);
                parameters.Add("@ApprovedMarketingOn", paymentRequest.PaymentRequest.ApprovedMarketingOn);
                parameters.Add("@ApprovedMarketingBy", paymentRequest.PaymentRequest.ApprovedMarketingBy);
                parameters.Add("@ModifiedBy", paymentRequest.PaymentRequest.User);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Update", parameters, commandType: CommandType.StoredProcedure);


                    //
                    // PaymentRequestDetail
                    //
                    for (int i = 0; i < paymentRequest.PaymentRequestDetails.Count; i++)
                    {
                        var parameterDetails = new DynamicParameters();

                        parameterDetails.Add("@RowStatus", paymentRequest.PaymentRequestDetails[i].RowStatus == "" ? "ACT" : paymentRequest.PaymentRequestDetails[i].RowStatus);
                        parameterDetails.Add("@CountryId", paymentRequest.PaymentRequest.CountryId);
                        parameterDetails.Add("@CompanyId", paymentRequest.PaymentRequest.CompanyId);
                        parameterDetails.Add("@BranchId", paymentRequest.PaymentRequest.BranchId);
                        parameterDetails.Add("@PaymentRequestId", paymentRequest.PaymentRequest.Id);
                        parameterDetails.Add("@Sequence", i+1);
                        parameterDetails.Add("@DebetCredit", paymentRequest.PaymentRequestDetails[i].DebetCredit);
                        parameterDetails.Add("@AccountId", paymentRequest.PaymentRequestDetails[i].AccountId);
                        parameterDetails.Add("@Description", paymentRequest.PaymentRequestDetails[i].Description);
                        parameterDetails.Add("@Type", paymentRequest.PaymentRequestDetails[i].Type);
                        parameterDetails.Add("@CodingQuantity", paymentRequest.PaymentRequestDetails[i].CodingQuantity);
                        parameterDetails.Add("@Quantity", paymentRequest.PaymentRequestDetails[i].Quantity);
                        parameterDetails.Add("@PerQty", paymentRequest.PaymentRequestDetails[i].PerQty);
                        parameterDetails.Add("@Amount", paymentRequest.PaymentRequestDetails[i].Amount);
                        parameterDetails.Add("@AmountCrr", paymentRequest.PaymentRequestDetails[i].AmountCrr);
                        parameterDetails.Add("@Paid", paymentRequest.PaymentRequestDetails[i].Paid);
                        parameterDetails.Add("@PaidOn", paymentRequest.PaymentRequestDetails[i].PaidOn);
                        parameterDetails.Add("@PaidPV", paymentRequest.PaymentRequestDetails[i].PaidPV);
                        parameterDetails.Add("@EPLDetailId", paymentRequest.PaymentRequestDetails[i].EPLDetailId);
                        parameterDetails.Add("@StatusMemo", paymentRequest.PaymentRequestDetails[i].StatusMemo);
                        parameterDetails.Add("@MemoNo", paymentRequest.PaymentRequestDetails[i].MemoNo);
                        parameterDetails.Add("@IdLama", paymentRequest.PaymentRequestDetails[i].IdLama);
                        parameterDetails.Add("@IsCostToCost", paymentRequest.PaymentRequestDetails[i].IsCostToCost);
                        parameterDetails.Add("@IsPpn", paymentRequest.PaymentRequestDetails[i].IsPpn);
                        parameterDetails.Add("@PersenPpn", paymentRequest.PaymentRequestDetails[i].PersenPpn);
                        parameterDetails.Add("@FakturNo", paymentRequest.PaymentRequestDetails[i].FakturNo);
                        parameterDetails.Add("@FakturDate", paymentRequest.PaymentRequestDetails[i].FakturDate);
                        parameterDetails.Add("@IsCostTrucking", paymentRequest.PaymentRequestDetails[i].IsCostTrucking);
                        parameterDetails.Add("@KendaraanId", paymentRequest.PaymentRequestDetails[i].KendaraanId);
                        parameterDetails.Add("@KendaraanNopol", paymentRequest.PaymentRequestDetails[i].KendaraanNopol);
                        parameterDetails.Add("@EmployeeId", paymentRequest.PaymentRequestDetails[i].EmployeeId);
                        parameterDetails.Add("@EmployeeName", paymentRequest.PaymentRequestDetails[i].EmployeeName);
                        parameterDetails.Add("@MrgId", paymentRequest.PaymentRequestDetails[i].MrgId);
                        parameterDetails.Add("@DeliveryDate", paymentRequest.PaymentRequestDetails[i].DeliveryDate);
                        parameterDetails.Add("@OriginalUsd", paymentRequest.PaymentRequestDetails[i].OriginalUsd);
                        parameterDetails.Add("@OriginalRate", paymentRequest.PaymentRequestDetails[i].OriginalRate);
                        parameterDetails.Add("@ModifiedBy", paymentRequest.PaymentRequestDetails[i].User);

                        var affectedDetailRows = await connection.ExecuteAsync("operation.SP_PaymentRequestDetail_Update", parameterDetails, commandType: CommandType.StoredProcedure);
                    }


                    //transaction.Commit();
                    //}

                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<PaymentRequestResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var parameterDetails = new DynamicParameters();
                parameterDetails.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameterDetails.Add("@CountryId", requestId.UserLogin.CountryId);
                parameterDetails.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameterDetails.Add("@BranchId", requestId.UserLogin.BranchId);
                parameterDetails.Add("@Id", requestId.Id);
                parameterDetails.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Delete", parameters, commandType: CommandType.StoredProcedure);

                    //
                    //Detail
                    //
                    var affectedDetailRows = await connection.ExecuteAsync("operation.SP_PaymentRequestDetail_Delete", parameterDetails, commandType: CommandType.StoredProcedure);

                    responsePage.Code = 200;
                    responsePage.Message = "Data deleted";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to delete";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestResponse>> Approval(PaymentRequestApproval paymentRequest)
        {
            var responsePage = new ResponsePage<PaymentRequestResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@Id", paymentRequest.Id);
                parameters.Add("@Flag", paymentRequest.Flag);
                
                using (var connection = new SqlConnection(connectionString))
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Approve", parameters, commandType: CommandType.StoredProcedure);

                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }

    }
}
