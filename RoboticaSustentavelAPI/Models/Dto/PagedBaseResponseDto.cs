﻿
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoLivrariaAPI.Models.Dtos.Validations;

namespace ProjetoLivrariaAPI.Models.Dtos
{
    public class PagedBaseResponseDto<T>
    {
        public PagedBaseResponseDto(int totalRegisters, int page, int totalPages, List<T> data)
        {
            TotalRegisters = totalRegisters;
            PageNumber = page;
            TotalPages = totalPages;
            Data = data;
        }

        public int TotalRegisters { get; private set; }
        public int TotalPages { get; private set; }
        public int PageNumber { get; private set; }
        public List<T> Data { get; private set; }
    }
}