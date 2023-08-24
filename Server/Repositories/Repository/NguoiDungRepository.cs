using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities;
using Server.Models;
using Server.Repositories.IRepository;
using Server.Services.FilterService;

namespace Server.Repositories.Repository
{
    public class NguoiDungRepository : IRepositoryOfEntity<NguoiDungModel>
    {
        private readonly KhoaHocOnlineDbContext _context;
        private readonly IMapper _mapper;

        public NguoiDungRepository(KhoaHocOnlineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateEntity(NguoiDungModel entity)
        {
            try
            {
                _context.NguoiDungs!.Add(_mapper.Map<NguoiDung>(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEntity(int id)
        {
            var nguoiDung = await _context.NguoiDungs!.SingleOrDefaultAsync(nd => nd.Id == id);
            if (nguoiDung == null)
                return false;
            try
            {
                _context.NguoiDungs!.Remove(nguoiDung);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<NguoiDungModel>>? GetAll() => _mapper.Map<List<NguoiDungModel>>(await _context.NguoiDungs!.ToListAsync());

        public async Task<List<NguoiDungModel>>? GetAllFullOptions(string filter, string sortBy, int? pageIndex, int? pageSize)
        {
            var query = _context.NguoiDungs!.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(nd => nd.ToString().Contains(filter));
            // sort default HoTen
            query = query.OrderBy(nd => nd.HoTen).ThenBy(nd => nd.TenDangNhap);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "HoTen_Desc":
                        {
                            query = query.OrderByDescending(nd => nd.HoTen);
                        }
                        break;

                    case "TenDangNhap_Asc":
                        {
                            query = query.OrderBy(nd => nd.TenDangNhap);
                        }
                        break;

                    case "TenDangNhap_Desc":
                        {
                            query = query.OrderByDescending(nd => nd.TenDangNhap);
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
            return _mapper.Map<List<NguoiDungModel>>((pageIndex == null && pageSize == null) ? await query.ToListAsync() : await query.Skip((pageIndex!.Value - 1) * pageSize!.Value).Take(pageSize.Value).ToListAsync());
        }

        public async Task<List<NguoiDungModel>>? GetAllFullOptions(PaginationFilterService paginationFilterService)
        {
            var query = _context.NguoiDungs!.AsQueryable();

            if (paginationFilterService.Filter != null)
            {
                query = _context.NguoiDungs!.Where(nd => nd.ToString().Contains(paginationFilterService.Filter.ToString()));
            }

            if (paginationFilterService.PageSize != null && paginationFilterService.PageNumber != null)
            {
                query = _context.NguoiDungs!.Skip((paginationFilterService.PageNumber.Value - 1) * paginationFilterService.PageSize.Value)
                            .Take(paginationFilterService.PageSize.Value);
            }
            return _mapper.Map<List<NguoiDungModel>>(await query.ToListAsync());

        }

        public async Task<NguoiDungModel>? GetEntityById(int id) => _mapper.Map<NguoiDungModel>((await _context.NguoiDungs!.FindAsync(id))!);

        public async Task<bool> UpdateEntity(int? id, NguoiDungModel entity)
        {
            if (id != null)
            {
                if (id.Value != entity.Id)
                    return false;
                var nguoiDung = await _context.NguoiDungs!.FindAsync(id.Value);
                if (nguoiDung == null)
                    return false;
                try
                {
                    _context.NguoiDungs!.Update(_mapper.Map<NguoiDung>(entity));
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }
    }
}