using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSeite.Models;

namespace WebSeite.Controllers
{
    public class KategoriesController : Controller
    {
        private readonly ProduktContext _context;

        public KategoriesController(ProduktContext context)
        {
            _context = context;
        }

        // GET: Kategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorie.ToListAsync());
        }

        // GET: Kategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorie = await _context.Kategorie
                .SingleOrDefaultAsync(m => m.ProduktKategorieId == id);
            if (kategorie == null)
            {
                return NotFound();
            }

            return View(kategorie);
        }

        // GET: Kategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktKategorieId,Name")] Kategorie kategorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorie);
        }

        // GET: Kategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorie = await _context.Kategorie.SingleOrDefaultAsync(m => m.ProduktKategorieId == id);
            if (kategorie == null)
            {
                return NotFound();
            }
            return View(kategorie);
        }

        // POST: Kategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduktKategorieId,Name")] Kategorie kategorie)
        {
            if (id != kategorie.ProduktKategorieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorieExists(kategorie.ProduktKategorieId))
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
            return View(kategorie);
        }

        // GET: Kategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorie = await _context.Kategorie
                .SingleOrDefaultAsync(m => m.ProduktKategorieId == id);
            if (kategorie == null)
            {
                return NotFound();
            }

            return View(kategorie);
        }

        // POST: Kategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategorie = await _context.Kategorie.SingleOrDefaultAsync(m => m.ProduktKategorieId == id);
            _context.Kategorie.Remove(kategorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorieExists(int id)
        {
            return _context.Kategorie.Any(e => e.ProduktKategorieId == id);
        }
    }
}
