using System;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AStore : Object
  {
    public string Name { get; protected set; }


    public override string ToString()
    {
      return Name;
    }
  }
}
