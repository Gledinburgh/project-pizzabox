using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Client
{
  /// <summary>
  ///
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;

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
      PrintStoreList();

      order.Customer = new Customer();
      order.Store = SelectStore();
      order.Pizza = SelectPizza();
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    private static void PrintToppings()
    {
      var index = 0;
      foreach (var topping in Topping.toppings)
      {
        Console.WriteLine($"{++index} - {topping}");
      }

    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      if (input == 1)
      {
        var custom = CreateCustomPizza();
        PrintOrder(custom);
        return custom;

      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];


      PrintOrder(pizza);

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

      PrintPizzaList();

      return _storeSingleton.Stores[input - 1];
    }
    private static CustomPizza CreateCustomPizza()
    {
      CustomPizza customPizza = new CustomPizza();
      System.Console.WriteLine("please select your toppings");
      PrintToppings();
      customPizza = AddTopping(customPizza);
      var response = Console.ReadLine();
      // customPizza = SelectCrust(customPizza);

      return customPizza;

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
  }
}

