using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PrjRRHH.Services;

namespace PrjRRHH.Controllers
{
    [Route("/departamento")]   
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(_departamentoService.GetAll());
        }         
    }
}
