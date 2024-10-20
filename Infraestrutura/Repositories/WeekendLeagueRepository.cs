using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;
using WLFCApi.Domain.Model;

namespace WLFCApi.Infraestrutura.Repositories
{
    public class WeekendLeagueRepository : IWeekendLeagueRepository
    {
        private readonly ConnectionContext _connectionContext;

        public WeekendLeagueRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void DeleteWl(int id)
        {
            var wlExisting = _connectionContext.WeekendLeagues.Find(id);
            if(wlExisting != null)
            {
                _connectionContext.WeekendLeagues.Remove(wlExisting);
                _connectionContext.SaveChanges();
            }

        }

        public List<WeekendLeague> GetEstatisticasWl()
        {
            return _connectionContext.WeekendLeagues.ToList();
        }

        public List<WeekendLeague> GetWlByDate(string data)
        {
            return _connectionContext.WeekendLeagues.Where(w => w.data == data).ToList();
        }

        public WeekendLeague GetWlById(int id)
        {
            return _connectionContext.WeekendLeagues.Find(id);
        }

        public List<WeekendLeague> GetWlByRank(int vitorias)
        {      
            return _connectionContext.WeekendLeagues.Where(w => w.vitorias == vitorias).ToList();
            
        }

        public List<WeekendLeague> GetWlByVitorias(int vitorias)
        {
            return _connectionContext.WeekendLeagues
            .Where(w => w.vitorias == vitorias)
            .ToList();
        }
     
        public void NewEstatisticasWl(WeekendLeague wl)
        {
            _connectionContext.WeekendLeagues.Add(wl);
            _connectionContext.SaveChanges();
        }

        public void UpdateWl(WeekendLeague wl)
        {
            var existingWl = _connectionContext.WeekendLeagues.Find(wl.id_wl);

            if (existingWl != null)
            {
                existingWl.numero_wl = wl.numero_wl;
                existingWl.vitorias = wl.vitorias;
                existingWl.gols_sofridos = wl.gols_sofridos;
                existingWl.derrotas = wl.derrotas;
                existingWl.gols_marcados = wl.gols_marcados;
                existingWl.gols_sofridos = wl.gols_sofridos;
                existingWl.data = wl.data;

                _connectionContext.WeekendLeagues.Update(wl);
                _connectionContext.SaveChanges();

            }
        }
    }
}
