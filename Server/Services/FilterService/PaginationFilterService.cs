using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server.Services.FilterService
{
    public class PaginationFilterService
    {

        [FromQuery(Name = "filter")]
        public string? Filter { get; set; }
        [FromQuery(Name = "pageNumber")]
        public int? PageNumber { get; set; }
        [FromQuery(Name = "pageSize")]
        public int? PageSize { get; set; }

        public PaginationFilterService()
        {
            Filter = null;
            PageNumber = 1;
            PageSize = 15;
        }

        public PaginationFilterService(string? filter, int? pageNumber, int? pageSize)
        {
            Filter = filter;
            PageNumber = pageNumber!.Value < 1 ? 1 : pageNumber.Value;
            PageSize = pageSize!.Value > 15 ? 15 : pageSize.Value;
        }
    }
}