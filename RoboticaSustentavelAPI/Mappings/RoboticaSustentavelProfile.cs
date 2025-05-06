using AutoMapper;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Dto.Donation;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;

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

            //Donation
            CreateMap<Donation, DonationDto>().ReverseMap();

            //ItemSale
            CreateMap<Sale, CreateItemSaleDto>().ReverseMap();
            CreateMap<Sale, ItemSaleDto>().ReverseMap();
        }
    }
}
