var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Create new products to prepend and append to the shopping cart
var newProduct1 = new Product { Name = "New Product 1", Price = 10 };
var newProduct2 = new Product { Name = "New Product 2", Price = 20 };

// Prepend the new product to the beginning of the shopping cart
shoppingCart.Products = shoppingCart.Products.Prepend(newProduct1).ToList();

// Append the new product to the end of the shopping cart
shoppingCart.Products = shoppingCart.Products.Append(newProduct2).ToList();

// Display the updated shopping cart
Console.WriteLine("Updated Shopping Cart:");
foreach (var product in shoppingCart.Products)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

static IEnumerable<string> TrimSentenceAndChangeEndMarker_Refactored(IEnumerable<string> words)
{
    return words.TakeWhile(word => word != "The end").Append("END");
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