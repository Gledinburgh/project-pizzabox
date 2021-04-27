using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class OrderSingleton
  {
    public static Order Order { get; set; }
    private readonly PizzaBoxContext _context = ContextSingleton.Instance.Context;
    private static OrderSingleton _instance;
    public static OrderSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new OrderSingleton(context);
      }
      return _instance;
    }
    private OrderSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Order == null)
      {
        Order = new Order();
      }
    }
    public static Order CreateNewOrder()
    {
      Order = new Order();
      return Order;
    }
  }
}
