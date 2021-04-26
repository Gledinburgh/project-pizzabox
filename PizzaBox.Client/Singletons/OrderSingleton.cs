using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  public class OrderSingleton
  {
    public static Order Order { get; private set; }
    public static Order CreateNewOrder()
    {
      Order = new Order();
      return Order;
    }
  }
}