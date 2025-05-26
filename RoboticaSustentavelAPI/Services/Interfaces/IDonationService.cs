using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Donation;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IDonationService
    {
        Task<ResultService<ICollection<DonationDto2>>> Get();
        Task<ResultService<DonationDto2>> GetById(int id);
    }
}
