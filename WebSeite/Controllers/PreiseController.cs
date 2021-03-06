﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSeite.Models;

namespace WebSeite.Controllers
{
    public class PreiseController : Controller
    {
        private readonly ProduktContext _context;

        public PreiseController(ProduktContext context)
        {
            _context = context;
        }

        // GET: Preis
        public async Task<IActionResult> Index()
        {
            var produktContext = _context.Preis.Include(p => p.Anschrift).Include(p => p.Produkt);
            return View(await produktContext.ToListAsync());
        }

        // GET: Preis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preis = await _context.Preis
                .Include(p => p.Anschrift)
                .Include(p => p.Produkt)
                .SingleOrDefaultAsync(m => m.PreisId == id);
            if (preis == null)
            {
                return NotFound();
            }

            return View(preis);
        }

        // GET: Preis/Create
        public IActionResult Create()
        {
            ViewData["AnschriftGeschaeftID"] = new SelectList(_context.Geschaeft, "AnschriftGeschaeftID", "Name");
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "ProduktId", "Name");
            return View();
        }

        // POST: Preis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreisId,Kosten,PreisDatum,ProduktId,AnschriftGeschaeftID")] Preis preis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnschriftGeschaeftID"] = new SelectList(_context.Geschaeft, "AnschriftGeschaeftID", "Name", preis.AnschriftGeschaeftID);
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "ProduktId", "ProduktId", preis.ProduktId);
            return View(preis);
        }

        // GET: Preis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preis = await _context.Preis.SingleOrDefaultAsync(m => m.PreisId == id);
            if (preis == null)
            {
                return NotFound();
            }
            ViewData["AnschriftGeschaeftID"] = new SelectList(_context.Geschaeft, "AnschriftGeschaeftID", "Name", preis.AnschriftGeschaeftID);
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "ProduktId", "ProduktId", preis.ProduktId);
            return View(preis);
        }

        // POST: Preis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreisId,Kosten,PreisDatum,ProduktId,AnschriftGeschaeftID")] Preis preis)
        {
            if (id != preis.PreisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreisExists(preis.PreisId))
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
            ViewData["AnschriftGeschaeftID"] = new SelectList(_context.Geschaeft, "AnschriftGeschaeftID", "Name", preis.AnschriftGeschaeftID);
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "ProduktId", "ProduktId", preis.ProduktId);
            return View(preis);
        }

        // GET: Preis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preis = await _context.Preis
                .Include(p => p.Anschrift)
                .Include(p => p.Produkt)
                .SingleOrDefaultAsync(m => m.PreisId == id);
            if (preis == null)
            {
                return NotFound();
            }

            return View(preis);
        }

        // POST: Preis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preis = await _context.Preis.SingleOrDefaultAsync(m => m.PreisId == id);
            _context.Preis.Remove(preis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreisExists(int id)
        {
            return _context.Preis.Any(e => e.PreisId == id);
        }
    }
}
