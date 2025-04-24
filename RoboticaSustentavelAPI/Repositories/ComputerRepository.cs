using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjetoLivrariaAPI.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly DataContext _context;

        public ComputerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Computer> Add(Computer computer)
        {
            _context.Add(computer);
            await _context.SaveChangesAsync();
            return computer;
        }


        public async Task Update(Computer computer)
        {
            _context.Update(computer);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Computer computer)
        {
            _context.Remove(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Computer>> GetAllComputers()
        {
            return await _context.Computers.OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<Computer> GetComputerById(int computerId)
        {

            return await _context.Computers.FirstOrDefaultAsync(c => c.Id == computerId);
        }


        public async Task<PagedBaseReponse<Computer>> GetAllComputerPaged(Filter computerFilter)
        {
            var computer = _context.Computers.AsQueryable();
            if (!string.IsNullOrEmpty(computerFilter.Search))
            {
                var filter = computerFilter.Search.ToLower();

                computer = computer.Where(c =>
                c.Brand.ToLower().Contains(filter) ||
                c.CPU.ToLower().Contains(filter) ||
                c.Ram.ToLower().Contains(filter) ||
                c.Storage.ToLower().Contains(filter) ||
                c.Id.ToString().Contains(filter));
            }
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Computer>, Computer>(computer, computerFilter);
        }

    }
}