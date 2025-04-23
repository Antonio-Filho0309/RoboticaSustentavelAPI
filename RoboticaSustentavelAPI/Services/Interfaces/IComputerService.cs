using ProjetoMundoReceitas.Service;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IComputerService
    {
        Task<ResultService<ICollection<ComputerDto>>> Get();
        Task<ResultService<ICollection<ComputerDto>>> GetById();
        Task<ResultService> Create(CreateComputerDto createComputerDto);
        Task<ResultService> Update(UpdateComputerDto updateComputerDto);
        Task<ResultService> Delete(int id);
    }
}
