namespace ICT2InventoryManagementWebAPIConsumer.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Rate { get; set; }

        public int Category { get; set; } // Foreign Key ID

        public string? Description { get; set; }

        public Category CategoryNavigation { get; set; }
    }
}
