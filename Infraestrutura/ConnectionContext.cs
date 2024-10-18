using Microsoft.EntityFrameworkCore;
using WLFCApi.Domain.Model;

namespace WLFCApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<WeekendLeague> WeekendLeagues { get; set; }
        public DbSet<EstatisticasJogadorWL> EstatisticasJogadorWl { get; set; }
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options)
        {
        }
        //String de conexão 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(
             "Server=localhost;" +
             "Port=5432;Database=wldb_fc;" +
             "User Id=postgres;" +
             "Password=Staff4912;");

    }
}
