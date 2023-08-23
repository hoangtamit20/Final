using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.IRepository;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly IRepositoryOfEntity<NguoiDungModel> _repositoryOfEntity;

        public NguoiDungController(IRepositoryOfEntity<NguoiDungModel> repositoryOfEntity)
        {
            _repositoryOfEntity = repositoryOfEntity;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_repositoryOfEntity.GetAll() == null)
            {
                return BadRequest("Entity is null");
            }
            return Ok(await _repositoryOfEntity.GetAll()!);
        }
    }
}