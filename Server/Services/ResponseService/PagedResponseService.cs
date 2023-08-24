using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services.ResponseService
{
    public class PagedResponseService<T> : ResponseModel<T>
    {
        public string? Filter { get; set; }
        public string? SortBy { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int? TotalPage { get; set;}
        public int? TotalRecord { get; set; }
        public string? PreviousLink { get; set; }
        public string? NextLink { get; set; }
        public string? FirstPage { get; set; }
        public string? LastPage { get; set; }


        public PagedResponseService(T data, int PageSize, int pageNumber)
        {
            this.Data = data;
            this.PageSize = PageSize;
            this.PageNumber = pageNumber;
        }

    }
}