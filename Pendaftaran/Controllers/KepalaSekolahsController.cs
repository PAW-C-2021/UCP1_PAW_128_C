using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pendaftaran.Models;

namespace Pendaftaran.Controllers
{
    public class KepalaSekolahsController : Controller
    {
        private readonly PendaftaranContext _context;

        public KepalaSekolahsController(PendaftaranContext context)
        {
            _context = context;
        }

        // GET: KepalaSekolahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KepalaSekolah.ToListAsync());
        }

        // GET: KepalaSekolahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepalaSekolah = await _context.KepalaSekolah
                .FirstOrDefaultAsync(m => m.IdKepalaSekolah == id);
            if (kepalaSekolah == null)
            {
                return NotFound();
            }

            return View(kepalaSekolah);
        }

        // GET: KepalaSekolahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KepalaSekolahs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKepalaSekolah,NamaKepalaSekolah")] KepalaSekolah kepalaSekolah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kepalaSekolah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kepalaSekolah);
        }

        // GET: KepalaSekolahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepalaSekolah = await _context.KepalaSekolah.FindAsync(id);
            if (kepalaSekolah == null)
            {
                return NotFound();
            }
            return View(kepalaSekolah);
        }

        // POST: KepalaSekolahs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKepalaSekolah,NamaKepalaSekolah")] KepalaSekolah kepalaSekolah)
        {
            if (id != kepalaSekolah.IdKepalaSekolah)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kepalaSekolah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KepalaSekolahExists(kepalaSekolah.IdKepalaSekolah))
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
            return View(kepalaSekolah);
        }

        // GET: KepalaSekolahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepalaSekolah = await _context.KepalaSekolah
                .FirstOrDefaultAsync(m => m.IdKepalaSekolah == id);
            if (kepalaSekolah == null)
            {
                return NotFound();
            }

            return View(kepalaSekolah);
        }

        // POST: KepalaSekolahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kepalaSekolah = await _context.KepalaSekolah.FindAsync(id);
            _context.KepalaSekolah.Remove(kepalaSekolah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KepalaSekolahExists(int id)
        {
            return _context.KepalaSekolah.Any(e => e.IdKepalaSekolah == id);
        }
    }
}
