using csharp_bibliotecaMvc.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_bibliotecaMvc.Models
{
    public class Autore
    {
        [Column(Order = 1), System.ComponentModel.DataAnnotations.Key]
        public string Cognome { get; set; }
        [Column(Order = 2), System.ComponentModel.DataAnnotations.Key]
        public string Nome { get; set; }
        [Column(Order = 3), System.ComponentModel.DataAnnotations.Key]
        public DateTime DataNascita { get; set; }
        public ICollection<Libro>? Libri { get; set; }
    }
}