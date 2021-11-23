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
    public class SiswasController : Controller
    {
        private readonly PendaftaranContext _context;

        public SiswasController(PendaftaranContext context)
        {
            _context = context;
        }

        // GET: Siswas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Siswa.ToListAsync());
        }

        // GET: Siswas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // GET: Siswas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Siswas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiswa,NamaSiswa,TanggalLahir,JenisKelamin,Alamat,NoRegistrasi")] Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siswa);
        }

        // GET: Siswas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            return View(siswa);
        }

        // POST: Siswas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiswa,NamaSiswa,TanggalLahir,JenisKelamin,Alamat,NoRegistrasi")] Siswa siswa)
        {
            if (id != siswa.IdSiswa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaExists(siswa.IdSiswa))
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
            return View(siswa);
        }

        // GET: Siswas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // POST: Siswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswa.FindAsync(id);
            _context.Siswa.Remove(siswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswa.Any(e => e.IdSiswa == id);
        }
    }
}
