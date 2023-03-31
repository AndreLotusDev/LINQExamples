//Print line

using All.Classes;

Console.WriteLine("====================================");

var arrayOf10Pets = new Pets[10];
arrayOf10Pets[0] = new Pets { Name = "Fido", Age = 3, Type = EType.Dog };
arrayOf10Pets[1] = new Pets { Name = "Mittens", Age = 2, Type = EType.Cat };
arrayOf10Pets[2] = new Pets { Name = "Fluffy", Age = 1, Type = EType.Bird };
arrayOf10Pets[3] = new Pets { Name = "Bubbles", Age = 4, Type = EType.Fish };
arrayOf10Pets[4] = new Pets { Name = "Spike", Age = 5, Type = EType.Reptile };
arrayOf10Pets[5] = new Pets { Name = "Rover", Age = 6, Type = EType.Dog };
arrayOf10Pets[6] = new Pets { Name = "Scooter", Age = 7, Type = EType.Dog };

var allPetsAreDog = arrayOf10Pets.All(pet => pet.Type == EType.Dog);
Console.WriteLine($"All pets are dogs: {allPetsAreDog}");

var allPetsAreCalledSpike = arrayOf10Pets.All(pet => pet.Name == "Spike");
Console.WriteLine($"All pets are called Spike: {allPetsAreCalledSpike}");