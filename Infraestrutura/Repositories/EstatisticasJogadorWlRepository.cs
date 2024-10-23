using Microsoft.EntityFrameworkCore;
using WLFCApi.Domain.Model;

namespace WLFCApi.Infraestrutura.Repositories
{
    public class EstatisticasJogadorWlRepository : IEstatisticasJogadorWlRepository
    {
        private readonly ConnectionContext _connectionContext;

        public EstatisticasJogadorWlRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewEstatisticas(EstatisticasJogadorWL stats)
        {
            _connectionContext.EstatisticasJogadorWl.Add(stats);
            _connectionContext.SaveChanges();

        }

        public void DeleteEstatisticas(int id)
        {
            var existingEstatisticas = _connectionContext.EstatisticasJogadorWl.Find(id);
            if (existingEstatisticas == null)
            {
                throw new Exception("A estatistica não existe");
            }
            _connectionContext.EstatisticasJogadorWl.Remove(existingEstatisticas);
            _connectionContext.SaveChanges();
        }

        public List<EstatisticasJogadorWL> GetAllEstatisticas()
        {
            return _connectionContext.EstatisticasJogadorWl.ToList();
        }

        public EstatisticasJogadorWL GetEstatisticaById(int id)
        {
           
            return _connectionContext.EstatisticasJogadorWl.Find(id);
        }

        public List<EstatisticasJogadorWL> GetEstatisticasJogadoresPorWl(int idWl)
        {
            return _connectionContext.EstatisticasJogadorWl
            .Include(e => e.Jogador) // Inclui as informações do jogador
            .Include(e => e.WeekendLeague)
            .Where(e => e.id_wl == idWl) // Filtra pela WL
            .ToList();
        }

        public List<EstatisticasJogadorWL> GetUltimasEstatisticas()
        {
            // Obtém o maior id_wl (última Weekend League)
            var lastWl = _connectionContext.EstatisticasJogadorWl.Max(e => e.id_wl);

            // Retorna as estatísticas associadas à última Weekend League
            return _connectionContext.EstatisticasJogadorWl.Where(e => e.id_wl == lastWl).ToList();
        }

        public void UpdateEstatisticas(EstatisticasJogadorWL stats)
        {
            var existingEstatisticas = _connectionContext.EstatisticasJogadorWl.Find(stats.id_estatistica);
            if (existingEstatisticas == null)
            {
                throw new Exception("Não existe estatisticas nesse id");
            }
            existingEstatisticas.numero_partida = stats.numero_partida;
            existingEstatisticas.gols = stats.gols;
            existingEstatisticas.assistencias = stats.assistencias;

            _connectionContext.EstatisticasJogadorWl.Update(existingEstatisticas);
            _connectionContext.SaveChanges();
        }
    }
}
