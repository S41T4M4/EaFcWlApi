using Microsoft.AspNetCore.Mvc;
using WLFCApi.Domain.Model;
using WLFCApi.Infraestrutura.Repositories;
using WLFCApi.ViewModel;

namespace WLFCApi.Controllers
{
    [ApiController]
    [Route("api/estatisticas")]
    public class EstatisticasJogadorWlController : ControllerBase
    {
        private readonly IEstatisticasJogadorWlRepository _repository;

        public EstatisticasJogadorWlController(IEstatisticasJogadorWlRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("novaEstatistica")]
        public IActionResult AddNewEstatistica(EstatisticasJogadorWlViewModel estatisticasJogadorWL)
        {
            var newEstatistica = new EstatisticasJogadorWL
            {
                id_estatistica = estatisticasJogadorWL.IdEstatistica,
                id_jogador = estatisticasJogadorWL.IdJogador,
                id_wl = estatisticasJogadorWL.IdWL,
                numero_partida = estatisticasJogadorWL.NumeroPartida,
                gols = estatisticasJogadorWL.Gols,
                assistencias = estatisticasJogadorWL.Assistencias,

            };
            _repository.AddNewEstatisticas(newEstatistica);
            return Ok();
        }
        [HttpGet("getAllEstatistica")]
        public IActionResult GetAllEstatisticas()
        {
            var estatisticas = _repository.GetAllEstatisticas();
            return Ok(estatisticas);
        }
        [HttpPut("UpdateEstatisticas")]
        public IActionResult UpdateEstatisticas(int id, EstatisticasJogadorWlViewModel estatisticasJogadorWL)
        {
            var existingEstatisticas = _repository.GetEstatisticaById(id);
            if (existingEstatisticas == null)
            {
                throw new Exception("Não existe essa estatisticas");
            }
            existingEstatisticas.id_estatistica = estatisticasJogadorWL.IdEstatistica;
            existingEstatisticas.id_jogador = estatisticasJogadorWL.IdJogador;
            existingEstatisticas.id_wl = estatisticasJogadorWL.IdWL;
            existingEstatisticas.numero_partida = estatisticasJogadorWL.NumeroPartida;
            existingEstatisticas.gols = estatisticasJogadorWL.Gols;
            existingEstatisticas.assistencias = estatisticasJogadorWL.Assistencias;

            _repository.AddNewEstatisticas(existingEstatisticas);
            return Ok(estatisticasJogadorWL);
        }
        [HttpGet("getEstatisticasById")]
        public IActionResult GetEstatisticasById(int id)
        {
            var estatisticas = _repository.GetEstatisticaById(id);
            return Ok(estatisticas);

        }
        [HttpDelete("deleteEstatisticas")]
        public IActionResult DeleteEstatisticas(int id)
        {
            var estatistica = _repository.GetEstatisticaById(id);
            if (estatistica != null)
            {
                _repository.AddNewEstatisticas(estatistica);
                return Ok();
            }
            else
            {
                throw new Exception("Não existe essa estatistica");
            }
        }
        [HttpGet("getJogadoresPorWl/{idWl}")]
        public IActionResult GetJogadoresPorWl(int idWl)
        {
            var estatisticasJogadores = _repository.GetEstatisticasJogadoresPorWl(idWl);

            if (estatisticasJogadores == null || estatisticasJogadores.Count == 0)
            {
                return NotFound("Nenhum jogador encontrado para esta WL.");
            }

            // Retorna apenas os jogadores com suas estatísticas
            var jogadoresComEstatisticas = estatisticasJogadores.Select(e => new
            {
                
                nomeJogador = e.Jogador.nome,
                posicao = e.Jogador.posicao,
                overall = e.Jogador.overall,
                gols = e.gols,
                assistencias = e.assistencias,
                weekendLeague = new
                {
                    numeroWl = e.WeekendLeague.numero_wl,
                    data = e.WeekendLeague.data,  // Supondo que tenha uma data na entidade WeekendLeague
                    vitorias = e.WeekendLeague.vitorias,
                    derrotas = e.WeekendLeague.derrotas
                }

            }).ToList();

            return Ok(jogadoresComEstatisticas);
        }


    }
}
