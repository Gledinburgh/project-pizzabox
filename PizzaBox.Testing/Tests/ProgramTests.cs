using Xunit;
using PizzaBox.Client;
using PizzaBox.Storing;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Testing.Tests
{
  public class ProgramTests
  {
    public static Order order = OrderSingleton.CreateNewOrder();
    [Fact]
    public static void Add_Order_Test()
    {
      for (int i = 0; i < 25; i++)
      {
        order.Pizzas.Add(new VeggiePizza());
      }
      var sut = order;
      var act = Program.PlaceOrder();
      Assert.Equal(act, true);
    }
  }
}
