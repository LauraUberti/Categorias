using Microsoft.EntityFrameworkCore;
using Ftec.ProjetoWeb.Categorias.Persistencia.Data;
using Ftec.ProjetoWeb.Categorias.Persistencia.Repositorios;
using Ftec.ProjetoWeb.Categorias.Dominio.Interfaces;
using Ftec.ProjetoWeb.Categorias.Aplicacao.Servicos;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar o Banco de Dados (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar nossas dependências (Injeção de Dependência)
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();