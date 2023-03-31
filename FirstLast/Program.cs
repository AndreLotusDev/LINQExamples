var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Find the cheapest and most expensive products using LINQ First and Last
var cheapestProduct = shoppingCart.Products.First(p => p.Price == shoppingCart.Products.Min(p2 => p2.Price));
var mostExpensiveProduct = shoppingCart.Products.Last(p => p.Price == shoppingCart.Products.Max(p2 => p2.Price));

// Display the cheapest and most expensive products
Console.WriteLine($"Cheapest Product: {cheapestProduct.Name} (${cheapestProduct.Price})");
Console.WriteLine($"Most Expensive Product: {mostExpensiveProduct.Name} (${mostExpensiveProduct.Price})");
static string FindFirstNameInTheCollection(IEnumerable<string> words)
{
    return words.FirstOrDefault(f => f.Length >= 2 && char.IsUpper(f[0]) && f.Substring(1).All(a => char.IsLower(a)));
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
                Price = random.Next(1, 1000)
            };
            Products.Add(product);
        }
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}