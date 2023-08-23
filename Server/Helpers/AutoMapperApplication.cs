using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Entities;
using Server.Models;

namespace Server.Helpers
{
    public class AutoMapperApplication : Profile
    {
        public AutoMapperApplication()
        {
            CreateMap<NguoiDung, NguoiDungModel>().ReverseMap();
        }
    }
}