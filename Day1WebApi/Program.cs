using Day1WebApi.ClaimsPrincipalFactory;
using Day1WebApi.Data;
using Day1WebApi.ExceptionHandlers;
using Day1WebApi.Filters;
using Day1WebApi.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlite<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(c =>
{
    c.Filters.Add<WrapResponseFilter>();

    // Jika bukan staging, maka tambahkan otorisasi global
    // Jika staging dan DisableGlobalAuthorize = true, maka tidak perlu otorisasi global
    if (builder.Environment.IsProduction()
        || builder.Configuration["DisableGlobalAuthorize"] != "true")
    {
        // Otorisasi global, semua endpoint akan memerlukan otorisasi
        c.Filters.Add(new AuthorizeFilter());
    }
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.RegisterDIService()
    .RegisterSwagger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<GlobalExceptionHandlers>();
builder.Services.AddIdentityApiEndpoints<Pegawai>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddClaimsPrincipalFactory<PegawaiClaimsPrincipalFactory>();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("SupervisorOnly", policy => policy.RequireClaim("jabatan", "Supervisor"));

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.AddDevAppDependency();
}


app.MapGet("/health", () => Results.Ok("Healthy"));


app.UseAuthorization();
app.UseMiddleware<SampleMiddleware>();
app.UseExceptionHandler("/error");

app.MapControllers();
app.MapIdentityApi<Pegawai>();

app.UseCors("AllowAll");

app.Run();
