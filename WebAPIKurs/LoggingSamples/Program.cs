using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region IServiceCollection wird befüllt -> builder.Services
builder.Services.AddControllers();


builder.Services.AddControllersWithViews(); //MVC -> Controllers + Views
builder.Services.AddRazorPages(); // RP -> Pages
builder.Services.AddMvc(); //AddControllersWithViews + AddRazorPages

//Beispiel1 
//builder.Host.UseSerilog((ctx, lc) => lc 
//.WriteTo.Console()
//.WriteTo.Seq("http://localhost:5341"));

IConfigurationRoot configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configurationRoot)
    .CreateLogger();

builder.Host.UseSerilog();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region 2ter PArt der Startup
var app = builder.Build(); //Initialsierungphase ist mit Build abgeschlossen 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
