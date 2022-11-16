namespace SplitiT.Services.EfficientDataStructure
{
    public class EfficientDataStructureService : IEfficientDataStructureService
    {
        Dictionary<string, List<string>> _efficientDataStructure;

        public EfficientDataStructureService()
        {
            _efficientDataStructure = new Dictionary<string, List<string>>();   
        }

        public bool AddPurchaseToDictionary(string monthYear, string id)
        {

            if (_efficientDataStructure.ContainsKey(monthYear) && _efficientDataStructure[monthYear].Contains(id))
            {
                Console.WriteLine($"Failed to add Purchase {id} - Already existing...");
                return false;
            }

            if(_efficientDataStructure.ContainsKey(monthYear))
            {
                _efficientDataStructure[monthYear].Add(id);
            }
            else
            {
                _efficientDataStructure[monthYear] = new List<string>() { id };
            }

            return true;
        }

        public IList<string> GetPurchasesByMonthAndYear(string monthYear)
        {
            if (_efficientDataStructure.ContainsKey(monthYear))
            {
                return _efficientDataStructure[monthYear];
            }
            return new List<string>();
        }

    }
}
