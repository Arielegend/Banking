using SplitiT.Models.Sources;

public class CustomerAddress
{
    public object city { get; set; }
    public string country { get; set; }
    public object line1 { get; set; }
    public object line2 { get; set; }
    public string postal_code { get; set; }
    public object state { get; set; }
}

public class Data
{
    public string TransactionId { get; set; }
    public string id { get; set; }
    public string @object { get; set; }
    public int amount { get; set; }
    public string currency { get; set; }
    public Period period { get; set; }
    public Plan plan { get; set; }
    public Price price { get; set; }
}

public class Lines
{
    public string @object { get; set; }
    public Data data { get; set; }
    public bool has_more { get; set; }
    public int total_count { get; set; }
    public string url { get; set; }
}

public class Metadata
{
}

public class MyObject
{
    public string id { get; set; }
    public string @object { get; set; }
    public string account_country { get; set; }
    public string account_name { get; set; }
    public object account_tax_ids { get; set; }
    public int amount_due { get; set; }
    public int amount_paid { get; set; }
    public int created { get; set; }
    public string currency { get; set; }
    public object custom_fields { get; set; }
    public string customer { get; set; }
    public CustomerAddress customer_address { get; set; }
    public string customer_email { get; set; }
    public string customer_name { get; set; }
    public string description { get; set; }
    public object discount { get; set; }
    public List<object> discounts { get; set; }
    public object due_date { get; set; }
    public Purchases Purchases { get; set; }
    public Lines lines { get; set; }
    public bool livemode { get; set; }
    public Metadata metadata { get; set; }
}

public class Period
{
    public int end { get; set; }
    public int start { get; set; }
}

public class Plan
{
    public string id { get; set; }
    public string @object { get; set; }
    public bool active { get; set; }
    public object aggregate_usage { get; set; }
    public int amount { get; set; }
    public string amount_decimal { get; set; }
    public string billing_scheme { get; set; }
    public int created { get; set; }
    public string currency { get; set; }
    public string interval { get; set; }
    public int interval_count { get; set; }
    public bool livemode { get; set; }
    public Metadata metadata { get; set; }
    public object nickname { get; set; }
    public string product { get; set; }
    public object tiers_mode { get; set; }
    public object transform_usage { get; set; }
    public object trial_period_days { get; set; }
    public string usage_type { get; set; }
}

public class Price
{
    public string id { get; set; }
    public string @object { get; set; }
    public bool active { get; set; }
    public string billing_scheme { get; set; }
    public int created { get; set; }
    public string currency { get; set; }
    public bool livemode { get; set; }
    public object lookup_key { get; set; }
    public Metadata metadata { get; set; }
    public object nickname { get; set; }
    public string product { get; set; }
    public Recurring recurring { get; set; }
    public string tax_behavior { get; set; }
    public object tiers_mode { get; set; }
    public object transform_quantity { get; set; }
    public string type { get; set; }
    public int unit_amount { get; set; }
    public string unit_amount_decimal { get; set; }
}


public class Purchases
{
    public List<PurchaseHistory> PurchaseHistory { get; set; }
}

public class Recurring
{
    public object aggregate_usage { get; set; }
    public string interval { get; set; }
    public int interval_count { get; set; }
    public object trial_period_days { get; set; }
    public string usage_type { get; set; }
}

public class Payload3
{
    public MyObject @object { get; set; }
}

