using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreSingleton
  {
    private const string _path = @"store.xml";
    private readonly FileRepository _fr = new FileRepository();
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
      if (Stores == null)
      {
        Stores = _fr.ReadFromFile(_path);
      }

      // if (Stores == null)
      // {
      //   _fr.WriteToFile(_path, new List<AStore>()
      //   {
      //     new ChicagoStore(),
      //     new NewYorkStore()
      //   });

      //   Stores = _fr.ReadFromFile(_path);
      // }
    }
  }
}
