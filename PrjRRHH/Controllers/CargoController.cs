using DAORepository.Models;
using Microsoft.AspNetCore.Mvc;
using PrjRRHH.Configuration;
using PrjRRHH.Services;

namespace PrjRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private CargoService _cargoService;
        
        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }


        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(_cargoService.GetCargo());
        }


        [HttpGet("/getAllCargos")]
        public async Task<ActionResult> GetAllCargos([FromQuery] CargoQueryParameters queryParameters)
        {
            return Ok(await _cargoService.getPagination(queryParameters));
        }

        [HttpPost("saveCargo")]
        public IActionResult save([FromBody] Cargo cargo)
        {            
            RptaDefault estaGrabado = _cargoService.saveCargo(cargo);
                        
            return estaGrabado.idRespuesta == 0?
                BadRequest(estaGrabado):Ok(estaGrabado);
        }

        /*[HttpDelete("deleteCargo/{Idcargo}")]
        public IActionResult Delete(string Idcargo)
        {

            return _cargoService.deleteCargo(Idcargo);
        }*/

    }
}
