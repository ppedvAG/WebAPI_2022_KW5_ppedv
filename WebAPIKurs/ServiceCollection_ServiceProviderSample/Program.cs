using GoodCar.Entities;
using GoodCar.Interfaces;
using Microsoft.Extensions.DependencyInjection;


//Seperation of Concerne -> 

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddMockCar();
serviceCollection.AddScoped<ICar, Car>();



//Initialisierungphase ist mit diesem Befehl zu Ende und wir können den IOC Container nun verwenden
IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


//2 Varianten um eine Instanz aus unserem IOC Container zu lesen

//GetService -> wenn Eintrag ICar nicht gefunden wird -> wird Null zurück gegeben
ICar? mockCar1 = serviceProvider.GetService<ICar>();

//GetRequiredService ->  wenn Eintrag ICar nicht gefunden wird -> eine Exception wird geschmissen
ICar mockCar2 = serviceProvider.GetRequiredService<ICar>();


public static class CarExtensionClass
{
    public static void AddMockCar(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICar, MockCar>();
    }
}