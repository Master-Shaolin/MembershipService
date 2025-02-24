using ClubMembership_Memberships.Infrastructure.Persistence;
using ClubMembership_Memberships.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Add this line to define 'configuration'

// Load environment variables from .env
DotEnv.Load();
var Environment = DotEnv.Read();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(Environment["DB_CONNECTION_STRING"])); // Fix the 'configuration' error

// Register application services (repositories + services)
builder.Services.AddApplicationServices();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    try
    {
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
    app.UseExceptionHandler("/error"); // Handle errors in production
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();