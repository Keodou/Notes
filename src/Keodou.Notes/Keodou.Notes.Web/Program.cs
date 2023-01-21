var builder = WebApplication.CreateBuilder(args);

// Service container
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
