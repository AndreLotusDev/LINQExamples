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
    public string PetOwner { get; set; }

    public Pet(Category category, string name, float weight, string petOwner)
    {
        Category = category;
        Name = name;
        Weight = weight;
        PetOwner = petOwner;
    }
    
    //tostring with all fields
    public override string ToString()
    {
        return $"Category: {Category}, Name: {Name}, Weight: {Weight}, PetOwner: {PetOwner}";
    }
}


public class PetGenerator
{
    private readonly string[] Names = { "Buddy", "Max", "Charlie", "Lucy", "Daisy", "Rocky", "Molly", "Bailey", "Sadie", "Jack" };
    private readonly string[] Owners = { "Alice", "Bob", "Charlie", "Dave", "Emma", "Frank", "Grace", "Henry", "Isabella", "Jack" };

    private readonly Random random = new Random();

    public Pet GeneratePet()
    {
        Category category = (Category)random.Next(0, 4);
        string name = Names[random.Next(0, Names.Length)];
        float weight = (float)random.NextDouble() * 19.0f + 1.0f;
        string petOwner = Owners[random.Next(0, Owners.Length)];
        return new Pet(category, name, weight, petOwner);
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

public interface IPetNameOwnerComparer : IComparer<Pet>
{
}

public class PetNameOwnerComparer : IPetNameOwnerComparer
{
    public int Compare(Pet x, Pet y)
    {
        int result = x.Name.CompareTo(y.Name);

        if (result == 0)
        {
            result = x.PetOwner.CompareTo(y.PetOwner);
        }

        return result;
    }
}