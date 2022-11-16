using SplitiT.Models.Sources;

public class Amount
{
    public string currency { get; set; }
    public int value { get; set; }
}

public class NotificationItems
{
    public NotificationRequestItem NotificationRequestItem { get; set; }
}

public class NotificationRequestItem
{
    public Amount amount { get; set; }
    public string eventCode { get; set; }
    public string TransactionId { get; set; }
    public List<PurchaseHistory> PurchaseHistory { get; set; }
    public DateTime eventDate { get; set; }
    public string merchantAccountCode { get; set; }
    public string merchantReference { get; set; }
    public string originalReference { get; set; }
    public string paymentMethod { get; set; }
    public string pspReference { get; set; }
    public string reason { get; set; }
    public string success { get; set; }
}


public class Payload2
{
    public string live { get; set; }
    public NotificationItems notificationItems { get; set; }
}

