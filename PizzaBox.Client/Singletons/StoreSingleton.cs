using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  ///
  /// </summary>
  public class StoreSingleton
  {
    private const string _path = @"data/stores.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    public readonly PizzaBoxContext _context = ContextSingleton.Instance.Context;
    private static StoreSingleton _instance;



    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    ///
    /// </summary>
    private StoreSingleton()
    {
      if (Stores == null)
      {
        Stores = _context.Stores.ToList();
      }
    }
    public void AddOrder(AStore store, Order order)
    {
      if (store.Orders == null) store.Orders = new List<Order>();
      order.TimeOfPurchase = order.TimeStamp;
      store.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}

