using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;

namespace RoboticaSustentavelAPI.Services
{
    public class DonationService : IDonationService
    {
        private readonly IMapper _mapper;
        private readonly IDonationRepository _donationRepository;
        public async Task<ResultService> Create(Donation donation)
        {
            if (donation == null)
                return ResultService.BadRequest("Objeto deve ser informado!");

            var donationMap = _mapper.Map<Donation>(donation);

            var createdDonation = await _donationRepository.Add(donationMap);

            if (createdDonation == null)
                return ResultService.BadRequest("Erro ao criar a doação.");

            return ResultService.Ok(createdDonation);

        }

        public async Task<ResultService<ICollection<Donation>>> Get()
        {
            var donations = await _donationRepository.GetAllDonations();
            return ResultService.Ok(_mapper.Map<ICollection<Donation>>(donations));
        }

        public async Task<ResultService<Donation>> GetById(int id)
        {
            var donation = await _donationRepository.GetDonationById(id);
            if (donation == null)
                return ResultService.NotFound<Donation>("Doação não encontrado!");

            return ResultService.Ok(_mapper.Map<Donation>(donation));
        }

        public async Task<ResultService<List<Donation>>> GetPagedAsync(Filter donationFilter)
        {
            var donation = await _donationRepository.GetAllDonationPaged(donationFilter);
            var result = new PagedBaseResponseDto<Donation>(donation.TotalRegisters, donation.TotalPages, donation.PageNumber, _mapper.Map<List<Donation>>(donation.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<Donation>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }
    }
}
