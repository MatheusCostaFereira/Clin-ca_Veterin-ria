using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class ConsultaPagarsController : Controller
    {
        private readonly ClinicaVeterinariaContext _context;

        public ConsultaPagarsController(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        // GET: ConsultaPagars
        public async Task<IActionResult> Index(string nome)
        {
            var clinicaVeterinariaContext = from c in _context.ConsultaPagar.Include(x => x.Proprietario) select c;
            if (!String.IsNullOrEmpty(nome))
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(s => s.Proprietario.Nome == nome);
            }
            return View(await clinicaVeterinariaContext.OrderByDescending(x => x.Proprietario.Nome).ToListAsync());
        }

        // GET: ConsultaPagars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPagar = await _context.ConsultaPagar
                .Include(c => c.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaPagar == null)
            {
                return NotFound();
            }

            return View(consultaPagar);
        }

        // GET: ConsultaPagars/Create
        public IActionResult Create()
        {
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome");
            return View();
        }

        // POST: ConsultaPagars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data_Validade,Valor,ProprietarioId")] ConsultaPagar consultaPagar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaPagar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", consultaPagar.ProprietarioId);
            return View(consultaPagar);
        }

        // GET: ConsultaPagars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPagar = await _context.ConsultaPagar.FindAsync(id);
            if (consultaPagar == null)
            {
                return NotFound();
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", consultaPagar.ProprietarioId);
            return View(consultaPagar);
        }

        // POST: ConsultaPagars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data_Validade,Valor,ProprietarioId")] ConsultaPagar consultaPagar)
        {
            if (id != consultaPagar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaPagar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaPagarExists(consultaPagar.Id))
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
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", consultaPagar.ProprietarioId);
            return View(consultaPagar);
        }

        // GET: ConsultaPagars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPagar = await _context.ConsultaPagar
                .Include(c => c.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaPagar == null)
            {
                return NotFound();
            }

            return View(consultaPagar);
        }

        // POST: ConsultaPagars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaPagar = await _context.ConsultaPagar.FindAsync(id);
            _context.ConsultaPagar.Remove(consultaPagar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaPagarExists(int id)
        {
            return _context.ConsultaPagar.Any(e => e.Id == id);
        }
    }
}
