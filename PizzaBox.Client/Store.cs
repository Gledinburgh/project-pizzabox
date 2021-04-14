using System;

namespace PizzaBox.Client
{
  public class Store
  {
    string name;
    public Store()
    {
      name = DateTime.Now.Ticks.ToString();
    }

    public override string ToString()
    {
      return name;
    }
  }
}