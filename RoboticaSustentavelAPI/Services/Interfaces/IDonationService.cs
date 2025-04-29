using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Donation;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IDonationService
    {
        Task<ResultService<ICollection<DonationDto>>> Get();
        Task<ResultService<DonationDto>> GetById(int id);
        Task<ResultService<List<DonationDto>>> GetPagedAsync(Filter donationFilter);
    }
}
