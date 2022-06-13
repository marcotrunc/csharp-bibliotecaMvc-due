namespace csharp_bibliotecaMvc.Models
{
    public class Prestito
    {
        public string PrestitoID { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public int UtenteID { get; set; }
        public int LibroID { get; set; }

        public virtual Libro Libro { get; set; }
        public virtual Utente Utente { get; set; }

        
    }
}
