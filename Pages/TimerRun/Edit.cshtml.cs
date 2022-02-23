using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Data;
using MyFitTimer.Models;

namespace MyFitTimer.Pages.TimerRun
{
    public class EditModel : PageModel
    {
        private readonly MyFitTimer.Data.MyFitTimerContext _context;

        public EditModel(MyFitTimer.Data.MyFitTimerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyFitTimer.Models.TimerRun TimerRun { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimerRun = await _context.TimerRuns.FindAsync(id);

            if (TimerRun == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var TimerRunToUpdate = await _context.TimerRuns.FindAsync(id);

            if (TimerRunToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<MyFitTimer.Models.TimerRun>(
                TimerRunToUpdate,
                "timerRun",
                t => t.StartTime, t => t.EndTime))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool TimerRunExists(int id)
        {
            return _context.TimerRuns.Any(e => e.ID == id);
        }
    }
}
