namespace MiniECommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }

        //Navigation properties
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}