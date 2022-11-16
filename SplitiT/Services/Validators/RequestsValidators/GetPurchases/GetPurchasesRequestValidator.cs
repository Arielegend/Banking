using SplitiT.Contracts;
using SplitiT.Models;

namespace SplitiT.Services.Validators.RequestsValidators
{
    public class GetPurchasesRequestValidator : RequestValidatorBase<GetPurchasesByMonthAndYearRequest>, IGetPurchasesRequestValidator
    {
        public bool ValidateRequest(GetPurchasesByMonthAndYearRequest req)
        {
            if (req.Month is null)
            {
                throw new Exception("InvalidParamsForGetPurchases-Month");
            }
            ValidateYear(req.Year);
            ValidateMonth(req.Month);

            return true;
        }
        private static void ValidateYear(int year)
        {
            if (0 >=  year)
            {
                throw new Exception("InvalidParamsForGetPurchases-Year");
            }
        }
        private static void ValidateMonth(string month)
        {
            bool success = Enum.IsDefined(typeof(MonthsEnum), month.ToUpper());

            if (!success)
            {
                throw new Exception("InvalidParamsForGetPurchases-Month");
            }
        }
    }
}



