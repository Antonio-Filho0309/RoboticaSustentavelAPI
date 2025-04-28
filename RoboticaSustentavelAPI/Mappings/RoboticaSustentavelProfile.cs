using AutoMapper;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;

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
            CreateMap<Computer, DonationItemComputerDto>().ReverseMap();

            //ItemDonation
            CreateMap<ItemDonation, ItemDonationDto>().ReverseMap();
            CreateMap<ItemDonation, CreateItemDonationDto>().ReverseMap();

        }
    }
}
