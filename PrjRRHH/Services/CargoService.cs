﻿using AutoMapper;
using DAORepository.Models;
using PrjRRHH.Configuration;
using PrjRRHH.Dto;
namespace PrjRRHH.Services
{
    public class CargoService
    {
        private readonly RhContext _context;
        private readonly ILogger<CargoService> _logger;
        private readonly IMapper _mapper;

        public CargoService(
            RhContext context, 
            ILogger<CargoService> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CargoDto> GetCargo()
        {
            List<CargoDto> listaCargos = new List<CargoDto>();

            _context.Cargos.ToList<Cargo>().ForEach(c =>
            {
                listaCargos.Add(_mapper.Map<CargoDto>(c));
            });
            return listaCargos;
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
