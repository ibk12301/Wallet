using Microsoft.EntityFrameworkCore;
using SmtWallet.Web.Data;
using SmtWallet.Web.Data.Entities;
using SmtWallet.Web.Data.Repositories;
using SmtWallet.Web.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlServer("Server=JC_PHARGUZIN; Database=SmtWalletDb; Trusted_Connection=True;"));

builder.Services.AddScoped<IRepository<Customer, Guid>, ClientRepository>();
builder.Services.AddScoped<IRepository<Country, Guid>, NationalityRepository>();

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

var serviceProvider = app.Services.GetRequiredService<IServiceProvider>(); 
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await SeedHelper.InitializeData(context);

}

app.Run();
