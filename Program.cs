
using Microsoft.EntityFrameworkCore;
using WLFCApi.Domain.Model;
using WLFCApi.Infraestrutura;
using WLFCApi.Infraestrutura.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJogadorRepository, JogadorRepository>();
builder.Services.AddTransient<IEstatisticasJogadorWlRepository, EstatisticasJogadorWlRepository>();
builder.Services.AddTransient<IWeekendLeagueRepository, WeekendLeagueRepository>();
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