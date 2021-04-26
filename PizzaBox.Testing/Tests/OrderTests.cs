using Xunit;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Abstracts;
using System;

namespace PizzaBox.Testing.Tests
{

  public class OrderTests
  {
    ///<summary>
    /// test Total cost
    //given an odrder with a set of pizzas, It should return the accumulative price
    /// </summary>
    public static Order testOrder = new Order();
    public static List<APizza> testPizzas = new List<APizza>
    {
      new MeatPizza(),
      new VeggiePizza(),
      new CustomPizza()
   };
    [Fact]
    public void Test_Order_TotalCost()
    {
      testOrder.Pizzas = testPizzas;

      var sut = testOrder;
      var actual = sut.TotalCost;
      Assert.Equal(actual, 37.5m);
    }
    [Fact]
    public void Test_Order_TimeStamp()
    {
      testOrder.TimeOfPurchase = testOrder.TimeStamp;
      var sut = testOrder;
      var actual = testOrder.TimeOfPurchase;
      Assert.IsType<DateTime>(actual);
      Assert.NotNull(actual);
    }
  }
}

