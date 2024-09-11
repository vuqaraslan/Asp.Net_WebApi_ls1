using Microsoft.EntityFrameworkCore;
using WebApi_LS1_HW.Data;
using WebApi_LS1_HW.Repositories;
using WebApi_LS1_HW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ShoppingDbContext>(opt => opt.UseSqlServer(connection));

builder.Services.AddScoped<IProductRepository,EFProductRepository>();
builder.Services.AddScoped<ICustomerRepository,EFCustomerRepository>();
builder.Services.AddScoped<IOrderRepository,EFOrderRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IOrderService,OrderService>();


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
