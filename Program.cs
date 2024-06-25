using farmHub.Models.Datacontext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Npgsql and DbContext services
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // Use Razor Pages routing

app.MapControllerRoute(
    name: "default",

pattern: "{controller=Home}/{action=index}/{id?}");

//pattern: "{controller=DealerSignUp}/{action=Create}/{id?}");

//pattern: "{controller=DealerTesting}/{action=Create}/{id?}");
//pattern: "{controller=CollectionsEntities}/{action=Create}");
//pattern: "{controller=FarmerTesting}/{action=Create}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern:"{controller=DealerTesting}/{action=SignIn}");
    //pattern: "{controller=CollectionsEntites}/{action=Create}/{id}");

app.Run();
