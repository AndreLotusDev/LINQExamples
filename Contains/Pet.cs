using System;

public enum Category
{
    Dog,
    Cat,
    Fish,
    Bird
}

public class Pet 
{
    public Category Category { get; set; }
    public string Name { get; set; }
    public float Weight { get; set; }

    public Pet(Category category, string name, float weight)
    {
        Category = category;
        Name = name;
        Weight = weight;
    }
}

public class PetGenerator
{
    private readonly string[] Names = { "Buddy", "Max", "Charlie", "Lucy", "Daisy", "Rocky", "Molly", "Bailey", "Sadie", "Jack" };

    private readonly Random random = new Random();

    public Pet GeneratePet()
    {
        Category category = (Category)random.Next(0, 4);
        string name = Names[random.Next(0, Names.Length)];
        float weight = (float)random.NextDouble() * 19.0f + 1.0f;
        return new Pet(category, name, weight);
    }
}

public class PetNameComparer : IEqualityComparer<Pet>
{
    public bool Equals(Pet x, Pet y)
    {
        if (x == null || y == null)
        {
            return false;
        }
        return x.Name == y.Name;
    }

    public int GetHashCode(Pet pet)
    {
        return pet.Name.GetHashCode();
    }
}