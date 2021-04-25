using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class ContextSingleton
  {
    private static ContextSingleton _instance;
    public PizzaBoxContext Context { get; }
    public static ContextSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ContextSingleton();
        }
        return _instance;
      }
    }

    private ContextSingleton()
    {
      if (Context == null)
      {
        Context = new PizzaBoxContext();
      }
    }

  }

}