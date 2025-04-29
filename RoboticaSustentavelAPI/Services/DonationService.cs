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

        public async Task<ResultService<ICollection<DonationDto>>> Get()
        {
            var donations = await _donationRepository.GetAllDonations();
            return ResultService.Ok(_mapper.Map<ICollection<DonationDto>>(donations));
        }

        public async Task<ResultService<DonationDto>> GetById(int id)
        {
            var donation = await _donationRepository.GetDonationById(id);
            if (donation == null)
                return ResultService.NotFound<DonationDto>("Doação não encontrada!");

            return ResultService.Ok(_mapper.Map<DonationDto>(donation));
        }

        public async Task<ResultService<List<DonationDto>>> GetPagedAsync(Filter donationFilter)
        {
            var donation = await _donationRepository.GetAllDonationPaged(donationFilter);
            var result = new PagedBaseResponseDto<DonationDto>(donation.TotalRegisters, donation.TotalPages, donation.PageNumber, _mapper.Map<List<DonationDto>>(donation.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<DonationDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }
    }
}
