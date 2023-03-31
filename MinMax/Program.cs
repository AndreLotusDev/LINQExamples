var oneHundredPets = Enumerable.Range(1, 100).Select(i => new PetGenerator().GeneratePet());

var maxWeightPet = oneHundredPets.Max();
Console.WriteLine($"Max weight pet: {maxWeightPet}");

var minWeightPet = oneHundredPets.Min();
Console.WriteLine($"Min weight pet: {minWeightPet}");