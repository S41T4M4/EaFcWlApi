namespace WLFCApi.ViewModel
{
    public class EstatisticasJogadorWlViewModel
    {
        public int IdEstatistica { get; set; } // ID da estatística

        public int IdJogador { get; set; } // ID do jogador
        public string NomeJogador { get; set; } // Nome do jogador

        public int IdWL { get; set; } // ID da Weekend League
        public int NumeroWL { get; set; } // Número da Weekend League

        public int NumeroPartida { get; set; } // Número da partida (1 a 15)

        public int Gols { get; set; } // Gols marcados na partida
        public int Assistencias { get; set; } // Assistências na partida
    }
}
