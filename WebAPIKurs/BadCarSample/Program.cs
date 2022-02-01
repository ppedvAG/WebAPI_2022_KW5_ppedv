
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//Feste Kopplung sind der Grund, weshalb Programme mit Zeit teurer werden 

//Programmierer A (5 Tage) 
public class BadCar
{
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int ConstructionYear { get; set; }   
}


//Programmierer B (3 Tage) -> Programmierer B kann erst an Tag 5 oder 6 einsteigen (weil BadCar erst dann als Parameter verwendbar)
public class BadCarService
{
    public void Repair(BadCar car)
    {
        //Mach was
    }
}