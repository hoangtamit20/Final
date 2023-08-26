using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Server.Models;
using Server.Repositories.IRepository;
using Server.Services.FilterService;
using Server.Services.ResponseService;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]", Name = "DefaultApi")]
    public class NguoiDungController : ControllerBase
    {
        private readonly IRepositoryOfEntity<NguoiDungModel> _repositoryOfEntity;

        public NguoiDungController(IRepositoryOfEntity<NguoiDungModel> repositoryOfEntity)
        {
            _repositoryOfEntity = repositoryOfEntity;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilterService paginationFilterService)
        {
            var validFilter = new PaginationFilterService(paginationFilterService.Filter!, paginationFilterService.PageNumber!.Value, paginationFilterService.PageSize!.Value);
            var pagedData = await _repositoryOfEntity.GetAllFullOptions(validFilter)!;
            var totalRecords = (await _repositoryOfEntity.GetAll(validFilter.Filter!)!).Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / validFilter.PageSize!.Value) == 0 ? 1 : (int)Math.Ceiling((double)totalRecords / validFilter.PageSize!.Value);

            // Add Previous and Next page links
            string? prevPageLink = validFilter.PageNumber!.Value > 1
                ? Url.Link("DefaultApi", new { filter = validFilter.Filter == null ? null : validFilter.Filter, pageNumber = (validFilter.PageNumber!.Value > totalPages ? totalPages : validFilter.PageNumber!.Value) - 1, pageSize = validFilter.PageSize!.Value })
                : null;

            string? nextPageLink = validFilter.PageNumber < totalPages
                ? Url.Link("DefaultApi", new { filter = validFilter.Filter == null ? null : validFilter.Filter, pageNumber = validFilter.PageNumber + 1, pageSize = validFilter.PageSize!.Value })
                : null;

            string? firstPage = totalRecords == 0 ? null : Url.Link("DefaultApi", new { filter = validFilter.Filter == null ? null : validFilter.Filter, pageNumber = 1, pageSize = validFilter.PageSize.Value });
            string? lastPage = totalRecords == 0 ? null : Url.Link("DefaultApi", new { filter = validFilter.Filter == null ? null : validFilter.Filter, pageNumber = totalPages, pageSize = validFilter.PageSize.Value });

            var response = new PagedResponseService<List<NguoiDungModel>>(pagedData, validFilter.PageSize.Value, validFilter.PageNumber.Value)
            {
                Filter = validFilter.Filter,
                TotalPage = totalPages,
                TotalRecord = totalRecords,
                PreviousLink = prevPageLink,
                NextLink = nextPageLink,
                FirstPage = firstPage,
                LastPage = lastPage,
                SortBy = null
            };
            return Ok(response);
        }
    }
}