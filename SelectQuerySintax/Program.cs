SalesData salesData = new SalesData();
salesData.GenerateSalesData();

// Select sales from the last 7 days and calculate the total revenue per customer
var revenueByCustomer = from sale in salesData.Sales
    where sale.Date >= DateTime.Now.AddDays(-7)
    group sale by sale.CustomerName into customerGroup
    select new
    {
        CustomerName = customerGroup.Key,
        TotalRevenue = customerGroup.Sum(sale => sale.Total)
    };

// Display the results
Console.WriteLine("Revenue by customer in the last 7 days:");
foreach (var result in revenueByCustomer)
{
    Console.WriteLine($"{result.CustomerName}: {result.TotalRevenue:C}");
}

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public string CustomerName { get; set; }
    public List<SaleItem> Items { get; set; }
}

public class SaleItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class SalesData
{
    public List<Sale> Sales { get; set; }

    public SalesData()
    {
        Sales = new List<Sale>();
    }

    public void GenerateSalesData()
    {
        Random random = new Random();

        for (int i = 1; i <= 100; i++)
        {
            List<SaleItem> items = new List<SaleItem>();
            int itemCount = random.Next(1, 6);

            for (int j = 1; j <= itemCount; j++)
            {
                SaleItem item = new SaleItem
                {
                    Id = j,
                    ProductName = $"Product {j}",
                    Price = random.Next(1, 50),
                    Quantity = random.Next(1, 6)
                };

                items.Add(item);
            }

            Sale sale = new Sale
            {
                Id = i,
                Date = DateTime.Now.AddDays(-random.Next(1, 30)),
                CustomerName = $"Customer {i}",
                Items = items
            };

            sale.Total = items.Sum(item => item.Price * item.Quantity);

            Sales.Add(sale);
        }
    }
}