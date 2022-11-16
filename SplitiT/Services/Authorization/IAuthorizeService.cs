using SplitiT.Contracts;

namespace SplitiT.Services
{
    public interface IAuthorizeService
    {
        Task AuthorizeTransactionId(string transactionId); 
    }
}