using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;
      //sut.Name = "dotnet";
      //actual = "dotnet"; // this should not happen

      // assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      Assert.True(sut.Name.Equals("NewYorkStore"));
    }
  }
}