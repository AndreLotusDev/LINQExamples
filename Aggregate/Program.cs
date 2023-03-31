List<decimal> sales = new List<decimal> { 100.50m, 55.25m, 200.75m, 75.60m };

var result = sales.Aggregate(
    new { Total = 0m, Count = 0 },
    (acc, s) => new { Total = acc.Total + s, Count = acc.Count + 1 },
    acc => new { Total = acc.Total, Average = acc.Total / acc.Count }
);

Console.WriteLine(result.Total);