using bookstore.Models;

namespace bookstore.Services;

public class OrderState
{
    public Order Order { get; set; } = new();

    public event Action OnChange;

    public OrderState()
    {
        Order.OrderItems = new List<OrderItem>();
    }

    public void AddItem(OrderItem item)
    {
        var existing = Order.OrderItems.FirstOrDefault(i => i.Book.Id == item.Book.Id);
        if (existing != null)
        {
            if (existing.Quantity < 5)
                existing.Quantity++;
        }
        else
        {
            Order.OrderItems.Add(item);
        }
        OnChange?.Invoke();
    }

    public void RemoveItem(OrderItem item)
    {
        Order.OrderItems.Remove(item);
        OnChange?.Invoke();
    }

    public void ResetOrder()
    {
        Order = new Order();
        OnChange?.Invoke();
    }

}