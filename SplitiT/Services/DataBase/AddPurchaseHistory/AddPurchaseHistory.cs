using SplitiT.Contracts;
using SplitiT.Models.Sources;
using SplitiT.Services.EfficientDataStructure;

namespace SplitiT.Services.DataBase.AddPurchaseHistory
{
    public class AddPurchaseHistory : IAddPurchaseHistory
    {

        private readonly IResponseGenerator _responseGenerator;
        private readonly ILogger<AddPurchaseHistory> _logger;
        private readonly IEfficientDataStructureService _efficientDataStructureService;
        private int _counter;

        public AddPurchaseHistory(IResponseGenerator responseGenerator, ILogger<AddPurchaseHistory> logger, IEfficientDataStructureService efficientDataStructureService)
        {
            _responseGenerator = responseGenerator;
            _logger = logger;
            _efficientDataStructureService = efficientDataStructureService;
        }
        public AddPurchaseHistoryResponse AddEntirePurchaseHistoryArray(IList<PurchaseHistory> purchaseHistory)
        {
            _counter = 0;
            foreach (var purchase in purchaseHistory)
            {
                if (ValidatePurchase(purchase) && AddSinglePurchaseToDictionary(purchase))
                {
                    _counter += 1;
                }
            }
            return _responseGenerator.GetAddPurchaseHistoryResponse(status:200, msg:"", total:purchaseHistory.Count, succuess:_counter);
        }
        private bool AddSinglePurchaseToDictionary(PurchaseHistory purchase)
        {
            string monthYear = purchase.Month + "-" + purchase.Year.ToString();
            return _efficientDataStructureService.AddPurchaseToDictionary(monthYear, purchase.Id);
        }
        private static bool ValidatePurchase(PurchaseHistory purchase)
        {
            return (purchase != null && (!string.IsNullOrEmpty(purchase.Id)) && (!string.IsNullOrEmpty(purchase.Month)) && (!string.IsNullOrEmpty(purchase.Year.ToString())));
        }
    }
}
