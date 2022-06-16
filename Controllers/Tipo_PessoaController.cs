using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteEngegraph.Data;
using TesteEngegraph.Models;

namespace TesteEngegraph.Controllers
{
    public class Tipo_PessoaController : Controller
    {
        private readonly TesteEngegraphContext _context;

        public Tipo_PessoaController(TesteEngegraphContext context)
        {
            _context = context;
        }

        // GET: Tipo_Pessoa
        public async Task<IActionResult> Index()
        {
            var testeEngegraphContext = _context.Tipo_Pessoa.Include(t => t.Pessoa);
            return View(await testeEngegraphContext.ToListAsync());
        }

        // GET: Tipo_Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipo_Pessoa == null)
            {
                return NotFound();
            }

            var tipo_Pessoa = await _context.Tipo_Pessoa
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_Pessoa == null)
            {
                return NotFound();
            }

            return View(tipo_Pessoa);
        }

        // GET: Tipo_Pessoa/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id");
            return View();
        }

        // POST: Tipo_Pessoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,PessoaId")] Tipo_Pessoa tipo_Pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", tipo_Pessoa.PessoaId);
            return View(tipo_Pessoa);
        }

        // GET: Tipo_Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipo_Pessoa == null)
            {
                return NotFound();
            }

            var tipo_Pessoa = await _context.Tipo_Pessoa.FindAsync(id);
            if (tipo_Pessoa == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", tipo_Pessoa.PessoaId);
            return View(tipo_Pessoa);
        }

        // POST: Tipo_Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,PessoaId")] Tipo_Pessoa tipo_Pessoa)
        {
            if (id != tipo_Pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_PessoaExists(tipo_Pessoa.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", tipo_Pessoa.PessoaId);
            return View(tipo_Pessoa);
        }

        // GET: Tipo_Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipo_Pessoa == null)
            {
                return NotFound();
            }

            var tipo_Pessoa = await _context.Tipo_Pessoa
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_Pessoa == null)
            {
                return NotFound();
            }

            return View(tipo_Pessoa);
        }

        // POST: Tipo_Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipo_Pessoa == null)
            {
                return Problem("Entity set 'TesteEngegraphContext.Tipo_Pessoa'  is null.");
            }
            var tipo_Pessoa = await _context.Tipo_Pessoa.FindAsync(id);
            if (tipo_Pessoa != null)
            {
                _context.Tipo_Pessoa.Remove(tipo_Pessoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_PessoaExists(int id)
        {
          return (_context.Tipo_Pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
