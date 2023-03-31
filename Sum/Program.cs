// Generate a list of random products for the shopping cart
using System.Linq;

var random = new Random();
var products = Enumerable.Range(1, 10)
    .Select(i => new Product
    {
        Name = $"Product {i}",
        Price = random.Next(1, 100)
    })
    .ToList();

// Display the products in the shopping cart
Console.WriteLine("Shopping Cart:");
foreach (var product in products)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

// Calculate the total amount in the shopping cart using LINQ Sum
var totalAmount = products.Sum(p => p.Price);

Console.WriteLine($"Total Amount: ${totalAmount}");
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

