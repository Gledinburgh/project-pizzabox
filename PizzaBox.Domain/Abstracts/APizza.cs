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
  public abstract class APizza : AModel
  {
    public string Name;
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public long CrustEntityId { get; set; }
    public long SizeEntityId { get; set; }
    public List<Topping> Toppings { get; set; }

    /// <summary>
    ///
    /// </summary>
    protected APizza()
    {
      Factory();
    }

    /// <summary>
    ///
    /// </summary>
    protected virtual void Factory()
    {
      AddName();
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    ///
    /// </summary>
    protected abstract void AddName();
    protected abstract void AddCrust();

    /// <summary>
    ///
    /// </summary>
    protected abstract void AddSize();

    /// <summary>
    ///
    /// </summary>
    protected abstract void AddToppings();

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

      return $"{Name} \n\t Crust: {Crust} \n\t Size: {Size} \n\t Toppings: {stringBuilder.ToString().TrimEnd(separator.ToCharArray())} \n\t Price: ${PizzaPrice()}\n";
    }
    public decimal PizzaPrice()
    {
      decimal sum = Crust.Price + Size.Price;
      foreach (Topping t in Toppings)
      {
        sum += t.Price;
      }
      return sum;
    }
  }
}
