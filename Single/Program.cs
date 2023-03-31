// Create a shopping cart with 100 random products
var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Find the cheapest and most expensive products using LINQ SingleOrDefault
var cheapestCategory = shoppingCart.Products
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, MinPrice = g.Min(p => p.Price) })
    .OrderBy(x => x.MinPrice)
    .FirstOrDefault();
var mostExpensiveCategory = shoppingCart.Products
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) })
    .OrderByDescending(x => x.MaxPrice)
    .FirstOrDefault();

// Display the cheapest and most expensive categories
Console.WriteLine($"Cheapest Category: {cheapestCategory.Category} (${cheapestCategory.MinPrice})");
Console.WriteLine($"Most Expensive Category: {mostExpensiveCategory.Category} (${mostExpensiveCategory.MaxPrice})");

// Try to find a category that doesn't exist in the shopping cart
try
{
    var nonExistentCategory = ProductCategory.Miscellaneous;
    var category = shoppingCart.Products
        .Where(p => p.Category == nonExistentCategory)
        .SingleOrDefault();
    if (category == null)
    {
        throw new Exception($"Category {nonExistentCategory} not found in shopping cart.");
    }
    Console.WriteLine($"Found category: {category.Category}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

enum ProductCategory
{
    Electronics,
    Clothing,
    Books,
    Home,
    Sports,
    Beauty,
    Food,
    Miscellaneous
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }
}

class ShoppingCart
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void GenerateProducts(int count)
    {
        var random = new Random();
        var categories = Enum.GetValues(typeof(ProductCategory)).Cast<ProductCategory>().ToList();
        for (int i = 1; i <= count; i++)
        {
            var category = categories[random.Next(categories.Count)];
            var product = new Product
            {
                Name = $"Product {i}",
                Price = random.Next(1, 1000),
                Category = category
            };
            Products.Add(product);
        }
    }
}