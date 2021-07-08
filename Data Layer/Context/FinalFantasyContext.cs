using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Context
{
    public class FinalFantasyContext:DbContext
    {
        public DbSet<Arma> Armi { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Eroe> Eroi { get; set; }
        public DbSet<Mostro> Mostri { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; 
                                    Integrated Security = true; 
                                    Initial Catalog = FinalFantasy; 
                                    Server = .\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Arma>(new ArmaConfiguration());
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
            modelBuilder.ApplyConfiguration<Eroe>(new EroeConfiguration());
            modelBuilder.ApplyConfiguration<Mostro>(new MostroConfiguration());
        }
    }
}
