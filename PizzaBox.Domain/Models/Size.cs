using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  ///
  /// </summary>
  public class Size : AComponent
  {
    public static List<string> sizes = new List<string> { "Small", "Medium", "Large" };

    public Size() { }
    public Size(string size)
    {
      Name = size;
      if (size == "Small") Price = 10.00M;
      if (size == "Medium") Price = 12.00M;
      if (size == "Large") Price = 15.00M;
    }
  }
}
