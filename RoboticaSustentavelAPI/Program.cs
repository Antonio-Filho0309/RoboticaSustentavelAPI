using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Repositories;
using RoboticaSustentavelAPI.Repositories;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Reflection;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

Env.Load();
var defaultConnection = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
builder.Configuration["ConnectionStrings:DefaultConnection"] = defaultConnection;

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repositorio
builder.Services.AddScoped<IComputerRepository,ComputerRepository>();
builder.Services.AddScoped<IItemDonationRepository, ItemDonationRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IItemSaleRepository, ItemSaleRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

//Service
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IItemDonationService, ItemDonationService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<ISalesServices , SaleService>();
builder.Services.AddScoped<IItemSaleService, ItemSaleService>();


builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "RoboticaSustentavelAPI",
        Description = "Projeto de locação e venda de computadores em C#",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Antonio José dos Santos Filho",
            Email = "antoniofilho030905@gmail.com",
            Url = new Uri("https://scintillating-biscotti-bbc86f.netlify.app")
        },
        License = new OpenApiLicense
        {
            Name = "Projeto Robotica Sustentavel License",
            Url = new Uri("https://mit.edu")
        },
    });
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    options.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();