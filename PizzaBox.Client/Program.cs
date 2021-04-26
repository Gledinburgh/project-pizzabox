using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models.Pizzas;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  /// <summary>
  ///
  /// </summary>
  public class Program
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly Order _orderSingleton = OrderSingleton.Order;

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
      Console.WriteLine("Welcome to PizzaBox");
      Console.WriteLine("==========================");
      string accountType = UI.SelectAccountType();
      if (accountType == "Customer")
      {
        UI.SelectCustomer();
        UI.SelectOpeningActions();

      }
      PrintFinalActions();
      Boolean openMenue = true;
      while (openMenue)
      {
        PrintFinalActions();
        openMenue = SelectFinalAction();
      }
    }
    private static Boolean SelectFinalAction()
    {
      int input = int.Parse(System.Console.ReadLine());
      if (input == 1) PrintOrder();
      else if (input == 2) { UI.PrintPizzaList(); _orderSingleton.Pizzas.Add(SelectPizza()); }
      else if (input == 3) removePizza();
      else if (input == 4) { PlaceOrder(); return false; }
      else if (input == 5) UI.PrintCustomerOrderHistory();
      else if (input == 6) UI.CreateNewOrder();
      else if (input == 7) return false;
      return true;
    }


    private static void removePizza()
    {
      PrintOrder();
      System.Console.WriteLine("Select a pizza to remove");
      int input = int.Parse(System.Console.ReadLine());
      _orderSingleton.Pizzas.Remove(_orderSingleton.Pizzas[input - 1]);
    }
    private static void PrintFinalActions()
    {
      UI.printList(UI.FinalActions, ("=========================="));
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintOrder()
    {
      UI.printList(_orderSingleton.Pizzas, "Your order so far");
      System.Console.WriteLine("Total: $" + _orderSingleton.TotalCost);
      System.Console.WriteLine("Store: " + _orderSingleton.StoreEntityId
      + " Customer:" + _orderSingleton.Customer.Name + "Time: " + _orderSingleton.TimeStamp.ToString("hh:mm:ss tt"));
    }

    /// <summary>
    ///
    /// </summary>


    /// <summary>
    ///
    /// </summary>
    private static void PrintSizes()
    {
      UI.printList(Size.sizes, "Please select a size");
    }
    private static void PrintStoreList()
    {

    }

    private static void PrintToppings()
    {
      UI.printList(Topping.toppings, "Please select your toppings");
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public static APizza SelectPizza()
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

    public static CustomPizza CreateCustomPizza()
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
      UI.printList(Crust.crustsOptions, "Please select your crust");
    }
    private static void PlaceOrder()
    {
      _storeSingleton.AddOrder(_orderSingleton.Store, _orderSingleton);
      System.Console.WriteLine("Thankyou " + _orderSingleton.Customer.Name + "! Your order has been placed.");
      OrderSingleton.CreateNewOrder();
    }
  }
}


