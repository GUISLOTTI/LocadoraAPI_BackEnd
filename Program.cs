using LocadoraApi.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Adicionando serviços ao container
builder.Services.AddControllers();  // Adiciona suporte para controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Configuração do banco de dados (caso use Entity Framework)
builder.Services.AddDbContext<LocadoraContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Configurar CORS (se precisar permitir acessos externos)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// 🔹 Criar aplicação
var app = builder.Build();

// 🔹 Configuração do pipeline HTTP (middlewares)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");  // Aplicar política de CORS
app.UseAuthorization();
app.MapControllers();  // Mapear os controllers

app.Run();