using Microsoft.EntityFrameworkCore;
using MySchoolAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 2, 0))));

builder.Services.AddControllersWithViews(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; //  http://localhost:5270/swagger
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Teacher}/{action=List}/{id?}");

app.Run();
