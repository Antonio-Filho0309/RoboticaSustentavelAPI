
namespace ProjetoLivrariaAPI.Models.Dtos
{
    public class PagedBaseResponseDto<T>
    {
        public PagedBaseResponseDto(int totalRegisters, int page, int totalPages, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Page = totalPages;
            NumberOfPages = page;
            Data = data;
        }

        public int TotalRegisters { get; private set; }
        public int Page { get; private set; }
        public int NumberOfPages { get; private set; }
        public List<T> Data { get; private set; }
    }
}