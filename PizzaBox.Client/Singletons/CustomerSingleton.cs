//access database
//if you need access to customers, you come here
//if you need to create a customer you come here

/*
needs:
instance of database context
list of all customers
add customer object
*/

using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

public class CustomerSingleton
{
  public readonly PizzaBoxContext _context = new PizzaBoxContext();
  private static CustomerSingleton _instance;
  public List<Customer> Customers { get; }
  public static CustomerSingleton Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new CustomerSingleton();
      }
      return _instance;
    }
  }
  private CustomerSingleton()
  {
    if (Customers == null)
    {
      Customers = _context.Customers.ToList();
    }
  }
  public Customer AddCustomer(string name)
  {
    Customer customer = new Customer();
    customer.Name = name;
    _context.Customers.Add(customer);
    _context.SaveChanges();
    return customer;
  }
  public Customer FetchCustomer(string name)
  {
    foreach (Customer customer in _context.Customers)
    {
      if (customer.Name == name)
      {
        return customer;
      }
    }
    return AddCustomer(name);
  }
  //check db for name entered
  //if in db then return customer object
  //if not in db call AddCustomer

}