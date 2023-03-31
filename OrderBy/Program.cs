using System;
using System.Collections.Generic;
using System.Linq;

var oneThousandPets = Enumerable.Range(0, 1000).ToList().Select(_ => new PetGenerator().GeneratePet());

var orderByOwnerThenByNameDog = oneThousandPets
    .Where(pet => pet.Category == Category.Dog)
    .OrderBy(pet => pet.PetOwner)
    .ThenBy(pet => pet.Name);

var ordenation = oneThousandPets.OrderBy(p => p, new PetNameOwnerComparer());
    
//print all the dogs
foreach (var pet in orderByOwnerThenByNameDog)
{
    Console.WriteLine(pet.ToString());
}

var thenFirstNumbers = new List<int>();
//add 10 first numbers
for (int i = 0; i < 10; i++)
{
    thenFirstNumbers.Add(i);
}

//OrderByDescending even numbers then odd numbers
var thenFirstNumbersOrdered = thenFirstNumbers
    .OrderByDescending(number => number % 2 == 0)
    .ThenByDescending(number => number);

//print all the numbers
foreach (var number in thenFirstNumbersOrdered)
{
    Console.WriteLine(number);
}
