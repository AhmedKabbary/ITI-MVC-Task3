using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/middleware")
    {
        await context.Response.WriteAsync("Hello from middleware");
    }
    else
    {
        await next();
    }
});

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();