using Newtonsoft.Json.Linq;

namespace SplitiT.Services.JsonValidators
{
    public interface IPayloadValidatorService
    {
        bool Validate(JObject jObject, string source);
    }
}
