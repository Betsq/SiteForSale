using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BeautySouthKoreaSiteMVC.Models
{
    public class CosmeticContext : DbContext
    {
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public CosmeticContext(DbContextOptions<CosmeticContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
