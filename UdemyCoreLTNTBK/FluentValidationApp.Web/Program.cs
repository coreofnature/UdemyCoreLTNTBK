using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationApp.Web.FluentValidators;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    // Validate child properties and root collection elements
    opt.ImplicitlyValidateChildProperties = true;
    opt.ImplicitlyValidateRootCollectionElements = true;
    // Automatic registration of validators in assembly
    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
