/*var builder = WebApplication.CreateBuilder(args);

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
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();*/

using MyConsoleApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // changed
builder.Services.AddSingleton<MedicineService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();   // important
app.UseStaticFiles();    // important

app.UseRouting();

app.UseAuthorization();

app.MapControllers();    // important

app.Run();