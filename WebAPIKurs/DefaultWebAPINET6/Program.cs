//WebApplication hat eine Factory - Methode -> WebApplicationBuilder 
using DefaultWebAPINET6.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //appsetting werden gelesen


//webApplicationBuilder ist f�r die Initialisierung meiner Application verantwortlich. 

#region Startup->ConfigureServices
// Add services to the container.
builder.Host.ConfigureAppConfiguration(config =>
{
    //config.AddIniFile ->  zus�tzliche Ini Files hinzuf�gen
    //config.AddXmlFile ->  zus�tzliche Xml Files hinzuf�gen
    config.AddJsonFile("MyArray.json"); //-> zus�tzliche JSON-File hinzuf�gen
});



//Alle Konfigurationen mit unterschiedlichen Quellen werden alle in IConfiguration geladen, mithilfe des ConfigurationManagers

//Frage-> Unterschied ziwschen builder.Configuration.AddIniFile("abc.ini"); UND builder.Host.ConfigureAppConfiguration(config =>
//builder.Configuration.AddIniFile("abc.ini");
//builder.Configuration.AddXmlFile("abc.xml");
//builder.Configuration.AddJsonFile("abc.json");

//Daten die sich in IConfiguration befinden, k�nnen mit einem Model gebunden werden
//-> siehe Beispiel: builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position));

builder.Services.Configure<MyArray>(builder.Configuration.GetSection("array"));


//AddController = Verwenden WebAPI 
builder.Services.AddControllers(); //-> ben�tigen ein Controllers-Verzeichnis

//MVC 
//builder.Services.AddControllersWithViews();//->ben�tigt ein Controller-Verzeichnis + Views Verzeichnis + Models -Verzeichnis

//Razor Pages
/*builder.Services.AddRazorPages();*/ // ben�tigt ein Pages-Verzeichnis

//MVC -> AddControllersWithViews + AddRazorPages
//builder.Services.AddMvc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion
WebApplication? app = builder.Build();

#region Startup -> Configure-Methode
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//else if(app.Environment.IsProduction())
//{
//    app.UseHsts(); //Aufsatz fpr HTTPS Protocol
//}


//F�r Alle Instanzen
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion
app.Run();
