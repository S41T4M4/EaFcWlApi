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
