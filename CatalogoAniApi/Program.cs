using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.RegraNegocio.Validadores;
using CatalogoAniApi.Repositorio;
using CatalogoAniApi.Repositorio.Repositorios;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using CatalogoAniApi.Servico.Servicos;
using CatalogoAniApi.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped(typeof(IValidarAnime), typeof(ValidarAnime));
builder.Services.AddScoped(typeof(ILogServico), typeof(LogServico));

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
