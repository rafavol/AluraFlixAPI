using AluraFlixAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>().HasKey(t => t.Id);
            modelBuilder.Entity<Categoria>().HasKey(t => t.Id);

            modelBuilder.Entity<Categoria>().HasMany<Video>();

        }

        public DbSet<Video> Video { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
