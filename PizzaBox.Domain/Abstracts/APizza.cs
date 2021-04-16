using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  public abstract class APizza
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    protected APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddCrust() { }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddSize() { }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddToppings() { }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
