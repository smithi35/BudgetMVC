using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetApplication.Models;

namespace BudgetApplication.Controllers
{
    public class BudgetItemsController : Controller
    {
        private readonly BudgetApplicationContext _context;

        public BudgetItemsController(BudgetApplicationContext context)
        {
            _context = context;
        }

        // GET: BudgetItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.BudgetItem.ToListAsync());
        }

        // GET: BudgetItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.BudgetItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetItem == null)
            {
                return NotFound();
            }

            return View(budgetItem);
        }

        // GET: BudgetItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,BudgettedAmount")] BudgetItem budgetItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetItem);
        }

        // GET: BudgetItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.BudgetItem.FindAsync(id);
            if (budgetItem == null)
            {
                return NotFound();
            }
            return View(budgetItem);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,BudgettedAmount")] BudgetItem budgetItem)
        {
            if (id != budgetItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetItemExists(budgetItem.Id))
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
            return View(budgetItem);
        }

        // GET: BudgetItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.BudgetItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetItem == null)
            {
                return NotFound();
            }

            return View(budgetItem);
        }

        // POST: BudgetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetItem = await _context.BudgetItem.FindAsync(id);
            _context.BudgetItem.Remove(budgetItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetItemExists(int id)
        {
            return _context.BudgetItem.Any(e => e.Id == id);
        }
    }
}
