using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class FileRepository
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<AStore> ReadFromFile(string path)
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(List<AStore>));

        return xml.Deserialize(reader) as List<AStore>; // if casting fails, ==> null POCOs, plain old csharp objects
        //return (List<AStore>)xml.Deserialize(reader); // if casting fails ==> exception
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool WriteToFile(string path, List<AStore> stores)
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(List<AStore>));

        xml.Serialize(writer, stores);

        return true;
      }
      catch
      {
        // throw new Exception("reaiding because reason", e);
        return false;
      }
    }
  }
}
