using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using GamePlatform.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()    // Allow requests from any origin
            .AllowAnyMethod()    // Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader();   // Allow any headers in the request
    });
});

var app = builder.Build();

app.UseDefaultFiles(); 
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        logger.LogInformation("Migrations done");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error with init database");
        throw;
    }
}

app.UseCors("AllowAllOrigins");  // Apply the CORS policy globally

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
