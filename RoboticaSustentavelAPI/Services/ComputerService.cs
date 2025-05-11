using AutoMapper;
using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using RoboticaSustentavelAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.Validations.ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Models.Dtos;

namespace RoboticaSustentavelAPI.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IMapper _mapper;
        private readonly IComputerRepository _computerRepository;

        public ComputerService(IMapper mapper, IComputerRepository computerRepository)
        {
            _mapper = mapper;
            _computerRepository = computerRepository;
        }

        public async Task<ResultService<ICollection<ComputerDto>>> Get()
        {
            var computers = await _computerRepository.GetAllComputers();
            return ResultService.Ok(_mapper.Map<ICollection<ComputerDto>>(computers));
        }

        public async Task<ResultService> Create(CreateComputerDto createComputerDto)
        {
            if (createComputerDto == null)
                return ResultService.BadRequest("Objeto deve ser informado!");

            var result = new CreateComputerDtoValidator().Validate(createComputerDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);

            var uniqueKey = $"{createComputerDto.Brand}-{createComputerDto.Ram}-{createComputerDto.Storage}-{createComputerDto.CPU}".ToLower();

            var isDuplicate = await _computerRepository.ExistByUniqueKeyAsync(uniqueKey);
            if (isDuplicate)
                return ResultService.BadRequest("Já existe um computador com essas especificações.");



            var computer = _mapper.Map<Computer>(createComputerDto);

            await _computerRepository.Add(computer);
            return ResultService.Ok("Computador registrado com sucesso!");
        }
        public async Task<ResultService<ComputerDto>> GetById(int id)
        {
            var computer = await _computerRepository.GetComputerById(id);
            if (computer == null)
                return ResultService.NotFound<ComputerDto>("Computador não encontrado!");

            return ResultService.Ok(_mapper.Map<ComputerDto>(computer));
        }

        public async Task<ResultService<List<ComputerDto>>> GetPagedAsync(Filter computerFilter)
        {
            var computer = await _computerRepository.GetAllComputerPaged(computerFilter);
            var result = new PagedBaseResponseDto<ComputerDto>(computer.TotalRegisters, computer.Page, computer.NumberOfPages, _mapper.Map<List<ComputerDto>>(computer.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<ComputerDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.Page, result.NumberOfPages);
        }

        public async Task<ResultService> Update(int id, UpdateComputerDto updateComputerDto)
        {
            if (updateComputerDto == null)
                return ResultService.BadRequest("Dados para atualização não informados");

            var validation = new UpdateComputerDtoValidator().Validate(updateComputerDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);

            var computer = await _computerRepository.GetComputerById(id);
            if (computer == null)
                return ResultService.NotFound("Computador não encontrado");

            computer = _mapper.Map(updateComputerDto, computer);
            await _computerRepository.Update(computer);
            return ResultService.Ok("Computador atualizado com sucesso");
        }

        public async Task<ResultService> Delete(int id)
        {
            var computer = await _computerRepository.GetComputerById(id);
            if (computer == null)
                return ResultService.NotFound("Computador não encontrado");

            await _computerRepository.Delete(computer);
            return ResultService.Ok("Computador deletado com sucesso");
        }
    }
}

