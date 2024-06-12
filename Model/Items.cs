namespace AuthorizationAPI.Model
{
    public class Items
    {
            public int Id { get; set; }
            public string ItemName { get; set; }
            public string? UnitPrice { get; set; }
            public string? Quantity { get; set; }
            public string? Description { get; set; }
            public string? TotalPrice { get; set; }
            public DateTime? InsertedAt { get; set; }
        }
    }

