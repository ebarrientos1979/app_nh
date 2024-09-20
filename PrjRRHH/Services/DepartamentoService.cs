using AutoMapper;
using DAORepository.Models;
using PrjRRHH.Dto;

namespace PrjRRHH.Services
{    
    public class DepartamentoService
    {
        private readonly RhContext _context;
        private readonly IMapper _mapper;

        public DepartamentoService(
            RhContext context,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<DepartamentoDto> GetAll()
        {
            List<DepartamentoDto> listDepartamento = new List<DepartamentoDto>();
            foreach (Departamento d in _context.Departamentos.ToList())
            {
                listDepartamento.Add(_mapper.Map<DepartamentoDto>(d));
            }
            return listDepartamento;
        }
    }
}
