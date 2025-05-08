using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Dto.Donation;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;

namespace RoboticaSustentavelAPI.Services
{
    public class DonationService : IDonationService
    {
        private readonly IMapper _mapper;
        private readonly IDonationRepository _donationRepository;

        public DonationService(IMapper mapper, IDonationRepository donationRepository)
        {
            _mapper = mapper;
            _donationRepository = donationRepository;
        }

        public async Task<ResultService<ICollection<DonationDto2>>> Get()
        {
            var donations = await _donationRepository.GetAllDonations();
            return ResultService.Ok(_mapper.Map<ICollection<DonationDto2>>(donations));
        }

        public async Task<ResultService<DonationDto2>> GetById(int id)
        {
            var donation = await _donationRepository.GetDonationById(id);
            if (donation == null)
                return ResultService.NotFound<DonationDto2>("Doação não encontrada!");

            return ResultService.Ok(_mapper.Map<DonationDto2>(donation));
        }

        public async Task<ResultService<List<DonationDto2>>> GetPagedAsync(Filter donationFilter)
        {
            var donation = await _donationRepository.GetAllDonationPaged(donationFilter);
            var result = new PagedBaseResponseDto<DonationDto2>(donation.TotalRegisters, donation.TotalPages, donation.PageNumber, _mapper.Map<List<DonationDto2>>(donation.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<DonationDto2>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }
    }
}
