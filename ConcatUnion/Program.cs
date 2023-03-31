// Create two shopping carts with random products

using System.Text.RegularExpressions;

var shoppingCart1 = new ShoppingCart();
shoppingCart1.GenerateProducts(50);

var shoppingCart2 = new ShoppingCart();
shoppingCart2.GenerateProducts(75);

// Combine the two shopping carts using Union()
var combinedShoppingCart = shoppingCart1.Products.Union(shoppingCart2.Products);

// Display the combined shopping cart
//Console.WriteLine("Combined Shopping Cart:");
//foreach (var product in combinedShoppingCart)
//{
//    Console.WriteLine($"{product.Name}: ${product.Price}");
//}

// Combine the two shopping carts using Union() and a custom comparer
var combinedShoppingCartUnion = shoppingCart1.Products.Union(shoppingCart2.Products, new ProductNameComparer());

// Display the combined shopping cart
Console.WriteLine("Combined Shopping Cart:");
foreach (var product in combinedShoppingCartUnion)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

static IEnumerable<int> GetPerfectSquares_Refactored(IEnumerable<int> numbers1, IEnumerable<int> numbers2)
{
    return numbers1.Where(w => Math.Sqrt(w) % 1 == 0)
        .Concat(numbers2.Where(w => Math.Sqrt(w) % 1 == 0))
        .Distinct()
        .OrderBy(o => o);
}

public struct News
{
    public DateTime PublishingDate { get; set; }
    public Priority Priority { get; set; }

    public override string ToString()
    {
        return $"Date: {PublishingDate.ToString("d")}, Priority: {Priority}";
    }
}

public enum Priority
{
    Low,
    Medium,
    High
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class ShoppingCart
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void GenerateProducts(int count)
    {
        var random = new Random();
        for (int i = 1; i <= count; i++)
        {
            var product = new Product
            {
                Name = $"Product {i}",
                Price = random.Next(1, 100)
            };
            Products.Add(product);
        }
    }
}
class ProductNameComparer : IEqualityComparer<Product>
{
    public bool Equals(Product x, Product y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return x.Name == y.Name;
    }

    public int GetHashCode(Product product)
    {
        if (product == null)
        {
            return 0;
        }

        return product.Name.GetHashCode();
    }
}