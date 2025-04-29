using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IDonationService
    {
        Task<ResultService<ICollection<Donation>>> Get();
        Task<ResultService<Donation>> GetById(int id);
        Task<ResultService> Create(Donation donation);
        Task<ResultService<List<Donation>>> GetPagedAsync(Filter donationFilter);
    }
}
