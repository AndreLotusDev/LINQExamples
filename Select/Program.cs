
var people = new List<Person>
{
    new Person { Id = 1, FirstName = "Alice", LastName = "Anderson", Age = 27, Email = "alice@example.com", PhoneNumber = "555-1234" },
    new Person { Id = 2, FirstName = "Bob", LastName = "Brown", Age = 35, Email = "bob@example.com", PhoneNumber = "555-5678" },
    new Person { Id = 3, FirstName = "Charlie", LastName = "Chaplin", Age = 62, Email = "charlie@example.com", PhoneNumber = "555-9012" }
};

var personSummaries = people.Select(p => new { p.Id, p.FirstName, p.LastName });

foreach (var summary in personSummaries)
{
    Console.WriteLine($"ID: {summary.Id}, Name: {summary.FirstName} {summary.LastName}");
}

foreach (var summary in personSummaries)
{
    Console.WriteLine($"ID: {summary.Id}, Name: {summary.FirstName} {summary.LastName}");
}

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}