using AutoMapper;
using DAORepository.Models;
using PrjRRHH.Dto;

namespace PrjRRHH.Services
{
    public class EmpleadoService  
    {
        private readonly RhContext _context;
        private readonly IMapper _mapper;

        public EmpleadoService(RhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<EmpleadoDto> getAllEmpleados()
        {
            List<EmpleadoDto> lista = new List<EmpleadoDto>();

            foreach (Empleado e in _context.Empleados)
            {
                lista.Add(_mapper.Map<EmpleadoDto>(e));
            }

            return lista;
            
        }
    }
}
