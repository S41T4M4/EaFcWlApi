using WLFCApi.Domain.Model;


namespace WLFCApi.Infraestrutura.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly ConnectionContext _connectionContext;

        public JogadorRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        public void NewJogador(Jogador jogador)
        {
            _connectionContext.Jogador.Add(jogador);
            _connectionContext.SaveChanges();
        }


        public void DeleteJogador(int id)
        {
            var jogador = _connectionContext.Jogador.Find(id);
            if (jogador != null)
            {
                _connectionContext.Jogador.Remove(jogador);
                _connectionContext.SaveChanges();
            }
            else
            {
                throw new Exception("O jogador não foi encontrado");
            }


        }

        public Jogador GetJogadorById(int id)
        {
            return _connectionContext.Jogador.Find(id);
        }

        public List<Jogador> GetJogadorList()
        {
            return _connectionContext.Jogador.ToList();

        }


        public void UpdateJogador(Jogador jogador)
        {
            var jogadorNovo = _connectionContext.Jogador.Find(jogador.id_jogador);
            if (jogadorNovo == null)
            {
                throw new ArgumentException("Jogador não encontrado");
            }
            
         
             jogadorNovo.nome = jogador.nome;
             jogadorNovo.negociavel = jogador.negociavel;
            jogadorNovo.overall = jogador.overall;
            jogadorNovo.posicao = jogador.posicao;

            _connectionContext.Jogador.Update(jogadorNovo);
            _connectionContext.SaveChanges();


        }
    }
}
