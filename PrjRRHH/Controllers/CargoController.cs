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

        [HttpPost("saveCargo")]
        public IActionResult save([FromBody] Cargo cargo)
        {            
            RptaDefault estaGrabado = _cargoService.saveCargo(cargo);
                        
            return estaGrabado.idRespuesta == 0?
                BadRequest(estaGrabado):Ok(estaGrabado);
        }

    }
}
