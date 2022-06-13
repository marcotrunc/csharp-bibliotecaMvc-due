using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BibliotecaContext context)
        {
            //E' il metodo di EF che crea il database SOLO se già non c'è
            context.Database.EnsureCreated();


            if (context.Autores.Any())
            {
                return;   // DB has been seeded
            }
            var autori = new Autore[]
            {
                new Autore{Nome="Daniel",Cognome="Defoe",DataNascita = DateTime.Parse("26/04/1340")},
                new Autore{Nome="J.K.",Cognome="Rollwing",DataNascita = DateTime.Parse("26/04/1340")},
                new Autore{Nome="Paulo",Cognome="Coelho",DataNascita = DateTime.Parse("26/04/1340")},
                new Autore{Nome="J.R.R.",Cognome="Tolkien",DataNascita = DateTime.Parse("26/04/1340")},
            };

            foreach (Autore a in autori)
            {
                context.Autores.Add(a);
            }

            context.SaveChanges();

            var Defoe = context.Autores.Where(item => item.Cognome == "Defoe").First();
            var Rollwing = context.Autores.Where(item => item.Cognome == "Rollwing").First();
            var Coelho = context.Autores.Where(item => item.Cognome == "Coelho").First();
            var Tolkien = context.Autores.Where(item => item.Cognome == "Tolkien").First();


            // Look for any students.
            if (context.Libris.Any())
            {
                return;   // DB has been seeded
            }
            var libris = new Libro[]
            {
                new Libro{Titolo="Robinson Crusoe",Autori=new List<Autore>{ Defoe }, Anno=1986,Stato="Disponibile",ISBN="IBNG5768HGF", Scaffale = 3},
                new Libro{Titolo="Harry Potter",Autori=new List<Autore>{ Rollwing },Anno=1991,Stato="Disponibile",ISBN="IBNY8732TRE", Scaffale = 5},
                new Libro{Titolo="Come il fiume che scorre",Autori=new List<Autore>{ Coelho },Stato="Disponibile",Anno=2001,ISBN="IBNZ4367BVX", Scaffale = 4},
                new Libro{Titolo="Il signore degli anelli",Autori=new List<Autore>{ Tolkien },Stato="Disponibile",Anno=1998,ISBN="IBNM1234CZA", Scaffale = 4},
                new Libro{Titolo="Lo Hobbit",Anno=2003,Autori=new List<Autore>{ Tolkien },Stato="Disponibile",ISBN="IBNO0172HBQ",Scaffale = 5},

            };

            foreach (Libro l in libris)
            {
                context.Libris.Add(l);
            }

            context.SaveChanges();
            





            if (context.Utentes.Any())
            {
                return;   // DB has been seeded
            }
            var utenti = new Utente[]
            {
                new Utente{Nome="Matteo",Cognome="Imbimbo",Email="matteoimbimbo@alice.it",Password="pippo91"},
                new Utente{Nome="Daniele",Cognome="Rossi",Email="danielerossi@alice.it",Password="pluto92"},
            };

            foreach (Utente u in utenti)
            {
                context.Utentes.Add(u);
            }

            context.SaveChanges();



            var Imbimbo = context.Utentes.Where(item => item.Cognome == "Imbimbo").First();
            var Rossi = context.Utentes.Where(item => item.Cognome == "Rossi").First();

            var libro1 = context.Libris.Where(item => item.ISBN == "IBNG5768HGF").First();
            var libro2 = context.Libris.Where(item => item.ISBN == "IBNY8732TRE").First();
            var libro3 = context.Libris.Where(item => item.ISBN == "IBNZ4367BVX").First();
            var libro4 = context.Libris.Where(item => item.ISBN == "IBNM1234CZA").First();
            var libro5 = context.Libris.Where(item => item.ISBN == "IBNO0172HBQ").First();


            if (context.Prestitis.Any())
            {
                return;   // DB has been seeded
            }
            var prestiti = new Prestito[]
            {
                new Prestito{PrestitoID="1",Inizio=DateTime.Parse("10/12/2021"),Fine=DateTime.Parse("10/01/2022"),Utente=Imbimbo,Libro=libro1},
                new Prestito{PrestitoID="2",Inizio=DateTime.Parse("11/07/2021"),Fine=DateTime.Parse("10/08/2021"),Utente=Imbimbo,Libro=libro2},
                new Prestito{PrestitoID="3",Inizio=DateTime.Parse("05/09/2020"),Fine=DateTime.Parse("05/10/2020"),Utente=Rossi,Libro=libro3},
                new Prestito{PrestitoID="4",Inizio=DateTime.Parse("01/01/2019"),Fine=DateTime.Parse("01/02/2019"),Utente=Rossi,Libro=libro4},
            };

            foreach (Prestito p in prestiti)
            {
                context.Prestitis.Add(p);
            }

            context.SaveChanges();

        }
    }
}
