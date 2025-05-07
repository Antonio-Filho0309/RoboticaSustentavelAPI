using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Donation;
using RoboticaSustentavelAPI.Models.Dto.Sales;
using RoboticaSustentavelAPI.Repositories;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;

namespace RoboticaSustentavelAPI.Services
{
    public class SaleService : ISalesServices
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public SaleService(IMapper mapper, ISaleRepository saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }
        public async Task<ResultService<ICollection<SaleDto>>> Get()
        {
            var sales = await _saleRepository.GetAllSales();
            return ResultService.Ok(_mapper.Map<ICollection<SaleDto>>(sales));
        }

        public async Task<ResultService<SaleDto>> GetById(int id)
        {
            var sale = await _saleRepository.GetSaleById(id);
            if (sale == null)
                return ResultService.NotFound<SaleDto>("Doação não encontrada!");

            return ResultService.Ok(_mapper.Map<SaleDto>(sale));
        }

        public async Task<ResultService<List<SaleDto>>> GetPagedAsync(Filter saleFilter)
        {
            var sale = await _saleRepository.GetAllSalesPaged(saleFilter);
            var result = new PagedBaseResponseDto<SaleDto>(sale.TotalRegisters, sale.TotalPages, sale.PageNumber, _mapper.Map<List<SaleDto>>(sale.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<SaleDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }
    }
}
