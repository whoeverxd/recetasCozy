using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<JwtService>();

// Configurar JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true
    };
});
//test db connection route
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// /testdb


var app = builder.Build();
app.MapGet("/testdb", async (DbContext dbContext) =>
{
    try
    {
        // Esto solo intenta conectarse a la DB
        bool canConnect = await dbContext.Database.CanConnectAsync();

        if (canConnect)
            return Results.Ok(new { success = true, message = "Conexión a la base de datos exitosa." });
        else
            return Results.Problem("No se pudo conectar a la base de datos.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error al conectar a la base de datos: {ex.Message}");
    }
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
