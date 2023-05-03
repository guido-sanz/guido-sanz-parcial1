using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.Data
{
    public class MotoContext : DbContext
    {
        public MotoContext (DbContextOptions<MotoContext> options)
            : base(options)
        {
        }

        public DbSet<guido_sanz_parcial1.Models.Moto> Moto { get; set; } = default!;
        public DbSet<guido_sanz_parcial1.Models.Agency> Agency { get; set; } = default!;

        public DbSet<guido_sanz_parcial1.Models.Inventory> Inventory { get; set; } = default!;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Agency>()
        //     .HasMany(p=> p.InvertoryList)
        //     .WithOne(p=> p.Agency)
        //     .HasForeignKey(p => p.IdAgency);

        //     modelBuilder.Entity<Inventory>()
        //     .HasOne(p => p.Agency)
        //     .WithMany()
        //     .HasForeignKey(p => p.IdAgency);

        //     modelBuilder.Entity<Inventory>()
        //     .HasOne(p => p.Moto)
        //     .WithMany()
        //     .HasForeignKey(p => p.IdMoto);
        // }
    }
}
