using ConfigurationSamples.Models;

var builder = WebApplication.CreateBuilder(args); //IConfiguration -> beinhaltet ALLE Configuration aus mehreren Konfigquellen


builder.Services.PostConfigure<PositionOptions>(myOptions =>
{
    myOptions.Name = "Donald Duck";
    myOptions.Title = "Dr.";
});

//Hier liegen die Konfigurationen in IConfiguration: 
//builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position));


//Default Konfigurations-


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
