var builder = WebApplication.CreateBuilder(args);

// เปิด CORS ให้ Frontend (Angular) เรียก API ได้
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// ตัวนับ (เก็บในหน่วยความจำ — รีสตาร์ท container แล้วรีเซ็ต)
var count = 0;
app.MapGet("/api/count", () => new { count = ++count });      // ปุ่ม Count (+1)
app.MapGet("/api/discount", () => new { count = --count });   // ปุ่ม Discount (-1)

app.MapGet("/", () => "Counter API — ลอง /api/count หรือ /api/discount");

var port = Environment
  .GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");
