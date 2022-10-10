using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace adventurechallenge.Models
{
    public partial class mijncontext : DbContext
    {
        public mijncontext()
            : base("name=mijncontext")
        {
        }

        public virtual DbSet<gebruiker> gebruiker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<gebruiker>()
                .Property(e => e.GebruikerNaam)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<adventurechallenge.Models.Challenge> Challenges { get; set; }
    }
}
