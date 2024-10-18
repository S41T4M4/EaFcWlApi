using Microsoft.AspNetCore.Mvc;
using WLFCApi.Domain.Model;
using WLFCApi.ViewModel;

namespace WLFCApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorController(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }
        [HttpPost("newJogador")]
        public IActionResult AddNewJogador(JogadorViewModel jogadorViewModel)
        {
            var newJogador = new Jogador
            {
                id_jogador = jogadorViewModel.IdJogador,
                nome = jogadorViewModel.Nome,
                negociavel = jogadorViewModel.Negociavel,
                overall = jogadorViewModel.Overall,
                posicao = jogadorViewModel.Posicao,
            };
            if (newJogador.nome == "")
            {
                throw new Exception("O nome do Jogador não pode ser vazio");
            }
            if (newJogador.overall < 45)
            {
                throw new Exception("O jogador não pode ter um over menor que 45");
            }

            _jogadorRepository.NewJogador(newJogador);
            return Ok(newJogador);
        }
        [HttpGet("getAllJogadores")]
        public IActionResult GetAllJogadores()
        {
            var jogadores = _jogadorRepository.GetJogadorList();
            return Ok(jogadores);
        }
        [HttpGet("getJogadorById")]
        public IActionResult GetJogadorById(int id)
        {
            var jogador = _jogadorRepository.GetJogadorById(id);
            return Ok(jogador);
        }
        [HttpPut("updateJogador/{id}")]
        public IActionResult UpdateJogador(int id, [FromBody] JogadorViewModel jogador)
        {
            var jogadorExistente = _jogadorRepository.GetJogadorById(id);

            if (jogadorExistente == null)
            {
                throw new Exception("O jogador não existe");
            }


            jogadorExistente.nome = jogador.Nome;
            jogadorExistente.negociavel = jogador.Negociavel;
            jogadorExistente.overall = jogador.Overall;
            jogadorExistente.posicao = jogador.Posicao;


            _jogadorRepository.UpdateJogador(jogadorExistente);
            return Ok();

        }
        [HttpDelete("deleteJogador")]
        public IActionResult DeleteJogador(int id)
        {
            var jogadorExistente = _jogadorRepository.GetJogadorById(id);
            if (jogadorExistente != null)
            {
                _jogadorRepository.DeleteJogador(id);
                return Ok();
            }
            else
            {
                throw new Exception("Não existe o jogador");
            }
        }
        [HttpGet("getJogadorByNome")]
        public IActionResult GetJogador(string nome)
        {
            var jogadorExistente = _jogadorRepository.GetJogadorByNome(nome);
            return Ok(jogadorExistente);
        }

    }
}
