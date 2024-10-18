using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WLFCApi.Domain.Model
{
    [Table("weekend_league")]
    public class WeekendLeague
    {
        [Key]
        public int id_wl { get; set; }

        public int numero_wl { get; set; }

        public int vitorias { get; set; }

        public int derrotas { get; set; }

        public int gols_marcados { get; set; }

        public int gols_sofridos { get; set; }

    }
}
