using Day1WebApi.Data;
using Day1WebApi.ExceptionHandlers;
using Day1WebApi.Filters;
using Day1WebApi.Interfaces;
using Day1WebApi.Middlewares;
using Day1WebApi.Services;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlite<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddControllers(c =>
{
    c.Filters.Add<WrapResponseFilter>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.RegisterDIService()
    .RegisterSwagger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<GlobalExceptionHandlers>();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddDevAppDependency();
}


app.MapGet("/health", () => Results.Ok("Healthy"));


app.UseAuthorization();
app.UseMiddleware<SampleMiddleware>();
app.UseExceptionHandler("/error");

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();
