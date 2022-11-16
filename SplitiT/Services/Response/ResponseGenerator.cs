using SplitiT.Contracts;
using SplitiT.Contracts.Responses;

namespace SplitiT.Services
{
    public class ResponseGenerator : IResponseGenerator
    {
        public AddPayloadResponse GetAddPayloadResponse(int status, string msg)
        {
            return new AddPayloadResponse
            {
                Status = status,
                Message = msg
            };
        }
        public AddPayloadLogRecordResponse GetAddPayloadLogRecordResponse(int status, string msg)
        {
            return new AddPayloadLogRecordResponse
            {
                Status = status,
                Message = msg
            };
        }
        public AddPurchaseHistoryResponse GetAddPurchaseHistoryResponse(int status, string msg,int total, int succuess)
        {
            return new AddPurchaseHistoryResponse
            {
                Status = status,
                Message = msg,
                Total = total,
                Success = succuess
            };
        }

        public GetPurchasesByMonthAndYearResponse GetPurchasesByMonthAndYearResponse(int status, string msg)
        {
            return new GetPurchasesByMonthAndYearResponse
            {
                Status = status,
                Message = msg
            };
        }
    }
}
