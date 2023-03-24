using Example.Identity.Context;
using Example.Identity.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{

    // KAYITTAKI ZORUNLU ÝÞLEMLERÝ ÝPTAL ET
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 1;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    //opt.SignIn.RequireConfirmedPhoneNumber = true;// mail veya tel onayi alýnsýn mi?

}).AddEntityFrameworkStores<ExampleContext>();

builder.Services.AddDbContext<ExampleContext>(opt =>
{
    opt.UseSqlServer("Data Source=AYHAN\\AYHAN;Password=sifre123@;User ID=sa;Initial Catalog=TodoExampleDb1;TrustServerCertificate=True;");
    opt.LogTo(Console.WriteLine, LogLevel.Information);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();


app.Run();
