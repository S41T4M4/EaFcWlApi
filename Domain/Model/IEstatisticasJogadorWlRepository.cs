namespace WLFCApi.Domain.Model
{
    public interface IEstatisticasJogadorWlRepository
    {
        void AddNewEstatisticas(EstatisticasJogadorWL stats);
        List<EstatisticasJogadorWL> GetAllEstatisticas();
        EstatisticasJogadorWL GetEstatisticaById(int id);
        void UpdateEstatisticas(EstatisticasJogadorWL stats);
        void DeleteEstatisticas(int id);
    }
}
