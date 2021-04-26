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
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly Order _orderSingleton = OrderSingleton.Order;
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


      Console.WriteLine("\n");
      Console.WriteLine("===========================");
      Console.WriteLine("--- Welcome to PizzaBox ---");
      Console.WriteLine("===========================");
      Console.WriteLine("\n");
      Console.WriteLine("Let's get your order started");
      Console.WriteLine("\n");
      Order order = CreateNewOrder();
      PrintFinalActions();
      Boolean openMenue = true;
      while (openMenue)
      {
        PrintFinalActions();
        openMenue = SelectFinalAction();
      }
    }

    private static Order CreateNewOrder()
    {
      OrderSingleton.CreateNewOrder();
      _orderSingleton.Customer = SelectCustomer();
      PrintStoreList();
      _orderSingleton.Store = SelectStore();
      PrintPizzaList();
      _orderSingleton.Pizzas.Add(SelectPizza());
      return _orderSingleton;
    }

    private static Customer SelectCustomer()
    {
      System.Console.WriteLine("First, What is your name?");
      string input = System.Console.ReadLine();
      Customer customer = _customerSingleton.FetchCustomer(input);
      System.Console.WriteLine("\nIt's Good to see you, " + customer.Name + "\n");

      return customer;
    }

    private static Boolean SelectFinalAction()
    {
      int input = int.Parse(System.Console.ReadLine());
      if (input == 1) PrintOrder();
      else if (input == 2) { PrintPizzaList(); _orderSingleton.Pizzas.Add(SelectPizza()); }
      else if (input == 3) removePizza();
      else if (input == 4) return PlaceOrder();
      else if (input == 5) PrintCustomerOrderHistory();
      else if (input == 6) CreateNewOrder();
      else if (input == 7) return false;
      return true;
    }

    private static void PrintCustomerOrderHistory()
    {
      IEnumerable<Order> orders = _customerSingleton.FetchCustomerOrders(_orderSingleton.Customer);
      foreach (Order o in orders)
      {
        InterfaceSingleton.printList(o.Pizzas, o.TimeOfPurchase.ToString());
      }
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
      InterfaceSingleton.printList(_interfaceSingleton.FinalActions, ("=========================="));
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintOrder()
    {
      InterfaceSingleton.printList(_orderSingleton.Pizzas, "Your order so far");
      System.Console.WriteLine("Total: $" + _orderSingleton.TotalCost);
      System.Console.WriteLine("Store: " + _orderSingleton.StoreEntityId
      + " Customer:" + _orderSingleton.Customer.Name + "Time: " + _orderSingleton.TimeStamp.ToString("hh:mm:ss tt"));
    }

    /// <summary>
    ///
    /// </summary>
    private static void PrintPizzaList()
    {
      System.Console.WriteLine("\n");
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
      System.Console.WriteLine("Store: " + store);
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
    public static bool PlaceOrder()
    {
      if (_orderSingleton.TotalCost <= 250 && _orderSingleton.Pizzas.Count <= 50)
      {
        _storeSingleton.AddOrder(_orderSingleton.Store, _orderSingleton);
        System.Console.WriteLine("Thankyou " + _orderSingleton.Customer.Name + "! Your order has been placed.");
        return false;
      }
      else
      {
        System.Console.WriteLine("Your order Exceeds order limit of $250 or the maximum of 50 pizzas, please remove Items before subbmitting your order");
        return true;
      }
    }
  }
}


