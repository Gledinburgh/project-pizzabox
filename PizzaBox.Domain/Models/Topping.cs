using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {
    public static List<string> toppings = new List<string> { "peppers", "onions", "olives" };
    public Topping(string name)
    {
      Price = 0.25M;
      Name = name;

    }
    public Topping()
    {
      Price = 0.25M;
    }

  }
}
