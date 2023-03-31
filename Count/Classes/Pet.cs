namespace ConsoleApp1Count.Classes;

public class Pets
{
    public string Name { get; set; }
    public int Age { get; set; }
    public EType Type { get; set; }
}

public enum EType
{
    Dog,
    Cat,
    Bird,
    Fish,
    Reptile,
    Other
}