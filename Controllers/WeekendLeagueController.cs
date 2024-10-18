using Microsoft.AspNetCore.Mvc;
using WLFCApi.Domain.Model;
using WLFCApi.ViewModel;

namespace WLFCApi.Controllers
{
    [ApiController]
    [Route("wl")]
    public class WeekendLeagueController : ControllerBase
    {
        private readonly IWeekendLeagueRepository _weekendLeagueRepository;

        public WeekendLeagueController(IWeekendLeagueRepository weekendLeagueRepository)
        {
            _weekendLeagueRepository = weekendLeagueRepository;
        }

        [HttpPost("newWl")]
        public IActionResult CreateNewWl(WeekendLeagueViewModel wlView)
        {
            var newWl = new WeekendLeague()
            {
                numero_wl = wlView.NumeroWl,
                vitorias = wlView.Vitorias,
                derrotas = wlView.Derrotas,
                gols_marcados = wlView.GolsMarcados,
                gols_sofridos = wlView.GolsSofridos,

            };
            _weekendLeagueRepository.NewEstatisticasWl(newWl);
            return Ok();
        }
        [HttpGet("getAllWls")]
        public IActionResult GetAllWls()
        {
            var wls = _weekendLeagueRepository.GetEstatisticasWl();
            return Ok(wls);
        }
        [HttpPut("editWl")]
        public IActionResult UpdateWl(int id, WeekendLeagueViewModel wlViewModel)
        {
            var wlExisting = _weekendLeagueRepository.GetWlById(id);
            if (wlExisting == null)
            {
                throw new Exception("Não foi encontrada essa wl");
            }
            wlExisting.numero_wl = wlViewModel.NumeroWl;
            wlExisting.vitorias = wlViewModel.Vitorias;
            wlExisting.derrotas = wlViewModel.Derrotas;
            wlExisting.gols_marcados = wlViewModel.GolsMarcados;
            wlExisting.gols_sofridos = wlViewModel.GolsSofridos;

            _weekendLeagueRepository.UpdateWl(wlExisting);
            return Ok("Os dados foram salvos !");
        }
        [HttpGet("getWlById")]

        public IActionResult FindWlByID(int id)
        {
            var wlExisting = _weekendLeagueRepository.GetWlById(id);
            return Ok(wlExisting);
        }
        [HttpDelete("deleteWl")]
        public IActionResult DeleteWl(int id)
        {
            var wlExisting = _weekendLeagueRepository.GetWlById(id);
            if (wlExisting != null)
            {
                _weekendLeagueRepository.DeleteWl(id);
                return Ok();
            }
            else
            {
                throw new Exception("Não existe essa wl");
            }
        }
        [HttpGet("wlByVitorias")]
        public IActionResult GetWlByVitorias(int vitorias)
        {
            var wlExisting = _weekendLeagueRepository.GetWlByVitorias(vitorias);
            return Ok(wlExisting);
        }


    }
}
