using Ecommerce.API;
using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Repositories.Interfaces;
using Ecommerce.Infrastructure.DataAccess;
using Ecommerce.Infrastructure.DependencyInjection;
using Hangfire;
using Hangfire.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices();

// Configure Hangfire for jobs scheduling.
builder.Services.AddHangfire(config =>
    config.UseEFCoreStorage(options =>
        options.UseInMemoryDatabase("EcommerceDb")) // Usa o mesmo banco InMemory já configurado
);
builder.Services.AddHangfireServer();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IJobScheduler, HangfireJobScheduler>();

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
