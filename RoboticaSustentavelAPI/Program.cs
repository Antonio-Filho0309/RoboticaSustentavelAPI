using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var defaultConnection = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
builder.Configuration["ConnectionStrings:DefaultConnection"] = defaultConnection;

//builder.Services.AddDbContext<DataContext>(options =>   options.UseNpgsql(builder.Configuration.GetConnectionString(defaultConnection)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();