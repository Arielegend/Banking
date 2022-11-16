namespace SplitiT.Services.Validators.RequestsValidators.GetPurchases
{
    public interface IRequestsValidator<T>
    {
        bool ValidateRequest(T req);
    }
}