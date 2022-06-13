using csharp_bibliotecaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_bibliotecaMvc.Data
{

    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Utente> Utentes { get; set; }
        public DbSet<Libro> Libris { get; set; }
        public DbSet<Prestito> Prestitis { get; set; }
        public DbSet<Autore> Autores { get; set; }
        /*
         * Di default i nomi delle tabelle sono creati al plurale. Questo metodo 
         * serve per specificare dei nomi diversi, in questo caso al singolare.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utente>().ToTable("Utente");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Prestito>().ToTable("Prestito");
            modelBuilder.Entity<Autore>().ToTable("Autore");
            modelBuilder.Entity<Autore>().HasKey(p => new {p.Cognome, p.Nome, p.DataNascita});
        }
    }
}
