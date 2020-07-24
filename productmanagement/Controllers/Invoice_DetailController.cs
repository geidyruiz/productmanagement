using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using productmanagement.Models;

namespace productmanagement.Controllers
{
       public class Invoice_DetailController : Controller
    {
        private readonly ProductContext _context;

        public Invoice_DetailController(ProductContext context)
        {
            _context = context;
        }

        // GET: Invoice_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invoice_Details.ToListAsync());
        }
    
        // GET: Invoice_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Detail = await _context.Invoice_Details
                .FirstOrDefaultAsync(m => m.Invoice_Detail_Number == id);
            if (invoice_Detail == null)
            {
                return NotFound();
            }

            return View(invoice_Detail);
        }
  
        // GET: Invoice_Detail/Create
        [Authorize(Roles = "Admin,Accountant")]

        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Invoice_Detail/Create
        [Authorize(Roles = "Admin,Accountant")]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Invoice_Detail_Number,Invoice_Number,ProductId,Quantity,Total_Price")] Invoice_Detail invoice_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice_Detail);
        }
        
        // GET: Invoice_Detail/Edit/5
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Detail = await _context.Invoice_Details.FindAsync(id);
            if (invoice_Detail == null)
            {
                return NotFound();
            }
            return View(invoice_Detail);
        }

        // POST: Invoice_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Invoice_Detail_Number,Invoice_Number,ProductId,Quantity,Total_Price")] Invoice_Detail invoice_Detail)
        {
            if (id != invoice_Detail.Invoice_Detail_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Invoice_DetailExists(invoice_Detail.Invoice_Detail_Number))
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
            return View(invoice_Detail);
        }
   
        // GET: Invoice_Detail/Delete/5
        [Authorize(Roles = "Admin,Accountant")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_Detail = await _context.Invoice_Details
                .FirstOrDefaultAsync(m => m.Invoice_Detail_Number == id);
            if (invoice_Detail == null)
            {
                return NotFound();
            }

            return View(invoice_Detail);
        }

        // POST: Invoice_Detail/Delete/5
        [Authorize(Roles = "Admin,Accountant")]
        [HttpPost, ActionName("Delete")]
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice_Detail = await _context.Invoice_Details.FindAsync(id);
            _context.Invoice_Details.Remove(invoice_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Invoice_DetailExists(int id)
        {
            return _context.Invoice_Details.Any(e => e.Invoice_Detail_Number == id);
        }
    }
}
