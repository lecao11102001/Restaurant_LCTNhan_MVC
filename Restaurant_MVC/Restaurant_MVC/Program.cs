using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.Entities;
using Restaurant_MVC.Models.Mapping;
using Restaurant_MVC.Models.SharedDataDictionary;
using Restaurant_MVC.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbDSN")));

//
builder.Services.AddSingleton<IDataSharingService, DataSharingService>();
builder.Services.AddTransient<ISpecialties, SpecialtiesService>();
builder.Services.AddTransient<IHome, HomeService>();
builder.Services.AddTransient<IReservation, ReservationService>();
builder.Services.AddTransient<IContactUs, ContactUsService>();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Reservation",
        areaName: "Reservation",
        pattern: "Reservation/{controller=Reservation}/{action=Index}"
    );
    endpoints.MapAreaControllerRoute(
        name: "ContactUs",
        areaName: "ContactUs",
        pattern: "ContactUs/{controller=ContactUs}/{action=Index}"
    );
    endpoints.MapAreaControllerRoute(
        name: "Stories",
        areaName: "Stories",
        pattern: "Stories/{controller=Stories}/{action=Index}"
    );
    endpoints.MapAreaControllerRoute(
        name: "Specialties",
        areaName: "Specialties",
        pattern: "Specialties/{controller=Specialties}/{action=Index}"
    );
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller}/{action}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

});

app.Run();
