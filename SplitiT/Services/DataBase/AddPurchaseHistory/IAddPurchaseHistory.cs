using SplitiT.Contracts;
using SplitiT.Models.Sources;

namespace SplitiT.Services.DataBase.AddPurchaseHistory
{
    public interface IAddPurchaseHistory
    {
        AddPurchaseHistoryResponse AddEntirePurchaseHistoryArray(IList<PurchaseHistory> purchaseHistory);
    }
}