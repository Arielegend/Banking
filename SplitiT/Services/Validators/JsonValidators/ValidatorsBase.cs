using Newtonsoft.Json.Schema;

namespace SplitiT.Services.JsonValidators
{
    public abstract class ValidatorsBase
    {
        public JSchema Schema1 { get; set; }
        public JSchema Schema2 { get; set; }
        public JSchema Schema3 { get; set; }
    }
}