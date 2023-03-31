var customers = new List<Customer>
{
    new Customer
    {
        Id = 1,
        Name = "Alice",
        Orders = new List<Order>
        {
            new Order { Id = 1, ProductName = "Widget", Price = 10.0m },
            new Order { Id = 2, ProductName = "Gadget", Price = 5.0m },
            new Order { Id = 3, ProductName = "Thingamabob", Price = 15.0m }
        }
    },
    new Customer
    {
        Id = 2,
        Name = "Bob",
        Orders = new List<Order>
        {
            new Order { Id = 1, ProductName = "Widget", Price = 10.0m },
            new Order { Id = 2, ProductName = "Doodad", Price = 7.5m }
        }
    }
};

var orderSummaries = customers.SelectMany(
    customer => customer.Orders,
    (customer, order) => new
    {
        CustomerName = customer.Name,
        OrderId = order.Id,
        ProductName = order.ProductName,
        TotalPrice = order.Price
    }
);

foreach (var summary in orderSummaries)
{
    Console.WriteLine($"Customer: {summary.CustomerName}, Order ID: {summary.OrderId}, Product: {summary.ProductName}, Price: {summary.TotalPrice:C}");
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}