using Microsoft.EntityFrameworkCore;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. ربط قاعدة البيانات
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. تسجيل الخدمة الإحصائية
builder.Services.AddScoped<DashboardService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. تفعيل الـ CORS للاتصال بالواجهة
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 4. توليد قاعدة البيانات والجداول تلقائياً عند أول تشغيل
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();