// See https://aka.ms/new-console-template for more information
using GoodCar.Entities;
using GoodCar.Interfaces;
using GoodCar.Services;

Console.WriteLine("Hello, World!");

ICar car = new Car() { Brand = "VW", Model = "Polo", ConstructionYear = 2004 };
ICar testCarIbj = new MockCar();


ICarVersion2 carVersion2 = new CarVersion2();


ICarService service = new CarService();
service.Repair(car);
service.Repair(testCarIbj);
service.Repair(carVersion2); //intern wird nur das ICar verwendet




