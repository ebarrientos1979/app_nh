using DAORepository.Models;
using PrjRRHH.Configuration;
namespace PrjRRHH.Services
{
    public class CargoService
    {
        private readonly RhContext _context;
        private readonly ILogger<CargoService> _logger;

        public CargoService(RhContext context, ILogger<CargoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Cargo> GetCargo()
        {
            return _context.Cargos.ToList();
        }

        //Método para registrar un nuevo Cargo
        public RptaDefault saveCargo(Cargo cargo)
        {
            RptaDefault rptaDefault = new RptaDefault();

            rptaDefault.idRespuesta = -1;
            rptaDefault.mensaje = "Cargo Grabado Correctamente";
            _context.Add(cargo);
            try
            {
                rptaDefault.idRespuesta = _context.SaveChanges();
                if (rptaDefault.idRespuesta == 0)
                    rptaDefault.mensaje = "Hubo un problema al momento de grabar";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                rptaDefault.mensaje = ex.Message;
                rptaDefault.idRespuesta = 0;
            }

            return rptaDefault;
        }

        //public RptaDefault deleteCargo(string idCargo)
        //{

        //}
    }
}
