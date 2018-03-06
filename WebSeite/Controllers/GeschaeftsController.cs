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
    public class GeschaeftsController : Controller
    {
        private readonly ProduktContext _context;

        public GeschaeftsController(ProduktContext context)
        {
            _context = context;
        }

        // GET: Geschaefts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Geschaeft.ToListAsync());
        }

        // GET: Geschaefts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftGeschaeft = await _context.Geschaeft
                .SingleOrDefaultAsync(m => m.AnschriftGeschaeftID == id);
            if (anschriftGeschaeft == null)
            {
                return NotFound();
            }

            return View(anschriftGeschaeft);
        }

        // GET: Geschaefts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Geschaefts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnschriftGeschaeftID,Name,Kundennummer,Strasse,Hausnummer,Ort,Zusatz,PLZ,Email,Homepage,Telefonnummer,Fax,Handy")] AnschriftGeschaeft anschriftGeschaeft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anschriftGeschaeft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anschriftGeschaeft);
        }

        // GET: Geschaefts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftGeschaeft = await _context.Geschaeft.SingleOrDefaultAsync(m => m.AnschriftGeschaeftID == id);
            if (anschriftGeschaeft == null)
            {
                return NotFound();
            }
            return View(anschriftGeschaeft);
        }

        // POST: Geschaefts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnschriftGeschaeftID,Name,Kundennummer,Strasse,Hausnummer,Ort,Zusatz,PLZ,Email,Homepage,Telefonnummer,Fax,Handy")] AnschriftGeschaeft anschriftGeschaeft)
        {
            if (id != anschriftGeschaeft.AnschriftGeschaeftID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anschriftGeschaeft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnschriftGeschaeftExists(anschriftGeschaeft.AnschriftGeschaeftID))
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
            return View(anschriftGeschaeft);
        }

        // GET: Geschaefts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anschriftGeschaeft = await _context.Geschaeft
                .SingleOrDefaultAsync(m => m.AnschriftGeschaeftID == id);
            if (anschriftGeschaeft == null)
            {
                return NotFound();
            }

            return View(anschriftGeschaeft);
        }

        // POST: Geschaefts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anschriftGeschaeft = await _context.Geschaeft.SingleOrDefaultAsync(m => m.AnschriftGeschaeftID == id);
            _context.Geschaeft.Remove(anschriftGeschaeft);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnschriftGeschaeftExists(int id)
        {
            return _context.Geschaeft.Any(e => e.AnschriftGeschaeftID == id);
        }
    }
}
