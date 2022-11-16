using SplitiT.Models.Sources;

namespace SplitiT.Services.Payloads
{
    public class Payload3Service : PayloadServiceBase<Payload3>, IPayload3Service
    {
        public string GetTransactionId()
        {
            return Payload.@object.lines.data.TransactionId;
        }
        public IList<PurchaseHistory> GetPurchaseHistory()
        {
            return Payload.@object.Purchases.PurchaseHistory;
        }
    }
}
