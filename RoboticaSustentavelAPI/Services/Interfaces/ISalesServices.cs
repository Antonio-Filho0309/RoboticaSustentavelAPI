using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Donation;
using RoboticaSustentavelAPI.Models.Dto.Sales;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface ISalesServices
    {
        Task<ResultService<ICollection<SaleDto>>> Get();
        Task<ResultService<SaleDto>> GetById(int id);
        Task<ResultService<List<SaleDto>>> GetPagedAsync(Filter saleFilter);
    }
}
