using System.Text.Json;
using TestCrossSiteRf.Models;

namespace TestCrossSiteRf.Helpers;

public static class ShoppingCartHelper
{
    public static List<ShoppingCartItem> getCart()
    {
        var cartAsJson = StaticHttpContext.Current?.Session.GetString("ShoppingCart");
        if (cartAsJson == null)
        {
            return new List<ShoppingCartItem>();
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
}