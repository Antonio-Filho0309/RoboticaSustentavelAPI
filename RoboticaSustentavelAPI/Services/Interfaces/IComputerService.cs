using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IComputerService
    {
        Task<ResultService<ICollection<ComputerDto>>> Get();
        Task<ResultService<ComputerDto>> GetById(int id);
        Task<ResultService> Create(CreateComputerDto createComputerDto);
        Task<ResultService> Update(int id, UpdateComputerDto updateComputerDto);
        Task<ResultService> Delete(int id);

        Task<ResultService<List<ComputerDto>>> GetPagedAsync(Filter computerFilter);
    }
}
