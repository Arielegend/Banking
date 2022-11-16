using SplitiT.Contracts;
using SplitiT.Models.Sources;

namespace SplitiT.Services.Validators.RequestsValidators
{
    public class AddPayloadRequestValidator : RequestValidatorBase<AddPayloadRequest>, IAddPayloadRequestValidator
    {
        public bool ValidateRequest(AddPayloadRequest req)
        {
            if ((string.IsNullOrEmpty(req.Payload)) || (string.IsNullOrEmpty(req.Source)))
            {
                throw new Exception("BadRequest_ParamsEmpty");
            }
            ValidateSource(req.Source.ToUpper());
            return true;
        }
        private static void ValidateSource(string source)
        {
            bool success = Enum.IsDefined(typeof(SourcesEnum), source);

            if (!success)
            {
                throw new Exception("UnknownSource");
            }
        }
    }
}
