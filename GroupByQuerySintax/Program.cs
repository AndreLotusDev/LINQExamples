var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

var groupedProducts = from product in shoppingCart.Products
                      group product by product.Category;

foreach (var group in groupedProducts)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group)
    {
        Console.WriteLine($"\t{product.Name} - ${product.Price}");
    }
}

public enum CategoryType
{
    Clothing,
    Electronics,
    Home,
    Beauty,
    Food
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public CategoryType Category { get; set; }
}

public class ShoppingCart
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void GenerateProducts(int count)
    {
        var random = new Random();
        var categories = Enum.GetValues(typeof(CategoryType)).Cast<CategoryType>().ToList();
        for (int i = 1; i <= count; i++)
        {
            var category = categories[random.Next(0, categories.Count)];
            var product = new Product
            {
                Name = $"Product {i}",
                Price = random.Next(1, 100),
                Category = category
            };
            Products.Add(product);
        }
    }
}