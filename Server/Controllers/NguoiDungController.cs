using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     if (await _repositoryOfEntity.GetAll()! == null)
        //     {
        //         return BadRequest("Entity is null");
        //     }
        //     return Ok(await _repositoryOfEntity.GetAll()!);
        // }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilterService filter)
        {
            var validFilter = new PaginationFilterService(filter.Filter!, filter.PageNumber!.Value, filter.PageSize!.Value);
            var pagedData = await _repositoryOfEntity.GetAllFullOptions(validFilter)!;
            var totalRecords = (await _repositoryOfEntity.GetAll()!).Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / validFilter.PageSize!.Value);

            // Add Previous and Next page links
            string? prevPageLink = validFilter.PageNumber!.Value > 1
                ? Url.Link("DefaultApi", new { PageNumber = validFilter.PageNumber!.Value - 1, PageSize = validFilter.PageSize!.Value })
                : null;

            string? nextPageLink = validFilter.PageNumber < totalPages
                ? Url.Link("DefaultApi", new { PageNumber = validFilter.PageNumber + 1, PageSize = validFilter.PageSize!.Value })
                : null;
            
            string? firstPage = Url.Link("DefaultApi", new {PageNumber = 1, PageSize = validFilter.PageSize.Value});
            string? lastPage = Url.Link("DefaultApi", new {PageNumber = totalPages, PageSize = validFilter.PageSize.Value});

            var response = new PagedResponseService<List<NguoiDungModel>>(pagedData, validFilter.PageNumber.Value, validFilter.PageSize.Value)
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