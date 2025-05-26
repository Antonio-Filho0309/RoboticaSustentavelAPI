using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.FilterDb;
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
    }
}
