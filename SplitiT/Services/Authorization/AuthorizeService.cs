using System.Net;

namespace SplitiT.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly string  _protocol = "https://";
        private readonly string _subdomain = "pgtl";
        private readonly string _domain = "splitit";
        private readonly string _topLevelDomain = ".com/";
        private readonly string _url;
        private static HttpClient _client;
        private string _fixedUrlHelper;


        public AuthorizeService()
        {
            _url = _protocol + _subdomain + "." + _domain + _topLevelDomain;
            _client = new HttpClient();
        }
        public async Task AuthorizeTransactionId(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new Exception("TransactionIdEmpty");
            }

            _fixedUrlHelper = _url + transactionId;
            var response = await _client.GetAsync(_fixedUrlHelper);

            //Mocking Status code 200
            response.StatusCode = HttpStatusCode.OK;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.Unauthorized:
                    throw new Exception("SplitItServer_Unauthorized");

                case HttpStatusCode.Forbidden:
                    throw new Exception("SplitItServer_Forbidden");

                case HttpStatusCode.BadRequest:
                    throw new Exception("SplitItServer_BadRequestAuthentication");

                case HttpStatusCode.NotFound:
                    throw new Exception("SplitItServer_NotFound");

                default:
                    throw new Exception("SplitItServer");
            }
        }
    }
}
