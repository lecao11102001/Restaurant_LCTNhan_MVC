using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Data;
using Restaurant_MVC.Models;
using Restaurant_MVC.Models.SharedDataDictionary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbDSN")));

builder.Services.AddSingleton<IDataSharingService, DataSharingService>();
builder.Services.AddTransient<ISpecialties, SpecialtiesService>();
builder.Services.AddTransient<IHome, HomeService>();
builder.Services.AddTransient<IReservation, ReservationService>();

//builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();