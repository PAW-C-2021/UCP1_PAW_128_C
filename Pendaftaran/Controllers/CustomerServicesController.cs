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
    public class CustomerServicesController : Controller
    {
        private readonly PendaftaranContext _context;

        public CustomerServicesController(PendaftaranContext context)
        {
            _context = context;
        }

        // GET: CustomerServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerService.ToListAsync());
        }

        // GET: CustomerServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerService
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customerService == null)
            {
                return NotFound();
            }

            return View(customerService);
        }

        // GET: CustomerServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustomer,NamaCustomerService,JenisKelamin")] CustomerService customerService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerService);
        }

        // GET: CustomerServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerService.FindAsync(id);
            if (customerService == null)
            {
                return NotFound();
            }
            return View(customerService);
        }

        // POST: CustomerServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustomer,NamaCustomerService,JenisKelamin")] CustomerService customerService)
        {
            if (id != customerService.IdCustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerServiceExists(customerService.IdCustomer))
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
            return View(customerService);
        }

        // GET: CustomerServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerService
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customerService == null)
            {
                return NotFound();
            }

            return View(customerService);
        }

        // POST: CustomerServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerService = await _context.CustomerService.FindAsync(id);
            _context.CustomerService.Remove(customerService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerServiceExists(int id)
        {
            return _context.CustomerService.Any(e => e.IdCustomer == id);
        }
    }
}
