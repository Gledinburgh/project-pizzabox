using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  class OrderSingleton
  {
    private static OrderSingleton _instance;
    public static Order Order { get; private set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }
        return _instance;
      }
    }

    private OrderSingleton()
    {
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
