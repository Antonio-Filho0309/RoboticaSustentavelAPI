using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Net;

namespace RoboticaSustentavelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        /// <summary>
        /// Retorna todos os computadores cadastrados
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _computerService.Get();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Retorna um computador pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _computerService.GetById(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }


        /// <summary>
        /// método para paginação
        /// </summary>
        [HttpGet]
        [Route("Paged")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] Filter computerFilter)
        {
            var result = await _computerService.GetPagedAsync(computerFilter);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Cria um novo computador
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateComputerDto createComputerDto)
        {
            var result = await _computerService.Create(createComputerDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);
            return BadRequest(result);
        }

        /// <summary>
        /// Atualiza um computador existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] UpdateComputerDto updateComputerDto)
        {
            var result = await _computerService.Update(id, updateComputerDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Remove um computador pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _computerService.Delete(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);
            return BadRequest(result);
        }
    }
}
