namespace CrossSiteRf.Models;

public class ShoppingCartItem
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }
}