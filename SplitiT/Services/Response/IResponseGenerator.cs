using SplitiT.Contracts;
using SplitiT.Contracts.Responses;

namespace SplitiT.Services
{
    public interface IResponseGenerator
    {
        AddPayloadResponse GetAddPayloadResponse(int status, string msg);
        AddPayloadLogRecordResponse GetAddPayloadLogRecordResponse(int status, string msg);
        AddPurchaseHistoryResponse GetAddPurchaseHistoryResponse(int status, string msg, int total, int succuess);
        GetPurchasesByMonthAndYearResponse GetPurchasesByMonthAndYearResponse(int status, string msg);
    }
}