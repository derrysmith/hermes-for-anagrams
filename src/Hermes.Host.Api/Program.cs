using Hermes.Core.Anagrams.Services;
using Hermes.Data.Anagrams.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Hermes.Core
builder.Services.TryAddSingleton<IAnagramService, AnagramService>();

// Hermes.Data
builder.Services.TryAddSingleton<IAnagramServiceProvider, EmbeddedResourceAnagramServiceProvider>();

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