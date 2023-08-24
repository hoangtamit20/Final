using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Data
{
    public class KhoaHocOnlineDbContext : DbContext
    {
        public KhoaHocOnlineDbContext(DbContextOptions<KhoaHocOnlineDbContext> options) : base(options){}

        #region
        public DbSet<NguoiDung>? NguoiDungs {get;set;}

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>(nd => nd.HasIndex(nd => nd.TenDangNhap).IsUnique());
            modelBuilder.Entity<NguoiDung>().Property(nd => nd.Created).HasDefaultValue(DateTime.Now);
        }
    }
}