using Locadora.API.Services;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IComputerService
    {
        Task<ResultService<ICollection<ComputerDto>>> Get();
        Task<ResultService<ComputerDto>> GetById(int id);
        Task<ResultService> Create(CreateComputerDto createComputerDto);
        Task<ResultService> Update(UpdateComputerDto updateComputerDto);
        Task<ResultService> Delete(int id);
    }
}
