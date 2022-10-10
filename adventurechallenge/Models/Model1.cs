using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace adventurechallenge.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=challenge")
        {
        }

        public virtual DbSet<Challenge> Challenge { get; set; }
        public virtual DbSet<gebruiker> gebruiker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .Property(e => e.ChallengeBeschrijving)
                .IsFixedLength();

            modelBuilder.Entity<gebruiker>()
                .Property(e => e.GebruikerNaam)
                .IsFixedLength();

            modelBuilder.Entity<gebruiker>()
                .Property(e => e.Wachtwoord)
                .IsFixedLength();
        }
    }
}
