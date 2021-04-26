//links
using System.Collections;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Client.Singletons
{
  public class UI
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    public static List<string> FinalActions = new List<string>
    {
      "Preview your order in progress",
      "Add a pizza to your order",
      "Remove a pizza from your order",
      "Checkout with your current order",
      "View order history",
      "Make new order",
      "Exit"
    };
    public static List<string> AccountTypes = new List<string>
    {
      "Customer",
      "Store Admin"
    };
    public static List<string> OpeningActions = new List<string>
    {
      "View order history",
      "Make new order",
      "Exit"
    };
    public static void printList<T>(List<T> list, string message)
    {
      int index = 0;
      System.Console.WriteLine(("--------------------------"));
      System.Console.WriteLine(message);
      foreach (var item in list)
      {
        System.Console.WriteLine($"{++index} - {item}");
      }
    }
    public static void PrintPizzaList()
    {
      printList(_pizzaSingleton.Pizzas, "Please select a Pizza");
    }
    public static void PrintCustomerOrderHistory()
    {
      IEnumerable<Order> orders = _customerSingleton.FetchCustomerOrders(OrderSingleton.Order.Customer);
      foreach (Order o in orders)
      {
        printList(o.Pizzas, o.TimeOfPurchase.ToString());
      }
    }
    public static string SelectAccountType()
    {
      printList(AccountTypes, "Select Your Account Type");
      return Selector(AccountTypes);
    }
    public static T Selector<T>(List<T> list)
    {
      var valid = int.TryParse(System.Console.ReadLine(), out int input);
      T item = list[input - 1];
      return item;
    }
    public static void SelectOpeningActions()
    {
      printList(OpeningActions, "What would you Like to do?");
      int action = int.Parse(System.Console.ReadLine());
      if (action == 1) PrintCustomerOrderHistory();
      if (action == 2) CreateNewOrder();
    }
    public static void SelectCustomer()
    {
      System.Console.WriteLine("What is your name?");
      string input = System.Console.ReadLine();
      Customer customer = _customerSingleton.FetchCustomer(input);
      OrderSingleton.Order.Customer = customer;
      System.Console.WriteLine("It's Good to see you, " + customer.Name);
      // return customer;
    }
    public static Order CreateNewOrder()
    {
      OrderSingleton.CreateNewOrder();
      PrintStoreList();
      OrderSingleton.Order.Store = SelectStore();
      UI.PrintPizzaList();
      OrderSingleton.Order.Pizzas.Add(Program.SelectPizza());
      return OrderSingleton.Order;
    }
    public static void PrintStoreList()
    {
      printList(_storeSingleton.Stores, "Please select a store");
    }
    public static AStore SelectStore()
    {
      return Selector(_storeSingleton.Stores);
    }
  }
}
//class
//user actions