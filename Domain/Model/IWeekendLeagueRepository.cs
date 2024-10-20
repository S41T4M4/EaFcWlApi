namespace WLFCApi.Domain.Model
{
    public interface IWeekendLeagueRepository
    {
        void NewEstatisticasWl(WeekendLeague wl);
        List<WeekendLeague> GetEstatisticasWl();
        WeekendLeague GetWlById(int id);
        void UpdateWl(WeekendLeague wl);
        void DeleteWl(int id);
        List<WeekendLeague> GetWlByVitorias(int vitorias);
        List<WeekendLeague> GetWlByDate(string data);
        List<WeekendLeague> GetWlByRank(int vitorias);
    }
}
