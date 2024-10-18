namespace WLFCApi.Domain.Model
{
    public interface IJogadorRepository
    {
        void NewJogador(Jogador jogador);
        List<Jogador> GetJogadorList();
        Jogador GetJogadorById(int id);
        void UpdateJogador(Jogador jogador);
        void DeleteJogador(int id);
    }
}
