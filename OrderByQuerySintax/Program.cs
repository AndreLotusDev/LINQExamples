var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

var productsByCategory = from p in shoppingCart.Products
    orderby p.Category ascending
    select p;

foreach (var product in productsByCategory)
{
    Console.WriteLine($"{product.Name} ({product.Category}): ${product.Price}");
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