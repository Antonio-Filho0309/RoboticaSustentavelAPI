using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Net;

namespace RoboticaSustentavelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        /// <summary>
        /// Retorna todos as data de doações cadastradas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _donationService.Get();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Retorna a data da doação pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _donationService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

    }
}
