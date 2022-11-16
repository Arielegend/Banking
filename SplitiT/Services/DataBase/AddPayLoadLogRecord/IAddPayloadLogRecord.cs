using SplitiT.Contracts;

namespace SplitiT.Services.DataBase
{
    public interface IAddPayloadLogRecord
    {
        Task<AddPayloadLogRecordResponse> InsertPayload(string payload);
    }
}