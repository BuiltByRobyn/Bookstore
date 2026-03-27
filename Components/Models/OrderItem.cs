namespace bookstore.Models;

public class OrderItem
{
    public Book Book { get; set; }
    public int Quantity { get; set; }

    public decimal GetTotal() => Book.Price * Quantity;
}