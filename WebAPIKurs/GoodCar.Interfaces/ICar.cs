namespace GoodCar.Interfaces
{
    public interface ICar
    {
        string Brand { get; set; }
        string Model { get; set; }

        int ConstructionYear { get; set; }
    }


    public interface ICarVersion2 : ICar
    {
        string Color { get; set; }
        bool HatAnhaengerKupplung { get; set; }
    }
}