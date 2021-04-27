
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class SizeSingleton
  {
    private static SizeSingleton _instance;
    private static PizzaBoxContext _context;

    public List<Size> Sizes { get; set; }
    public static SizeSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new SizeSingleton(context);
      }
      return _instance;
    }

    private SizeSingleton(PizzaBoxContext context)
    {
      _context = context;
      Sizes = new List<Size>
      {
        _context.Sizes.FirstOrDefault(s => s.Name == "Small"),
        _context.Sizes.FirstOrDefault(s => s.Name == "Medium"),
        _context.Sizes.FirstOrDefault(s => s.Name == "Large"),
      };
    }


  }
}