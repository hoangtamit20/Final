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
        public KhoaHocOnlineDbContext(DbContextOptions options) : base(options)
        {
            
        }

        #region
        public DbSet<NguoiDung> NguoiDungs {get;set;}

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>(nd => nd.HasIndex(nd => nd.TenDangNhap).IsUnique());
            base.OnModelCreating(modelBuilder);
        }
    }
}