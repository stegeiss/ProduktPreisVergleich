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
    public class HerstellersController : Controller
    {
        private readonly ProduktContext _context;

        public HerstellersController(ProduktContext context)
        {
            _context = context;
        }

        // GET: Herstellers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hersteller.ToListAsync());
        }

        // GET: Herstellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftHersteller = await _context.Hersteller
                .SingleOrDefaultAsync(m => m.AnschriftHerstellerID == id);
            if (anschriftHersteller == null)
            {
                return NotFound();
            }

            return View(anschriftHersteller);
        }

        // GET: Herstellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herstellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnschriftHerstellerID,Name,Kundennummer,Strasse,Hausnummer,Ort,Zusatz,PLZ,Email,Homepage,Telefonnummer,Fax,Handy")] AnschriftHersteller anschriftHersteller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anschriftHersteller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anschriftHersteller);
        }

        // GET: Herstellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftHersteller = await _context.Hersteller.SingleOrDefaultAsync(m => m.AnschriftHerstellerID == id);
            if (anschriftHersteller == null)
            {
                return NotFound();
            }
            return View(anschriftHersteller);
        }

        // POST: Herstellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnschriftHerstellerID,Name,Kundennummer,Strasse,Hausnummer,Ort,Zusatz,PLZ,Email,Homepage,Telefonnummer,Fax,Handy")] AnschriftHersteller anschriftHersteller)
        {
            if (id != anschriftHersteller.AnschriftHerstellerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anschriftHersteller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnschriftHerstellerExists(anschriftHersteller.AnschriftHerstellerID))
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
            return View(anschriftHersteller);
        }

        // GET: Herstellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftHersteller = await _context.Hersteller
                .SingleOrDefaultAsync(m => m.AnschriftHerstellerID == id);
            if (anschriftHersteller == null)
            {
                return NotFound();
            }

            return View(anschriftHersteller);
        }

        // POST: Herstellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anschriftHersteller = await _context.Hersteller.SingleOrDefaultAsync(m => m.AnschriftHerstellerID == id);
            _context.Hersteller.Remove(anschriftHersteller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnschriftHerstellerExists(int id)
        {
            return _context.Hersteller.Any(e => e.AnschriftHerstellerID == id);
        }
    }
}
