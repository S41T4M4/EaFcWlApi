using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WLFCApi.Domain.Model
{
    [Table("jogador")]
    public class Jogador
    {
        [Key]
        public int id_jogador { get; set; }

        public string nome { get; set; }

        public bool negociavel { get; set; }

        public string posicao { get; set; }

        public int overall { get; set; }


    }
}
