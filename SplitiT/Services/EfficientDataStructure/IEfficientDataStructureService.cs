namespace SplitiT.Services.EfficientDataStructure
{
    public interface IEfficientDataStructureService
    {
        bool AddPurchaseToDictionary(string monthYear, string id);
        IList<string> GetPurchasesByMonthAndYear(string monthYear);

    }
}