﻿using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        Task<ICollection<Donation>> GetAllDonations();
        Task<Donation> GetDonationById(int donationId);
        Task<PagedBaseReponse<Donation>> GetAllDonationPaged(Filter donationFilter);
    }
}
