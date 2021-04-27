
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class ToppingSingleton
  {
    private static ToppingSingleton _instance;
    private static PizzaBoxContext _context;

    public List<Topping> Toppings { get; set; }
    public static ToppingSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new ToppingSingleton(context);
      }
      return _instance;
    }

    private ToppingSingleton(PizzaBoxContext context)
    {
      _context = context;
      Toppings = _context.Toppings.ToList();
    }
  }
}