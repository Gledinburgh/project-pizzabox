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
    protected override void AddName()
    {
      Name = "Meat Pizza";
    }
    protected override void AddCrust()
    {
      Crust = new Crust() { Name = "Neapolitan" };
    }

    /// <summary>
    ///
    /// </summary>
    protected override void AddSize()
    {
      Size = new Size("Medium");
    }

    /// <summary>
    ///
    /// </summary>
    protected override void AddToppings()
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Parmigiano" },
        new Topping() { Name = "Margherita" }
      };
    }
  }
}
