using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
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
      Stores = new List<AStore>()
      {
        new ChicagoStore(),
        new NewYorkStore()
      };
    }

    public void WriteToFile()
    {
      // need file access
      var path = @"store.xml"; // literal explicit string
      // open the file
      var writer = new StreamWriter(path);
      // convert object to text
      var xml = new XmlSerializer(typeof(List<AStore>));
      // write text to file
      xml.Serialize(writer, Stores);
    }
  }
}
