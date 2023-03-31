List<Animal> animals = new List<Animal> { new Dog(), new Cat(), new Bird(), new Dog() };

// Filter the animals list to get only Dog objects
var dogs = animals.OfType<Dog>();

// Display the Dog objects
foreach (var dog in dogs)
{
    Console.WriteLine(dog.GetType().Name);
}

class Animal { }
class Dog : Animal { }
class Cat : Animal { }
class Bird : Animal { }