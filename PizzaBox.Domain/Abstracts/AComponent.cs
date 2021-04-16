namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  public class AComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Name;
    }
  }
}
