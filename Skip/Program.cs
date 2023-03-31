// Create a shopping cart with 100 random products
var shoppingCart = new ShoppingCart();
shoppingCart.GenerateProducts(100);

// Define pagination variables
var pageSize = 10;
var page = 1;

// Find all products that are cheaper than 10 using LINQ TakeWhile
var cheapProducts = shoppingCart.Products.Where(p => p.Price < 10);

// Paginate the cheap products and display the page
Console.WriteLine($"Cheap Products (Page {page}):");
foreach (var product in cheapProducts.Skip((page - 1) * pageSize).Take(pageSize))
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

// Prompt user to display next page
Console.WriteLine("Press enter to show the next page...");
Console.ReadLine();

// Increment the page number and display the next page
page++;
Console.WriteLine($"Cheap Products (Page {page}):");
foreach (var product in cheapProducts.Skip((page - 1) * pageSize).Take(pageSize))
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}

static double CalculateAverageMark(Student student)
{
    if (student.Marks == null)
    {
        return 0;
    }

    if (student.Marks.Any() == false)
    {
        return 0;
    }

    if (student.Marks.Count() < 3)
    {
        return 0;
    }

    return student.Marks.OrderBy(o => o).Skip(1).OrderByDescending(o => o).Skip(1).Average();
}

public class Student
{
    public IEnumerable<int> Marks { get; set; }
}

//feel free to ignore this method
//it is added because Udemy uses .NET Core 1
//and SkipLast is available since .NET Core 2
//so I just added this method so we can use SkipLast
public static class EnumerableExtension
{
    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (count == 0)
        {
            return source;
        }

        var toTake = source.Count() - count;
        return source.Take(toTake);
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