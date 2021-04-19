using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  ///
  /// </summary>
  public class PizzaSingleton
  {
    private const string _path = @"data/pizzas.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;

    public List<APizza> Pizzas { get; private set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    ///
    /// </summary>
    private PizzaSingleton()
    {
      if (Pizzas == null)
      {
        Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);
      }
    }
  }
}
