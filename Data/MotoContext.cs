using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace guido_sanz_parcial1.Data
{
    public class MotoContext : IdentityDbContext
    {
        public MotoContext (DbContextOptions<MotoContext> options)
            : base(options)
        {
        }

        public DbSet<guido_sanz_parcial1.Models.Moto> Moto { get; set; } = default!;
        public DbSet<guido_sanz_parcial1.Models.Agency> Agency { get; set; } = default!;

        public DbSet<guido_sanz_parcial1.Models.Inventory> Inventory { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Moto)
                .WithMany()
                .HasForeignKey(i => i.MotoId);
                
        }
    }

    
}
