using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models.Pizzas;
using System.Collections.Generic;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  /// <summary>
  ///
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly InterfaceSingleton _interfaceSingleton = InterfaceSingleton.Instance;

    /// <summary>
    ///
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    ///
    /// </summary>
    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("Welcome to PizzaBox");
      Console.WriteLine("==========================");
      PrintStoreList();

      order.Customer = new Customer();
      order.Store = SelectStore();
      PrintPizzaList();
      order.Pizzas.Add(SelectPizza());
      PrintFinalActions();
      Boolean openMenue = true;
      while (openMenue)
      {
        PrintFinalActions();
        SelectFinalAction(order, order.Store);
      }
    }

    private static Boolean SelectFinalAction(Order order, AStore store)
    {
      int input = int.Parse(System.Console.ReadLine());
      if (input == 1) PrintOrder(order);
      else if (input == 2) { PrintPizzaList(); order.Pizzas.Add(SelectPizza()); }
      else if (input == 3) removePizza(order);
      else if (input == 4) PlaceOrder(store, order);
      else if (input == 7) return false;
      return true;
    }

    private static void removePizza(Order order)
    {
      PrintOrder(order);
      System.Console.WriteLine("Select a pizza to remove");
      int input = int.Parse(System.Console.ReadLine());
      order.Pizzas.Remove(order.Pizzas[input - 1]);
    }
    private static void PrintFinalActions()
    {
      InterfaceSingleton.printList(_interfaceSingleton.FinalActions, ("=========================="));
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintOrder(Order order)
    {
      InterfaceSingleton.printList(order.Pizzas, "Your order so far");
      System.Console.WriteLine("Total: $" + order.TotalCost);
      System.Console.WriteLine("Store: " + order.StoreEntityId
      + " Customer:" + order.Customer.Name + "Time: " + order.TimeStamp.ToString("hh:mm:ss tt"));
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintPizzaList()
    {
      InterfaceSingleton.printList(_pizzaSingleton.Pizzas, "Please select a Pizza");
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintSizes()
    {
      InterfaceSingleton.printList(Size.sizes, "Please select a size");
    }
    private static void PrintStoreList()
    {
      InterfaceSingleton.printList(_storeSingleton.Stores, "Please select a store");
    }

    private static void PrintToppings()
    {
      InterfaceSingleton.printList(Topping.toppings, "Please select your toppings");
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      int input = int.Parse(System.Console.ReadLine());

      if (input == 1)
      {
        var custom = CreateCustomPizza();
        return custom;
      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];
      PrintSizes();
      SelectSize(pizza);
      return pizza;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      AStore store = _storeSingleton.Stores[input - 1];
      System.Console.WriteLine("store: " + store);
      return store;
    }
    private static CustomPizza CreateCustomPizza()
    {
      CustomPizza customPizza = new CustomPizza();
      PrintToppings();
      customPizza = AddTopping(customPizza);
      PrintCrusts();
      customPizza = SelectCrust(customPizza);
      PrintSizes();
      SelectSize(customPizza);
      return customPizza;
    }

    private static APizza SelectSize(APizza currentPizza)
    {
      string input = System.Console.ReadLine();
      int index = int.Parse(input);
      Size size = new Size(Size.sizes[index - 1]);
      currentPizza.Size = size;
      return currentPizza;
    }

    private static CustomPizza AddTopping(CustomPizza customPizza)
    {
      var index = Console.ReadLine();
      var valid = int.TryParse(index, out int input);
      customPizza.Toppings.Add(new Topping(Topping.toppings[int.Parse(index) - 1]));
      System.Console.WriteLine(input);
      System.Console.WriteLine("add another? (Y/N)");
      var response = Console.ReadLine();
      if (response == "Y")
      {
        PrintToppings();
        AddTopping(customPizza);
      }
      return customPizza;
    }

    private static CustomPizza SelectCrust(CustomPizza customPizza)
    {
      string input = System.Console.ReadLine();
      int index = int.Parse(input);
      string crustName = Crust.crustsOptions[index - 1];
      Crust crust = new Crust(crustName);
      customPizza.Crust = crust;
      return customPizza;
    }
    private static void PrintCrusts()
    {
      InterfaceSingleton.printList(Crust.crustsOptions, "Please select your crust");
    }
    private static void PlaceOrder(AStore store, Order order)
    {
      _storeSingleton.AddOrder(store, order);
      System.Console.WriteLine("Thankyou " + order.Customer.Name + "! Your order has been placed.");
    }
  }
}


