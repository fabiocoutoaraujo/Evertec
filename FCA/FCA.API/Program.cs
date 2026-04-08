using FCA.API.Middlewares;
using FCA.CrossCutting.IoC;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// From FCA.CrossCutting
builder.Services.AddInfrastructure();

builder.Services.AddSwaggerGen(opt => 
{
    opt.SwaggerDoc("v1", 
                   new OpenApiInfo {
                       Version = "v1",
                       Title = "Evertec Teste Backend de FCA.",
                       Description = "API para um CRUD completo de Proprietários e Veículos."
                   });

    // Configurando o Swagger para utilizar os comentários XML das controllers
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    opt.IncludeXmlComments(xmlFullPath);
});

var app = builder.Build();

// Middleware de exceções global
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment() ||
    app.Environment.IsProduction()) // habilitando o swagger em produção para testes no IIS local
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
