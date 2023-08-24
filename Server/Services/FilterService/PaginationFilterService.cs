using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.FilterService
{
    public class PaginationFilterService
    {
        public string? Filter { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public PaginationFilterService()
        {
            Filter = null;
            PageNumber = 1;
            PageSize = 15;
        }

        public PaginationFilterService(string filter, int? pageNumber, int? pageSize)
        {
            Filter = filter;
            PageNumber = pageNumber!.Value < 1 ? 1 : pageNumber.Value;
            PageSize = pageSize!.Value > 15 ? 15 : pageSize.Value;
        }
    }
}