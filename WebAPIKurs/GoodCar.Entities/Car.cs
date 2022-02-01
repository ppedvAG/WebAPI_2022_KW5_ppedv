//#nullable disable
using GoodCar.Interfaces;

namespace GoodCar.Entities
{
    public class Car : ICar
    {
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int ConstructionYear { get; set; }
    }




    //Mithilfe von Interface sind die Klassen testbar geworden 
    public class MockCar : ICar
    {
        public string Brand { get; set; } = "BMW";
        public string Model { get; set; } = "7er";
        public int ConstructionYear { get; set; } = 2015;
    }


    public class CarVersion2 : ICarVersion2
    {
        public string Color { get; set; }
        public bool HatAnhaengerKupplung { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
    }
}