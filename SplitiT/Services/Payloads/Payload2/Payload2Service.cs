using SplitiT.Models.Sources;

namespace SplitiT.Services.Payloads
{
    public class Payload2Service : PayloadServiceBase<Payload2>, IPayload2Service
    {
        public string GetTransactionId()
        {
            return Payload.notificationItems.NotificationRequestItem.TransactionId;
        }
        public IList<PurchaseHistory> GetPurchaseHistory()
        {
            return Payload.notificationItems.NotificationRequestItem.PurchaseHistory;
        }
    }
}
