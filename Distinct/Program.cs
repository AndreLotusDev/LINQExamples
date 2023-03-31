// Create a shopping cart with 100 random products
var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Add some duplicate products to the list
shoppingCart.Products.Add(new Product { Name = "Product 1", Price = 50 });
shoppingCart.Products.Add(new Product { Name = "Product 1", Price = 50 });
shoppingCart.Products.Add(new Product { Name = "Product 2", Price = 10 });
shoppingCart.Products.Add(new Product { Name = "Product 3", Price = 20 });

// Filter the shopping cart to get only distinct products based on name and price
var distinctProducts = shoppingCart.Products.Distinct(new ProductComparer());

// Display the distinct products
Console.WriteLine("Distinct Products:");
foreach (var product in distinctProducts)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

class ProductComparer : IEqualityComparer<Product>
{
    public bool Equals(Product x, Product y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
        return x.Name == y.Name && x.Price == y.Price;
    }

    public int GetHashCode(Product obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.Name.GetHashCode();
            hash = hash * 23 + obj.Price.GetHashCode();
            return hash;
        }
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