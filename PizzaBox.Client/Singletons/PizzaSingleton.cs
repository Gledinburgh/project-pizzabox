using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    public static List<APizza> pizzas = new List<APizza>
    {
      new CustomPizza(),
      new MeatPizza(),
      new VeggiePizza()
    };
  }
}