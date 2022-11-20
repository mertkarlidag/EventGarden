using EventGarden.BLL.Concretes;
using EventGarden.BLL.Interfaces;
using EventGarden.BLL.Mapping;
using EventGarden.BLL.ValidationRules;
using EventGarden.DAL.Contexts;
using EventGarden.DAL.UnitOfWork;
using EventGarden.DTOs.CategoryDTOs;
using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.Entities.Entitity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("local"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });


});

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IuOW, uOW>();

builder.Services.AddScoped<IEtkinlikService, EtkinlikService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBasketEventService, BasketEventService>();

builder.Services.AddTransient<IValidator<EtkinlikCreateDTO>, EtkinlikCreateDTOValidator>();
builder.Services.AddTransient<IValidator<EtkinlikUpdateDTO>, EtkinlikUpdateDTOValidator>();
builder.Services.AddTransient < IValidator<CategoryCreateDTO>, CategoryCreateDTOValidator>();
builder.Services.AddTransient<IValidator<CategoryUpdateDTO>, CategoryUpdateDTOValidator>();






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

app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
