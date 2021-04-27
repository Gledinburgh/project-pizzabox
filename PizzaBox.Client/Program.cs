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
    private static readonly ContextSingleton _contextSingleton = ContextSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance(_contextSingleton.Context);
    private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance(_contextSingleton.Context);
    private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance(_contextSingleton.Context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_contextSingleton.Context);
    private static readonly Order _orderSingleton = OrderSingleton.Order;
    private static readonly InterfaceSingleton _interfaceSingleton = InterfaceSingleton.Instance;
    private static void Main()
    {
      Run();
    }
    private static void Run()
    {


      Console.WriteLine("\n");
      Console.WriteLine("===================================");
      Console.WriteLine("------- Welcome to PizzaBox -------");
      Console.WriteLine("===================================");
      Console.WriteLine("\n");
      Console.WriteLine("Let's get your order started");
      Console.WriteLine("\n");
      Order order = CreateNewOrder();
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
      System.Console.WriteLine("\nIt's Good to see you, " + customer.Name);

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
        InterfaceSingleton.printList(o.Pizzas, o.TimeOfPurchase.ToString("MMMM dd, yyyy"));
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
      InterfaceSingleton.printList(_interfaceSingleton.FinalActions, ("What would you like to do next"));
    }
    private static void PrintOrder()
    {
      InterfaceSingleton.printList(_orderSingleton.Pizzas, "Your order so far");
      System.Console.WriteLine("Total: $" + _orderSingleton.TotalCost);
      System.Console.WriteLine("Store:" + _orderSingleton.Store.Name + " Customer:" + _orderSingleton.Customer.Name + " Time:" + _orderSingleton.TimeStamp.ToString("hh:mm tt"));
    }
    private static void PrintPizzaList()
    {

      InterfaceSingleton.printList(_pizzaSingleton.Pizzas, "Please select a Pizza");
    }
    private static void PrintSizes()
    {
      InterfaceSingleton.printList(_sizeSingleton.Sizes, "Please select a size");
    }
    private static void PrintStoreList()
    {
      InterfaceSingleton.printList(_storeSingleton.Stores, "Please select a store");
    }

    private static void PrintToppings()
    {
      InterfaceSingleton.printList(_toppingSingleton.Toppings, "Please select your toppings");
    }
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
      Size size = _sizeSingleton.Sizes[index - 1];
      currentPizza.Size = size;
      return currentPizza;
    }
    private static CustomPizza AddTopping(CustomPizza customPizza)
    {
      var index = Console.ReadLine();
      var valid = int.TryParse(index, out int input);

      customPizza.Toppings.Add(_toppingSingleton.Toppings[int.Parse(index) - 1]);
      System.Console.WriteLine(input);
      if (customPizza.Toppings.Count > 4)
      {
        System.Console.WriteLine("\n");
        InterfaceSingleton.printList(customPizza.Toppings, "Here are your Pizzas Toppings");
        return customPizza;
      }
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
      Crust crust = _crustSingleton.Crusts[index - 1];
      customPizza.Crust = crust;
      return customPizza;
    }

    private static void PrintCrusts()
    {
      InterfaceSingleton.printList(_crustSingleton.Crusts, "Please select your crust");
    }

    public static bool PlaceOrder()
    {
      if (ValidateOrderTime() == false)
      {
        System.Console.WriteLine("A new order can not be placed within 2 hours of last order");
        return true;
      }
      else if (_orderSingleton.TotalCost <= 250 && _orderSingleton.Pizzas.Count <= 50)
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

    public static bool ValidateOrderTime()
    {

      DateTime timeOfPurchase;
      List<Order> orders = _customerSingleton.FetchCustomerOrders(_orderSingleton.Customer);

      if (orders.Count >= 1)
      {

        timeOfPurchase = orders[orders.Count - 1].TimeOfPurchase;
        DateTime currentTime = DateTime.Now;
        int timeElapsed = currentTime.Subtract(timeOfPurchase).Hours;

        if (timeElapsed <= 2)
        {

          System.Console.WriteLine("\nHours elapsed since last order: " + timeElapsed);
          return false;

        }
      }

      return true;

    }
  }
}


