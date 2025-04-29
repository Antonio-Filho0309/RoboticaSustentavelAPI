using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;

namespace RoboticaSustentavelAPI.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DataContext _context;

        public DonationRepository(DataContext context)
        {
            _context = context;
        }

        public  async Task<PagedBaseReponse<Donation>> GetAllDonationPaged(Filter donationFilter)
        {
            var donation = _context.Donations.AsQueryable();
            if (!string.IsNullOrEmpty(donationFilter.Search))
            {
                var filter = donationFilter.Search.ToLower();

                donation = donation.Where(d =>
                d.DateDonation.ToString().Contains(filter));
            }
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Donation>, Donation>(donation, donationFilter);
        }

        public async Task<ICollection<Donation>> GetAllDonations()
        {
            return await _context.Donations.OrderBy(d => d.Id)
              .ToListAsync();
        }

        public async Task<Donation> GetDonationById(int donationId)
        {
            return await _context.Donations.FirstOrDefaultAsync(d => d.Id == donationId);
        }
    }
}
