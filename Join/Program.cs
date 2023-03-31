var customers = new List<Customer>
{
    new Customer { Id = 1, Name = "John" },
    new Customer { Id = 2, Name = "Jane" },
    new Customer { Id = 3, Name = "Bob" }
};

var orders = new List<Order>
{
    new Order { Id = 1, OrderDate = new DateTime(2022, 1, 1), CustomerId = 1 },
    new Order { Id = 2, OrderDate = new DateTime(2022, 2, 1), CustomerId = 2 },
    new Order { Id = 3, OrderDate = new DateTime(2022, 3, 1), CustomerId = 3 }
};

var orderItems = new List<OrderItem>
{
    new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 2 },
    new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1 },
    new OrderItem { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1 },
    new OrderItem { Id = 4, OrderId = 2, ProductId = 3, Quantity = 4 },
    new OrderItem { Id = 5, OrderId = 3, ProductId = 1, Quantity = 1 },
    new OrderItem { Id = 6, OrderId = 3, ProductId = 3, Quantity = 2 },
};

var products = new List<Product>
{
    new Product { Id = 1, Name = "Product 1", Price = 10.0m },
    new Product { Id = 2, Name = "Product 2", Price = 20.0m },
    new Product { Id = 3, Name = "Product 3", Price = 30.0m }
};

var query = from customer in customers
    join order in orders on customer.Id equals order.CustomerId
    join orderItem in orderItems on order.Id equals orderItem.OrderId
    join product in products on orderItem.ProductId equals product.Id
    select new
    {
        CustomerName = customer.Name,
        OrderDate = order.OrderDate,
        ProductName = product.Name,
        OrderItemQuantity = orderItem.Quantity,
        ProductPrice = product.Price
    };

foreach (var item in query)
{
    Console.WriteLine($"Customer: {item.CustomerName}, Order Date: {item.OrderDate.ToShortDateString()}, Product: {item.ProductName}, Quantity: {item.OrderItemQuantity}, Price: {item.ProductPrice:C}");
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}