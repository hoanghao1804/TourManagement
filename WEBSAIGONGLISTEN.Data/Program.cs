using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEBSAIGONGLISTEN.Models;
using WEBSAIGONGLISTEN.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Thêm services cần thiết
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Khởi tạo dữ liệu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await DbInitializer.InitializeAsync(services);
        Console.WriteLine("Database đã được khởi tạo thành công!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Lỗi khi khởi tạo database: {ex.Message}");
    }
}

app.MapGet("/", () => "Database initialization completed!");

app.Run();
