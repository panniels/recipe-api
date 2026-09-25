using Microsoft.EntityFrameworkCore;

using RecipeApi.Data;
using RecipeApi.Models;
using RecipeApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<RecipeDBContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

builder.Services.AddScoped<RecipeService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

