namespace ProjetoLivrariaAPI.Pagination
{
    public class PagedBaseReponse<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int TotalRegisters { get; set; }
        public int NumberOfPages { get; set; }
    }
}