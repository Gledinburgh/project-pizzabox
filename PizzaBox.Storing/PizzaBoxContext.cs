using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  //context represents the interface from a code standpoint
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    //enteties
    //what needs to be saved
    //get and set represent the read and write methods
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Size> Sizes { get; set; }
    //dependency injection
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }
    //connection
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      //where they need to be saved
      builder.UseSqlServer(_configuration["mssql"]);
    }

    //what do we want to save
    //for the creation of the configuration
    protected override void OnModelCreating(ModelBuilder builder)
    {
      //creating indexes to maintain order durring transfer
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      OnDataSeeding(builder);
    }

    private void OnDataSeeding(ModelBuilder builder)
    {
      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Chitown Main Street"}
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "BigApple"}
      });
      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, Name = "Mac"}
      });
      builder.Entity<Order>().HasData(new Order[]
      {
        new Order() { EntityId = 1, CustomerEntityId = 1}
      });

    }
  }
}