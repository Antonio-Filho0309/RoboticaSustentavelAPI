using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Computer;
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
    }
}
