var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os para o Swagger
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Habilita o uso de anota��es como [SwaggerSchema]
});

var app = builder.Build();

// Configura��es do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
