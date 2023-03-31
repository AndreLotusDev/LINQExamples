var itemNames = new List<string> { "T-Shirt", "Jeans", "Sneakers", "Hat" };
var itemPrices = new List<decimal> { 20.99m, 49.99m, 89.99m, 9.99m };

var itemsWithPrices = itemNames.Zip(itemPrices, (name, price) => (name, price));

foreach (var item in itemsWithPrices)
{
    Console.WriteLine($"{item.name}: ${item.price}");
}

