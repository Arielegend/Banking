using Newtonsoft.Json;
using SplitiT.Models.Sources;

public class Payload1
{
    public string AVS { get; set; }
    public string address { get; set; }
    public double amount { get; set; }
    public string amountString { get; set; }
    public string TransactionId { get; set; }
    public double authAmount { get; set; }
    public string authAmountString { get; set; }
    public string authCurrency { get; set; }
    public string authMode { get; set; }
    public string cardType { get; set; }
    public string cartId { get; set; }
    public string charenc { get; set; }
    public string compName { get; set; }
    public string country { get; set; }
    public string countryMatch { get; set; }
    public string countryString { get; set; }
    public string currency { get; set; }
    public string desc { get; set; }
    public string email { get; set; }
    public string fax { get; set; }
    public string futurePayId { get; set; }
    public string instId { get; set; }
    public string installation { get; set; }
    public string msgType { get; set; }
    public string name { get; set; }
    public string postcode { get; set; }
    public string rawAuthCode { get; set; }
    public List<PurchaseHistory> PurchaseHistory { get; set; }
    public string rawAuthMessage { get; set; }

    [JsonProperty("SP.charEnc")]
    public string SPcharEnc { get; set; }
    public string tel { get; set; }
    public string testMode { get; set; }
    public long transTime { get; set; }
}

