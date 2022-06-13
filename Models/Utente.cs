namespace csharp_bibliotecaMvc.Models
{
    public class Utente
    {
        public int UtenteID { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        

        public virtual ICollection<Prestito> Prestito { get; set; }

       
    }
}
