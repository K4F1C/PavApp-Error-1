using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PavApp.Data;
using PavApp.Models;

namespace PavApp.Controller
{
    public class EmpreadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpreadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empreadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empreado.ToListAsync());
        }

        // GET: Empreadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreado = await _context.Empreado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreado == null)
            {
                return NotFound();
            }

            return View(empreado);
        }

        // GET: Empreadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empreadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Year")] Empreado empreado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empreado);
        }

        // GET: Empreadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreado = await _context.Empreado.FindAsync(id);
            if (empreado == null)
            {
                return NotFound();
            }
            return View(empreado);
        }

        // POST: Empreadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Year")] Empreado empreado)
        {
            if (id != empreado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreadoExists(empreado.Id))
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
            return View(empreado);
        }

        // GET: Empreadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreado = await _context.Empreado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreado == null)
            {
                return NotFound();
            }

            return View(empreado);
        }

        // POST: Empreadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empreado = await _context.Empreado.FindAsync(id);
            _context.Empreado.Remove(empreado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreadoExists(int id)
        {
            return _context.Empreado.Any(e => e.Id == id);
        }
    }
}
