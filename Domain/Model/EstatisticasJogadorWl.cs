using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WLFCApi.Domain.Model
{
    [Table("estatisticas_jogador_wl")]
    public class EstatisticasJogadorWL
    {
        [Key]
        public int id_estatistica { get; set; }

        [ForeignKey("Jogador")]
        public int id_jogador { get; set; }
        public Jogador Jogador { get; set; }

        [ForeignKey("WeekendLeague")]
        public int id_wl { get; set; }
        public WeekendLeague WeekendLeague { get; set; }

        public int numero_partida { get; set; } // Número da partida (1 a 15)

        public int gols { get; set; } // Gols marcados na partida

        public int assistencias { get; set; } // Assistências na partida
    }
}
