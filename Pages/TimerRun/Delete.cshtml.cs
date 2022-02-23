using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Data;
using MyFitTimer.Models;

namespace MyFitTimer.Pages.TimerRun
{
    public class DeleteModel : PageModel
    {
        private readonly MyFitTimer.Data.MyFitTimerContext _context;

        public DeleteModel(MyFitTimer.Data.MyFitTimerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyFitTimer.Models.TimerRun TimerRun { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimerRun = await _context.TimerRuns.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (TimerRun == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.TimerRuns.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.TimerRuns.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
