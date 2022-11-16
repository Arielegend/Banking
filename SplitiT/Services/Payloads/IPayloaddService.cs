using SplitiT.Models.Sources;

namespace SplitiT.Services.Payloads
{
    public interface IPayloadService
    {
        string GetTransactionId();
        IList<PurchaseHistory> GetPurchaseHistory();
        void InitPayload(string payload);
    }
}
