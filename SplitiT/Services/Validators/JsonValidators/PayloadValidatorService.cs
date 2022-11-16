using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace SplitiT.Services.JsonValidators
{
    public class PayloadValidatorService : ValidatorsBase, IPayloadValidatorService
    {
        public PayloadValidatorService()
        {
            Schema1 = JSchema.Parse(File.ReadAllText("JsonSchemas/Source1Schema.json"));
            Schema2 = JSchema.Parse(File.ReadAllText("JsonSchemas/Source2Schema.json"));
            Schema3 = JSchema.Parse(File.ReadAllText("JsonSchemas/Source3Schema.json"));
        }

        private static void HandleInvalidJsonError(IList<string> errors)
        {
            throw new Exception("JsonNotValid");
        }

        public bool Validate(JObject jObject, string source)
        {
            IList<string> errors = new List<string>();

            switch (source)
            {
                case "S1":
                    if (jObject.IsValid(Schema1, out errors)) return true;
                    break;

                case "S2":
                    if (jObject.IsValid(Schema2, out errors)) return true;
                    break;

                case "S3":
                    if (jObject.IsValid(Schema3, out errors)) return true;
                    break;

                default:
                    break;
            }
            HandleInvalidJsonError(errors); 
            return false;
        }
    }
}
