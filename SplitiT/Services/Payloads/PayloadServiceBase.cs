using Newtonsoft.Json;

namespace SplitiT.Services.Payloads
{
    public abstract class PayloadServiceBase<T>
    {
        public T Payload { get; set; }
        public void InitPayload(string payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            Payload = JsonConvert.DeserializeObject<T>(payload);
        }
    }
}
