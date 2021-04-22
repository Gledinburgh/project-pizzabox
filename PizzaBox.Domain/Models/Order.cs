using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
    public long CustomerEntityId { get; set; }
    public AStore Store { get; set; }
    public APizza Pizza { get; set; }
    public List<APizza> Pizzas { get; set; }
    public Order()
    {
      Pizzas = new List<APizza>();
    }
    public decimal TotalCost
    {
      get
      {
        var sum = 0m;
        foreach (APizza pizza in Pizzas)
        {
          sum += pizza.Crust.Price + pizza.Size.Price;
          foreach (Topping topping in pizza.Toppings)
          {
            sum += topping.Price;
          }
        }
        return sum;
      }
    }
  }
}
