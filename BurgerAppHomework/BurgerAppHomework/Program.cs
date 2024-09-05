using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services;
using DataAccess.Interfaces;
using Domain;
using DataAccess.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with the connection string
string connectionString = builder.Configuration.GetConnectionString("BurgerAppConnectionString");
builder.Services.AddDbContext<BurgerAppDbContext>(options => options.UseSqlServer(connectionString));

// Register repository services
builder.Services.AddScoped<IRepository<Burger>, BurgerRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

// Register application services
builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddScoped<IBurgerService, BurgerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BurgerApp}/{action=Index}/{id?}");

app.Run();
