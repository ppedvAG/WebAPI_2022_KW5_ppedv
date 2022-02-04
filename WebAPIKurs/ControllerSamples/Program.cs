using ControllerSamples.Data;
using ControllerSamples.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiContrib.Core.Formatter.Csv;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
{
    //options.UseInMemoryDatabase("MovieDb");
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext"));
});



// Add services to the container.

builder.Services.AddControllers(options =>
{
    //options.InputFormatters.Insert(0, new VCardInputFormatter());
    //options.OutputFormatters.Insert(0, new VCardOutputFormatter());
}) //per Default -> JSON (text/json) (application/json) -> MIME-Standard
    .AddXmlSerializerFormatters() //XML -> text/xml / application/xml
    .AddCsvSerializerFormatters();//CSV -> text/CSV

builder.Services.AddSingleton<IContactRepository, ContactRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using ( IServiceScope scope = app.Services.CreateScope())
{
    DataSeed.Initialize(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
