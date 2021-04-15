using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreSingleton
  {
    private static readonly StoreSingleton _instance;
    public List<AStore> Stores { get; }

    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new StoreSingleton();
        }

        return _instance;
      }
    }

    private StoreSingleton()
    {
      Stores = new List<AStore>();
    }
  }
}