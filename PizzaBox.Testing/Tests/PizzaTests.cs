using PizzaBox.Domain.Models.Pizzas;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTest
  {
    [Fact]
    public void Test_Pizza_Price()
    {
      //subject under test
      var sut = new MeatPizza();
      //actual
      var act = sut.PizzaPrice();
      //assert
      Assert.Equal(act, 12.5m);
    }
  }
}