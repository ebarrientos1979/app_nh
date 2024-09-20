using AutoMapper;
using DAORepository.Models;
using PrjRRHH.Dto;

namespace PrjRRHH.Configuration
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t.Namespace == "DAORepository.Models"
                    || t.Namespace == "PrjRRHH.Dto"
                );

            foreach (var type in types)
            {
                var dtoType = types.FirstOrDefault(t => t.Name == type.Name + "Dto");
                if (dtoType != null)
                {
                    CreateMap(type, dtoType).ReverseMap();
                }
            }
        }
    }
}
