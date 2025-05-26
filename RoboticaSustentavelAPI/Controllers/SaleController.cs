using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Net;

namespace RoboticaSustentavelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISalesServices _saleService;

        public SaleController(ISalesServices salesService)
        {
            _saleService = salesService;
        }

        /// <summary>
        /// Retorna todos as data de vendas cadastradas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _saleService.Get();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Retorna a data da venda pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _saleService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
    }
}
