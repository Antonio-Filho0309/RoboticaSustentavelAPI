using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Repositories;
using RoboticaSustentavelAPI.Repositories;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services;
using RoboticaSustentavelAPI.Services.Interfaces;
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

builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost8080", builder => {
        builder.WithOrigins("http://localhost:8080")
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
builder.WebHost.UseUrls("http://0.0.0.0:80");
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();