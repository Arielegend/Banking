using SplitiT.Contracts;
using SplitiT.Services.Validators.RequestsValidators.GetPurchases;

namespace SplitiT.Services.Validators
{
    public interface IGetPurchasesRequestValidator : IRequestsValidator<GetPurchasesByMonthAndYearRequest>
    {
    }
}