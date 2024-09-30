using NotificationProgect.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NotificationProgect.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ToDoDbContext>((provider, options) =>
{
    options.UseSqlServer("Data Source=(local);Initial Catalog=ToDoManagement;Persist Security Info=True;User ID=test;Password=test;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True");
});

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification Progect API", Version = "v1" });

});


builder.Services.AddTransient<IToDoRepository, ToDoRepository>();

builder.Services.AddTransient<Func<IToDoRepository>>(provider => () => provider.CreateScope().
ServiceProvider.GetRequiredService<IToDoRepository>());

builder.Services.AddTransient<ToDoService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var dbContext = scope.ServiceProvider.GetService<ToDoDbContext>();
dbContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
