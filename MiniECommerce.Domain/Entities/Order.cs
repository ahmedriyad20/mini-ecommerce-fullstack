namespace MiniECommerce.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public int TotalItems => OrderItems.Sum(x => x.Quantity);

        public decimal Subtotal => OrderItems.Sum(x => x.Quantity * x.UnitPrice);

        public decimal DiscountPercentage
        {
            get
            {
                if (TotalItems >= 5)
                {
                    return 10m;  // 10% off for 5+ items
                }
                else if (TotalItems >= 2)
                {
                    return 5m;   // 5% off for 2-4 items
                }
                else
                {
                    return 0m;   // No discount for 1 item
                }
            }
        }

        public decimal DiscountAmount => Subtotal * (DiscountPercentage / 100);

        public decimal Total => Subtotal - DiscountAmount;

        //Navigation properties
        public Customer? Customer { get; set; } = null!;
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
