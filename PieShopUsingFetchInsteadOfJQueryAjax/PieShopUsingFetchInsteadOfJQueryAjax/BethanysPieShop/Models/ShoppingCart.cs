using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class ShoppingCart : IShoppingCart
{
    private readonly BethanysPieShopDbContext _context;

    public string? ShoppingCartId { get; }

    private ShoppingCart(BethanysPieShopDbContext context, string cartId)
    {
        ShoppingCartId = cartId;
        _context = context;
    }

    public static ShoppingCart GetCart(ISession? session, BethanysPieShopDbContext context)
    {
        string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        session?.SetString("CartId", cartId);

        return new ShoppingCart(context, cartId);
    }

    public void AddToCart(Pie pie)
    {
        var shoppingCartItem =
            _context.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        var shoppingCartItem =
            _context.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        var localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _context.SaveChanges();

        return localAmount;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Pie)
                .ToList();
    }

    public void ClearCart()
    {
        var cartItems = _context
            .ShoppingCartItems
            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

        _context.ShoppingCartItems.RemoveRange(cartItems);

        _context.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.Pie.Price * c.Amount).Sum();
        return total;
    }
}