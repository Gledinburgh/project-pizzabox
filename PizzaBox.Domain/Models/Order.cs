using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
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
        return Pizza.Crust.Price + Pizza.Size.Price + Pizza.Toppings.Sum(t => t.Price);
      }
    }
  }
}
