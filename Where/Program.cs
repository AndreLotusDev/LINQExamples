// Create a shopping cart with 100 random products
var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Find all products that are more expensive than 10 using LINQ Where
var expensiveProducts = shoppingCart.Products.Where(p => p.Price > 10);

// Display the expensive products
Console.WriteLine($"Expensive Products:");
foreach (var product in expensiveProducts)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
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