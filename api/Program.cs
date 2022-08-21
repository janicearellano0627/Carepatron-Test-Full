using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Repository;
using AutoMapper;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// cors
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .Build());
});

//Data Seeder
services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
services.AddScoped<DataSeeder>();

services.AddScoped<IClientRepository, ClientRepository>();
services.AddMediatR(typeof(ClientRepository).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();


using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    dataSeeder.Seed();
}

app.Run();
