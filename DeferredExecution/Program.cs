//generate list string of random animals
var animals = new List<string> { "dog", "cat", "bird", "fish", "snake", "lizard", "frog", "horse", "cow", "pig" };

var animalsWithD = animals.Where(w =>
{
    Console.WriteLine("Checkin animal" + w);
    return w.Contains("d");
});

foreach (var animal in animalsWithD)
{
    Console.WriteLine(animal);
}