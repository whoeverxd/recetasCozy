var builder = WebApplication.CreateBuilder(args);

// 👇 Necesario para usar controladores (clases en /Controllers)
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

// 👇 Esto habilita las rutas de tus controladores
app.MapControllers();

app.Run();