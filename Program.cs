using Microsoft.EntityFrameworkCore;
using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllers(); // Adiciona suporte a controladores (Web API)
builder.Services.AddEndpointsApiExplorer(); // Necessário para Swagger
builder.Services.AddSwaggerGen(); // Configura o Swagger para documentação
builder.Services.AddAuthorization(); // Adiciona o serviço de autorização

// Configurar o DbContext para o Entity Framework Core com Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar repositórios no contêiner de dependência (DI)
builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IRepository<Dispositivo>, DispositivoRepository>();
builder.Services.AddScoped<IRepository<Consumo>, ConsumoRepository>();
builder.Services.AddScoped<IRepository<Configuracao>, ConfiguracaoRepository>();
builder.Services.AddScoped<IRepository<Recomendacao>, RecomendacaoRepository>();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger apenas no ambiente de desenvolvimento
    app.UseSwaggerUI(); // Interface do Swagger
}

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS

app.UseAuthorization(); // Middleware de autorização

app.MapControllers(); // Mapeia os controladores para rotas

app.Run(); // Inicia a aplicação


