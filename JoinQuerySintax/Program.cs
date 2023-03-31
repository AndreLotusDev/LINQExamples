var petOwners = new List<PetOwner>
{
    new PetOwner { Id = 1, Name = "John" },
    new PetOwner { Id = 2, Name = "Jane" },
    new PetOwner { Id = 3, Name = "Bob" }
};

var pets = new List<Pet>
{
    new Pet { Id = 1, Name = "Fluffy", OwnerId = 1 },
    new Pet { Id = 2, Name = "Max", OwnerId = 2 },
    new Pet { Id = 3, Name = "Buddy", OwnerId = 3 }
};

var appointments = new List<Appointment>
{
    new Appointment { Id = 1, PetId = 1, AppointmentDate = DateTime.Now.AddDays(1) },
    new Appointment { Id = 2, PetId = 2, AppointmentDate = DateTime.Now.AddDays(2) },
    new Appointment { Id = 3, PetId = 3, AppointmentDate = DateTime.Now.AddDays(3) }
};

var veterinaryStores = new List<VeterinaryStore>
{
    new VeterinaryStore { Id = 1, Name = "ABC Veterinary Clinic", AppointmentId = 1 },
    new VeterinaryStore { Id = 2, Name = "XYZ Animal Hospital", AppointmentId = 2 }
};

var query = petOwners
    .Join(pets, petOwner => petOwner.Id, pet => pet.OwnerId, (petOwner, pet) => new { petOwner, pet })
    .Join(appointments, temp => temp.pet.Id, appointment => appointment.PetId, (temp, appointment) => new { temp.petOwner, temp.pet, appointment })
    .Join(veterinaryStores, temp => temp.appointment.Id, veterinaryStore => veterinaryStore.AppointmentId, (temp, veterinaryStore) => new { temp.petOwner, temp.pet, temp.appointment, veterinaryStore })
    .Select(result => new
    {
        OwnerName = result.petOwner.Name,
        PetName = result.pet.Name,
        AppointmentDate = result.appointment.AppointmentDate,
        VeterinaryStoreName = result.veterinaryStore.Name
    });

Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25}", "Owner", "Pet", "Appointment Date", "Veterinary Store");
Console.WriteLine(new string('-', 80));

foreach (var item in query)
{
    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25}", item.OwnerName, item.PetName, item.AppointmentDate.ToString("MM/dd/yyyy"), item.VeterinaryStoreName);
}

class PetOwner
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int OwnerId { get; set; }
}

class Appointment
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public DateTime AppointmentDate { get; set; }
}

class VeterinaryStore
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AppointmentId { get; set; }
}
