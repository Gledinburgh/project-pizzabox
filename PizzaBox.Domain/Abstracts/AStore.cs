using System;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AStore
  {
    string name;
    public AStore()
    {
      name = DateTime.Now.Ticks.ToString();
    }

    public override string ToString()
    {
      return name;
    }
  }
}
