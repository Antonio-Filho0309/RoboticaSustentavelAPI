using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Sales;
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
        public async Task<ResultService<ICollection<SaleDto2>>> Get()
        {
            var sales = await _saleRepository.GetAllSales();
            return ResultService.Ok(_mapper.Map<ICollection<SaleDto2>>(sales));
        }

        public async Task<ResultService<SaleDto2>> GetById(int id)
        {
            var sale = await _saleRepository.GetSaleById(id);
            if (sale == null)
                return ResultService.NotFound<SaleDto2>("Venda não encontrada!");

            return ResultService.Ok(_mapper.Map<SaleDto2>(sale));
        }

        public async Task<ResultService<List<SaleDto2>>> GetPagedAsync(Filter saleFilter)
        {
            var sale = await _saleRepository.GetAllSalesPaged(saleFilter);
            var result = new PagedBaseResponseDto<SaleDto2>(sale.TotalRegisters, sale.Page, sale.NumberOfPages, _mapper.Map<List<SaleDto2>>(sale.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<SaleDto2>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.Page, result.NumberOfPages);
        }
    }
}
