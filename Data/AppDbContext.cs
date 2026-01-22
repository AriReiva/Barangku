using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barangku.Model.Entities;


namespace Barangku.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Produk> Produk { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaksi> Transaksi {get; set;}
        public DbSet<DetailTransaksi> DetailTransaksi {get; set;}
    }
}