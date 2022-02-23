using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFitTimer.Data;
using MyFitTimer.Models;

namespace MyFitTimer.Pages.TimerRun
{
    public class CreateModel : PageModel
    {
        private readonly MyFitTimer.Data.MyFitTimerContext _context;

        public CreateModel(MyFitTimer.Data.MyFitTimerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyFitTimer.Models.TimerRun TimerRun { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTimerRun = new MyFitTimer.Models.TimerRun();

            if (await TryUpdateModelAsync<MyFitTimer.Models.TimerRun>(
                emptyTimerRun,
                "timerRun",   // Prefix for form value.
                t => t.StartTime, t => t.EndTime))
            {
                _context.TimerRuns.Add(emptyTimerRun);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
