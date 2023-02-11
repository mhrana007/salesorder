using BLL.Interface;
using BLL.Services;
using DAL.DataContext;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Database Connection
//builder.Services.AddDbContextFactory<DatabaseContext>(options =>
//{
//    // var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()
//    options.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>().Database.EnsureCreated();
//});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
//builder.Services.AddDbContextFactory<DatabaseContext>(options => 
//{
//    // var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()
//    options.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>().Database.EnsureCreated();
// });
//Lifetime service register
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IWindowRepository, WindowRepository>();
builder.Services.AddTransient<IElementRepository, ElementRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IWindowService, WindowService>();
builder.Services.AddTransient<IElementService, ElementService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
