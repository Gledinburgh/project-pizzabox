using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  ///
  /// </summary>
  public class Crust : AComponent
  {
    public static List<string> crustsOptions = new List<string> { "Thin", "Stuffed", "Original" };
    public Crust(string name)
    {
      Name = name;
    }
    public Crust() { }
  }
}
