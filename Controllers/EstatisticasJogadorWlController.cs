using Microsoft.AspNetCore.Mvc;
using WLFCApi.Domain.Model;
using WLFCApi.ViewModel;

namespace WLFCApi.Controllers
{
    [ApiController]
    [Route("estatisticasWl")]
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
                id_wl = estatisticasJogadorWL.IdEstatistica,
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
    }
}
