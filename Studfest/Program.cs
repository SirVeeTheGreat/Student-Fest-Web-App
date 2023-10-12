using Microsoft.EntityFrameworkCore;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Repository;
using Studfest.App_Start;
using Microsoft.AspNetCore.Builder;
using Studfest.Repository.Account;
using Studfest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<StudentFestDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});




builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IVendor, VendorRepo>();
builder.Services.AddScoped<AccountRepo>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/LogOut";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });






builder.Services.AddHttpContextAccessor(); 
builder.Services.AddSession();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
