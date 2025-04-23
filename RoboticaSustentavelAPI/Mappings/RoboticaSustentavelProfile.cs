using AutoMapper;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace RoboticaSustentavelAPI.Mappings
{
    public class RoboticaSustentavelProfile : Profile
    {
       public RoboticaSustentavelProfile()
        {
            //Computer
            CreateMap<Computer, ComputerDto>().ReverseMap();
            CreateMap<Computer, CreateComputerDto>().ReverseMap();
            CreateMap<Computer, UpdateComputerDto>().ReverseMap();


        }
    }
}
