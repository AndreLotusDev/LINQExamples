var orders = new List<Order>
{
    new Order { Id = 1, Items = new List<OrderItem> { new OrderItem { ProductId = 1, Quantity = 2 }, new OrderItem { ProductId = 2, Quantity = 1 } } },
    new Order { Id = 2, Items = new List<OrderItem> { new OrderItem { ProductId = 2, Quantity = 1 }, new OrderItem { ProductId = 3, Quantity = 4 } } },
    new Order { Id = 3, Items = new List<OrderItem> { new OrderItem { ProductId = 1, Quantity = 1 }, new OrderItem { ProductId = 3, Quantity = 2 } } },
};

var uniqueProducts = orders.SelectMany(order => order.Items)
    .GroupBy(item => item.ProductId)
    .Select(group => new {
        Id = group.Key,
        Name = group.First().Name,
        Price = group.First().Price
    })
    .ToList();

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; }
}