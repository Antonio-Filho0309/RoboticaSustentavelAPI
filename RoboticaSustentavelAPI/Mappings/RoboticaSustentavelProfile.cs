﻿using AutoMapper;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Dto.Donation;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;
using RoboticaSustentavelAPI.Models.Dto.Sales;
using RoboticaSustentavelAPI.Models.Dto;

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
            CreateMap<ItemDonation, Item>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Donation.DateDonation));

            //Donation
            CreateMap<Donation, DonationDto>().ReverseMap();
            CreateMap<Donation, DonationDto2>().ReverseMap();


            //ItemSale
            CreateMap<ItemSale, CreateItemSaleDto>().ReverseMap();
            CreateMap<ItemSale, ItemSaleDto>().ReverseMap();
            CreateMap<ItemSale, Item>()
                 .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Sale.SaleDate));

            //Sale 
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Sale, SaleDto2>().ReverseMap();
        }
    }
}
