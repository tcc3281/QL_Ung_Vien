using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Data;

var builder = WebApplication.CreateBuilder(args);

//dang ki db context
builder.Services.AddDbContext<QL_Ung_VienContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("QL_Ung_VienContext")));


// Add services to the container.
builder.Services.AddControllersWithViews();

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
