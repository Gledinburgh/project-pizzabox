# pizzabox

Not impressed with UberEats, DoorDash, GrubHub pizza offerings?
You can now try PizzaBox, the latest food delivery service.
It is a command line-based application focused on nothing but pizzas.

## as a customer

-x should be able to launch the application
-x should be able to view all stores
-x should be able to select a store
-x should be to place an order
-x should be able to choose either custom or pre-set pizzas

  for a custom pizza
  -x should be able to choose crust, size and toppings

  for a preset pizza
  -x should be able to choose pizza and size

-x should be able to view a preview of the order in progress
-x should be able to modify the order in progress (add/remove pizza)
-x should be able to place/checkout the order in progress
-x should be able to view order history
-x should be able to make new order

## as a store

- should be able to launch the application
- should be able to select options

  for order history
  - should be able to view all orders (including pizza count and total cost)
  - should be able to view orders by customer

  for sales
  - should be able to view revenue by week (inluding pizza type and count)
  - should be able to view revenue by month (including pizza type and count)

## architecture

- [solution] PizzaBox.sln
  - [project - console] PizzaBox.Client.csproj
    - [directory] Singletons
  - [project - classlib] PizzaBox.Domain.csproj
    - [directory] Abstracts
    - [directory] Models
  - [project - classlib ] PizzaBox.Storing.csproj
    - [directory] Repositories
  - [project - xunit] PizzaBox.Testing.csproj
    - [directory] Tests

## requirements

The application is centered around the interaction of 4 main objects:
- Customer
- Order
- Pizza
- Store

The database should maintain
- Customer
- Order
- Store

### store

x [required] there should exist at least 2 stores for a customer to choose from
+ [required] each store should be able to view any and all of their placed orders
+ [required] each store should be able to view any and all of their sales (weekly, monthly, quarterly)

### order

x [required] each order must be able to modify its collection of pizzas
x [required] each order must be able to compute its pricing
x [required] each order must be limited to a total pricing of no more than $250
x [required] each order must be limited to a collection of pizzas of no more than 50

### pizza

x [required] each pizza must be able to have a crust
x [required] each pizza must be able to have a size
x [required] each pizza must be able to have toppings
x [required] each pizza must be able to compute its pricing
x [required] each pizza must have no less than 2 default toppings
x [required] each pizza must have no more than 5 total toppings

### customer

x [required] must be able to view its order history
+ [required] must be able to only order from 1 location in a 24-hour period with no reset
+ [required] must be able to only order once in a 2-hour period

## technologies

+ .NET Core - C#
+ .NET Core - EF + SQL
+ .NET Core - xUnit

## timelines

- code-freeze on Apr-26 at 11.59p Central
- presentation on Apr-28 starting at 9.30a Central
- try to implement as many requirements as you can (don't push to get all done)
- should be an mvp (minimum viable product) status (20 hours)
  x able to at least place an order with 1 pizza
  - able to at least have 10 total validation unit tests for Customer, Order, Pizza, Store
  x able to save a placed order including customer info, pizza info, store info

> the goal is to try to complete as many reqs as you can in the time alloted. :)

todo:
  create tests
  refactor database access using LINQ
  abstract print function calls to singleton
