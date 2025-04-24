using ProjetoLivrariaAPI.Pagination;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Repositories.Interfaces
{
    public interface IComputerRepository
    {
        Task<Computer> Add(Computer computer);
        Task Update(Computer computer);
        Task Delete(Computer computer);

        Task<ICollection<Computer>> GetAllComputers();

        Task<Computer> GetComputerById(int computerId);

        Task<PagedBaseReponse<Computer>> GetAllComputerPaged(Filter computerFilter);
    }
}
