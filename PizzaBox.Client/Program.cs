using System.Collections.Generic;
using System;
// using sc = System.Console; // alias

namespace PizzaBox.Client
{
  public class Program
  {
    private static void Main()
    {
      List<string> storeList = new List<string> { "Store 001", "Store 002" }; // explicit
      var stores = new List<Store> { new Store(), new Store() }; // datatype inference

      for (var x = 0; x < stores.Count; x += 1)
      {
        Console.WriteLine($"{x} - {stores[x]}");
      }

      Console.WriteLine("make a selection");

      string input = Console.ReadLine();
      int entry = int.Parse(input);

      Console.WriteLine(stores[entry]);
    }
  }
}
