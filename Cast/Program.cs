var shoppingCarts = new List<ShoppingCart>();
for (int i = 1; i <= 3; i++)
{
    var shoppingCart = new ShoppingCart();
    shoppingCart.GenerateProducts(5 * i);
    shoppingCarts.Add(shoppingCart);
}

// Use AsEnumerable() to cast each Products list to an IEnumerable<Product>
var allProducts = shoppingCarts.SelectMany(cart => cart.Products.AsEnumerable());

// Use ToList() to convert the allProducts IEnumerable<Product> to a List<Product>
var allProductsList = allProducts.ToList();

// Use ToLookup() to group the allProducts by the first letter of their Name property
var productsByFirstLetter = allProducts.ToLookup(p => p.Name.Substring(0, 1));

// Use ToDictionary() to convert the allProductsList to a dictionary keyed by the product name
var productsByName = allProductsList.ToDictionary(p => p.Name);

// Display the products in each collection
Console.WriteLine("All Products:");
foreach (var product in allProducts)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

Console.WriteLine("All Products List:");
foreach (var product in allProductsList)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

Console.WriteLine("Products By First Letter:");
foreach (var group in productsByFirstLetter)
{
    Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(p => p.Name))}");
}

Console.WriteLine("Products By Name:");
foreach (var pair in productsByName)
{
    Console.WriteLine($"{pair.Key}: ${pair.Value.Price}");
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public IEnumerable<int> Marks { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, {DateOfBirth.ToString("d")}, Marks = {string.Join(", ", Marks)}";
    }
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