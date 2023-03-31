List<Pet> pets = new();

for (int i = 0; i < 100; i++)
{
    pets.Add(new PetGenerator().GeneratePet());
}

var pet = new Pet(Category.Dog, "Buddy", 10.0f);

var exists = pets.Contains(pet, new PetNameComparer());

Console.WriteLine(exists);