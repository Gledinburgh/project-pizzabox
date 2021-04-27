using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  ///
  /// </summary>
  public class Customer : AModel
  {
    public string Name { get; set; }
    // public List<Order> Orders { get; set; }
  }
}