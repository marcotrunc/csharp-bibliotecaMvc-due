using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_bibliotecaMvc.Data;
using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Controllers
{
    public class LibroesController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
              return _context.Libris != null ? 
                          View(await _context.Libris.ToListAsync()) :
                          Problem("Entity set 'BibliotecaContext.Libris'  is null.");
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libris == null)
            {
                return NotFound();
            }

            var libro = await _context.Libris.Where(m => m.LibroID == id).Include(p => p.Prestito).ToListAsync();
                //.FirstOrDefaultAsync(m => m.LibroID == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            //Libro myLibro = new Libro();
            //myLibro.Autori.Add(new Autore { Nome = "Dante", Cognome = "Alighieri", DataNascita = DateTime.Parse("26/04/1340") });
            //myLibro.Autori.Add(new Autore { Nome = "Giorgio", Cognome = "Bocca", DataNascita = DateTime.Parse("26/04/1933") });
            ViewData["listaAutori"] = _context.Autores.ToList<Autore>();
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(Libro libro, string[] AutoreData)
        {
            if (ModelState.IsValid)
            {
                string[] str = AutoreData;
                if(libro.Autori == null)
                    libro.Autori = new();

                for(int i = 0; i < str.Length; i++)
                {
                    string[] words = str[i].Split(',');
                    var cercaAutore = _context.Autores.Where(m => (m.Cognome == words[1] && m.Nome == words[0] && m.DataNascita == Convert.ToDateTime(words[2]))).First();
                    if (cercaAutore != null)
                        libro.Autori.Add(cercaAutore);
                    _context.Add(libro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libris == null)
            {
                return NotFound();
            }

            var libro = await _context.Libris.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibroID,Titolo,Anno,Stato,ISBN")] Libro libro)
        {
            if (id != libro.LibroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.LibroID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libris == null)
            {
                return NotFound();
            }

            var libro = await _context.Libris
                .FirstOrDefaultAsync(m => m.LibroID == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libris == null)
            {
                return Problem("Entity set 'BibliotecaContext.Libris'  is null.");
            }
            var libro = await _context.Libris.FindAsync(id);
            if (libro != null)
            {
                _context.Libris.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libris?.Any(e => e.LibroID == id)).GetValueOrDefault();
        }
    }
}
