using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Any.Classes;

var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var isThereAnyEvenNumberIsThisCollection = numbers.Any(n => n % 2 == 0);

var isThereAnyNegativeNumber = numbers.Any(n => n < 0);
Console.WriteLine(isThereAnyNegativeNumber);

if (isThereAnyEvenNumberIsThisCollection)
{
    Console.WriteLine("There is at least one even number in this collection");
}
else
{
    Console.WriteLine("There is no even number in this collection");
}

//Print line
Console.WriteLine("====================================");

var arrayOf10Pets = new Pets[10];
arrayOf10Pets[0] = new Pets { Name = "Fido", Age = 3, Type = EType.Dog };
arrayOf10Pets[1] = new Pets { Name = "Mittens", Age = 2, Type = EType.Cat };
arrayOf10Pets[2] = new Pets { Name = "Fluffy", Age = 1, Type = EType.Bird };
arrayOf10Pets[3] = new Pets { Name = "Bubbles", Age = 4, Type = EType.Fish };
arrayOf10Pets[4] = new Pets { Name = "Spike", Age = 5, Type = EType.Reptile };
arrayOf10Pets[5] = new Pets { Name = "Rover", Age = 6, Type = EType.Dog };
arrayOf10Pets[6] = new Pets { Name = "Scooter", Age = 7, Type = EType.Dog };

var isThereAnyPet = arrayOf10Pets.Any();
Console.WriteLine(isThereAnyPet);

var isThereAnyRover = arrayOf10Pets.Any(p => p.Name == "Rover");
Console.WriteLine(isThereAnyRover);

var isThereAnyFish = arrayOf10Pets.Any(p => p.Type == EType.Fish);
Console.WriteLine(isThereAnyFish);

