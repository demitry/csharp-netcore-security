using System.Text.Json;
using CrossSiteRf.Models;

namespace CrossSiteRf.Helpers;

public static class ShoppingCartHelper
{
    public static List<ShoppingCartItem> getCart()
    {
        var cartAsJson = StaticHttpContext.Current?.Session.GetString("ShoppingCart");
        if (cartAsJson == null)
        {
            return new List<ShoppingCartItem>(){ 
                new ShoppingCartItem() { Name = "Car", Price = 20, Quantity = 1 },
                new ShoppingCartItem() { Name = "Toy", Price = 2, Quantity = 3 },
                new ShoppingCartItem() { Name = "Tetris", Price = 3, Quantity = 1 }
            };
        }
        else
        {
            return JsonSerializer.Deserialize<List<ShoppingCartItem>>(cartAsJson) ?? new List<ShoppingCartItem>();
        }
    }
    public static void addToCart(ShoppingCartItem item)
    {
        var cart = getCart();
        cart.Add(item);
        StaticHttpContext.Current?.Session.SetString("ShoppingCart", JsonSerializer.Serialize<List<ShoppingCartItem>>(cart));
    }
    
    public static void clearCart()
    {
        StaticHttpContext.Current?.Session.SetString("ShoppingCart", "[]");
    }
    
    
}