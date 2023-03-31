var shoppingCart = GenerateRandomShoppingCart(10);
var productsByCategory = shoppingCart.GetProductsGroupedByCategory();

foreach (var category in productsByCategory.Keys)
{
    Console.WriteLine($"Category: {category}");

    foreach (var product in productsByCategory[category])
    {
        Console.WriteLine($"\t{product.Name} - {product.Price:C}");
    }
}

static ShoppingCart GenerateRandomShoppingCart(int numberOfProducts)
{
    var shoppingCart = new ShoppingCart();

    Random Random = new Random();

    for (int i = 0; i < numberOfProducts; i++)
    {
        var productName = $"Product {i + 1}";
        var price = Random.Next(1, 100);
        var category = (Category)Random.Next(Enum.GetValues(typeof(Category)).Length);

        var product = new Product { Name = productName, Price = price, Category = category };
        shoppingCart.AddProduct(product);
    }

    return shoppingCart;
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}

public enum Category
{
    Electronics,
    Clothing,
    Books,
    Food
}

public class ShoppingCart
{
    public List<Product> Products { get; set; }

    public ShoppingCart()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public Dictionary<Category, List<Product>> GetProductsGroupedByCategory()
    {
        return Products.GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}

