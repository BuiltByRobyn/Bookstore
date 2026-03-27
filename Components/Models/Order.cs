namespace bookstore.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }

    public decimal GetTotal() => OrderItems.Sum(item => item.GetTotal());
}