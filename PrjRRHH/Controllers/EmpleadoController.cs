using Microsoft.AspNetCore.Mvc;
using PrjRRHH.Services;

namespace PrjRRHH.Controllers
{
    [ApiController]
    [Route("/empleado")]
    public class EmpleadoController:ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController( EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_empleadoService.getAllEmpleados());
        }

    }
}
