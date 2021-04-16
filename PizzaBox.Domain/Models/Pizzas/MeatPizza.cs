using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    protected override void AddCrust()
    {
      Crust = new Crust() { Name = "Stuffed" };
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddSize()
    {
      Size = new Size() { Name = "Medium" };
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddToppings()
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Ricotta" },
        new Topping() { Name = "Bolognese" }
      };
    }
  }
}
