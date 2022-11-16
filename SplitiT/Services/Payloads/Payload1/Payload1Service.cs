using Newtonsoft.Json;
using SplitiT.Contracts;
using SplitiT.Models.Sources;

namespace SplitiT.Services.Payloads
{
    public class Payload1Service : PayloadServiceBase<Payload1>, IPayload1Service
    {
        public string GetTransactionId()
        {
            return Payload.TransactionId;
        }
        public IList<PurchaseHistory> GetPurchaseHistory()
        {
            return Payload.PurchaseHistory;
        }
    }
}
