//links
using System.Collections.Generic;

namespace PizzaBox.Client.Singletons
{
  public class InterfaceSingleton
  {
    private static InterfaceSingleton _instance;
    public List<string> FinalActions { get; } = new List<string>
    {
      "Preview of the order in progress",
      "Add a pizza to your order",
      "Remove a pizza from your order",
      "Checkout with your current order",
      "View order history",
      "Make new order",
    };
    private static InterfaceSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new InterfaceSingleton();
        }
        return _instance;
      }
    }
    public static void printList<T>(List<T> list, string message)
    {
      int index = 0;
      System.Console.WriteLine(message);
      foreach (var item in list)
      {
        System.Console.WriteLine($"{++index} - {item}");
      }
    }
    private InterfaceSingleton() { }
  }
}

//class
//user actions